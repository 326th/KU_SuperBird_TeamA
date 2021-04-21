using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public GameObject pipePrfab;
    public GameObject birdPrefab;
    public float pipeSpacing = 1f;

    void Start()
    {
        LevelGenerator();
    }

    void LevelGenerator()
    {
        for(int i = 0; i < 10; i++)
        {
            var pipe = Instantiate(pipePrfab);
            pipe.transform.position = new Vector3(i * pipeSpacing, 0, 0);
            PipePairController pipePairController = pipe.GetComponent<PipePairController>();
            pipePairController.SetPipeHeight(10,2,0);
        }
    }
}
