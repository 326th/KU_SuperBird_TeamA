using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTeleporterController : RandomGenerator
{
    private float pipeSpacing;
    private Strategy strategy;
    private GameObject pipePrefab;
    private void Start()
    {
        var gamePlayManager = GameObject.Find("[GamePlayManager]").GetComponent<GamePlayManager>();
        pipeSpacing = gamePlayManager.pipeSpacing;
        strategy = gamePlayManager.strategy;
        pipePrefab = gamePlayManager.pipePrefab;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PipePair")
        {
            var pipe = Instantiate(pipePrefab);
            pipe.transform.position = other.transform.position + Vector3.right * pipeSpacing * 5;
            pipe.GetComponent<PipePairController>().SetPipeHeight(10, 2, strategy.GetNextNumber());
            Destroy(other.gameObject);
        }
    }
}
