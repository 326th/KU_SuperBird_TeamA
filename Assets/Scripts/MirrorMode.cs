using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMode : MonoBehaviour
{
    public bool mirror;
    public GameObject gameCamera;
    public GameObject gameLight;
    // Start is called before the first frame update
    void Start()
    {
        if (mirror)
        {
            gameCamera.transform.position = new Vector3(
                gameCamera.transform.position.x,
                gameCamera.transform.position.y,
                gameCamera.transform.position.z * -1
            );
            gameCamera.transform.eulerAngles = new Vector3(
                gameCamera.transform.eulerAngles.x,
                gameCamera.transform.eulerAngles.y + 180,
                gameCamera.transform.eulerAngles.z
            );
            gameLight.transform.eulerAngles = new Vector3(
                gameLight.transform.eulerAngles.x + 90,
                gameLight.transform.eulerAngles.y,
                gameLight.transform.eulerAngles.z
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
