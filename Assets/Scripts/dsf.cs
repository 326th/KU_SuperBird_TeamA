using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dsf : MonoBehaviour
{
    public GameObject[] adfdsf;
    public int numbird = 1;
    private void Awake()
    {
        /// load player pref
        var bird = Instantiate(adfdsf[numbird]);
        bird.transform.parent = gameObject.transform;
    }

}
