using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject SpaceBar;
    private GameObject deadText;
    public float jumpPower = 3f;
    public float moveSpeed = 1f;
    public int score = 0;
    public float QTEDuration = 5;
    public int QTEIncrement = 5;
    public bool mirror = false;
    public int gravScale = 1;
    public float mirrorTextShift = 100;
    public float DeathTime = 3.3f;
    private float currentDeathTime = 0;
    private int currentQTERequirement = 0;
    private int currentQTEbuttonCount = 0;
    private float currentQTETime = -1;
    private bool zoomed_in = false;
    private float pipeSpacing;
    Camera playerCamera;
    private int pipePassed = 0;
    private int scoreMultiplier = 1;
    [Header("Text")]
    public Text textScore;
    public Text textMultiplier;
    public Text textScoreText;
    private int storedScore;
    private int survivedQTE = 0;
    [Header("Sound Effect")]
    public AudioSource deadAudio;
    public AudioSource jumpEffect;
    public AudioSource passQTE;

    AudioClip jumpSound;
    private void Start()
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
        jumpSound = jumpEffect.clip;
        if (mirror)
        {
            GameObject.Find("ScoreGroup").transform.position += Vector3.left * mirrorTextShift;
            var light = GameObject.Find("Directional Light");
            light.transform.eulerAngles = new Vector3(
                light.transform.eulerAngles.x + 90,
                light.transform.eulerAngles.y,
                light.transform.eulerAngles.z
                );
            playerCamera.transform.eulerAngles = new Vector3(
                playerCamera.transform.eulerAngles.x,
                playerCamera.transform.eulerAngles.y + 180,
                playerCamera.transform.eulerAngles.z
                );
            FlipCamera();
        }
        Physics.gravity = Vector3.down * Mathf.Abs(Physics.gravity.y) * gravScale;
        jumpPower = Mathf.Abs(jumpPower) * gravScale;
        deadText = GameObject.Find("DeathText");
        deadText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if(currentDeathTime > 0)
        {
            if (currentDeathTime > DeathTime)
            {
                SceneManager.LoadScene("GameOverScene");
            }
            currentDeathTime += Time.deltaTime;
            return;
        }
        if (survivedQTE >0)
        {
            score = storedScore;
            pipePassed = 0;
            SetScoreText();
            passQTE.Play();
            survivedQTE --;
        }
        if(currentQTETime >= 0)
        {
            HandleQTE();
            return;
        }
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            jumpEffect.PlayOneShot(jumpSound);
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
                survivedQTE = 3;
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
            pipePassed++;
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
        storedScore = score;
        ToggleZoom();
        currentQTETime = 0;
        currentQTERequirement += QTEIncrement;
        scoreMultiplier = 1;
        pipePassed = 0;
        SetMultiplierText();
    }
    private void GameOver()
    {
        deadText.SetActive(true);
        SpaceBar.SetActive(false);
        deadAudio.Play();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.SetInt("Score", score);
        currentDeathTime += Time.deltaTime;
    }
    private void Score()
    {
        score += scoreMultiplier;
        SetScoreText();
        if (pipePassed >= 5)
        {
            scoreMultiplier++;
            pipePassed = 0;
            SetMultiplierText();
        }
    }

    private void SetScoreText()
    {
        textScore.text = score.ToString();
    }

    public void SetMultiplierText()
    {
        textMultiplier.text = "X" + scoreMultiplier.ToString();
    }
    private void ToggleZoom()
    {
        zoomed_in = !zoomed_in;
        if (zoomed_in)
        {
            playerCamera.gameObject.GetComponent<CameraFollow>().stop = true;
            playerCamera.transform.position = transform.position + (Vector3.back * 4);
            playerCamera.fieldOfView = 25;
            SpaceBar.SetActive(true);
            textScore.gameObject.SetActive(false);
            textScoreText.gameObject.SetActive(false);
            textMultiplier.gameObject.SetActive(false);
            if (mirror)
            {
                FlipCamera();
            }
        return;
        }
        playerCamera.transform.position = new Vector3(0, 0, -7);
        playerCamera.gameObject.GetComponent<CameraFollow>().stop = false;
        playerCamera.fieldOfView = 60;
        SpaceBar.SetActive(false);
        textScore.gameObject.SetActive(true);
        textScoreText.gameObject.SetActive(true);
        textMultiplier.gameObject.SetActive(true);
        if (mirror)
        {
            FlipCamera();
        }
    }
    private void FlipCamera()
    {  
        playerCamera.transform.position = new Vector3(
            playerCamera.transform.position.x,
            playerCamera.transform.position.y,
            playerCamera.transform.position.z * -1
            );
    }
}
