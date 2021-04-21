using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePairController : MonoBehaviour
{
    PipeController topPipe;
    PipeController bottomPipe;
    public void SetPipeHeight(float maxRange, float pipeGap, float offset)
    {
        PipeController[] pipes = gameObject.GetComponentsInChildren<PipeController>();
        bottomPipe = pipes[0];
        topPipe = pipes[1];
        bottomPipe.SetPipeHeight(((maxRange - pipeGap) + (offset * 2)) / 4, Vector3.down * maxRange / 2);
        topPipe.SetPipeHeight(((maxRange - pipeGap) - (offset * 2)) / 4, Vector3.down * maxRange / 2);
        topPipe.gameObject.transform.Rotate(180, 0, 0);
    }
}
