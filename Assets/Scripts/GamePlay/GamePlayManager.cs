using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : RandomGenerator
{
    public GameObject pipePrefab;
    public float pipeSpacing;
    public Strategy strategy;

    void Awake()
    {
        //change strategy here
        strategy = new SinRandomStrategy(0,50,0.8f,1.6f);
        LevelGenerator();
    }

    void LevelGenerator()
    {
        for(int i = 0; i < 5; i++)
        {
            var pipe = Instantiate(pipePrefab);
            pipe.transform.position = new Vector3(i * pipeSpacing + 3, 0, 0);
            PipePairController pipePairController = pipe.GetComponent<PipePairController>();
            pipePairController.SetPipeHeight(10,2, strategy.GetNextNumber());
        }
    }
}
