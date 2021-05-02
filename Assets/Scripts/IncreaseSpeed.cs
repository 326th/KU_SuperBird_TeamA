using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public bool increaseSpeed;
    public float fasterBirdSpeed = 7f;
    private void Awake()
    {
        if (increaseSpeed)
            GameObject.Find("Bird").GetComponent<BirdController>().moveSpeed = fasterBirdSpeed;
    }
}
