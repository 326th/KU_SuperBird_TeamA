using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public bool stop = false;
    public float offsetX = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            return;
        }
        Vector3 newPos = new Vector3(player.transform.position.x + offsetX, transform.position.y, transform.position.z);
        transform.position = newPos;
    }
}
