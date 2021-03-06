using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject SpaceBar;
    public float jumpPower = 3f;
    public float moveSpeed = 1f;
    public int score = 0;
    public float QTEDuration = 5;
    public int QTEIncrement = 5;
    private int currentQTERequirement = 0;
    private int currentQTEbuttonCount = 0;
    private float currentQTETime = -1;
    private bool zoomed_in = false;
    private float pipeSpacing;
    private bool mirrorMode;
    Camera playerCamera;


    private void Awake()
    {
        playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        SpaceBar = GameObject.Find("SpaceBar");
        SpaceBar.SetActive(false);
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("Bird's Rigidbody not found!");
        rb.velocity = Vector3.right * moveSpeed;
        var gamePlayManager = GameObject.Find("[GamePlayManager]").GetComponent<GamePlayManager>();
        pipeSpacing = gamePlayManager.pipeSpacing;
        var mirrorModeManager = GameObject.Find("[MirrorModeManager]").GetComponent<MirrorMode>();
        mirrorMode = mirrorModeManager.mirror;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentQTETime >= 0)
        {
            HandleQTE();
        }
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x,jumpPower);
        } 
    }

    private void HandleQTE()
    {
        currentQTETime += Time.deltaTime;

        if (currentQTETime > QTEDuration)
        {
            if (currentQTEbuttonCount >= currentQTERequirement)
            {
                // deinitiate QTE
                rb.isKinematic = false;
                ToggleZoom();
                currentQTETime = -1;
                transform.position = new Vector3(Mathf.Floor((transform.position.x - 3)/ pipeSpacing) * pipeSpacing, 0, 0);
                rb.velocity = Vector3.right * moveSpeed;
                currentQTEbuttonCount = 0;
            }
            else
            {
                GameOver();
                return;
            }
        }
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            currentQTEbuttonCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pipes")
        {
            Death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PipePair"|| other.gameObject.tag == "Trigger") { return; }
        Death();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            Score();
        }
    }
    private void Death()
    {
        if (rb.isKinematic)
        {
            return;
        }
        // initiate QTE
        rb.isKinematic = true;
        ToggleZoom();
        currentQTETime = 0;
        currentQTERequirement += QTEIncrement;
    }
    private void GameOver()
    {
        print("You are dead LOL");
    }
    private void Score()
    {
        score ++;
        print(score);
    }
    private void ToggleZoom()
    {
        zoomed_in = !zoomed_in;
        if (zoomed_in)
        {
            playerCamera.gameObject.GetComponent<CameraFollow>().stop = true;
            var newPos = transform.position + (Vector3.back * 4);
            if (mirrorMode)
            {
                newPos = transform.position - (Vector3.back * 4);
            }
            playerCamera.transform.position = newPos;
            playerCamera.fieldOfView = 25;
            SpaceBar.SetActive(true);
            return;
        }
        playerCamera.transform.position = new Vector3(0, 0, -7);
        playerCamera.gameObject.GetComponent<CameraFollow>().stop = false;
        playerCamera.fieldOfView = 60;
        SpaceBar.SetActive(false);
    }
}
