using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePairController : MonoBehaviour
{
    PipeController topPipe;
    PipeController bottomPipe;
    GameObject trigger;
    /// <summary>
    /// Set the pipe pair to face each other vertically with gap in the middle.
    /// </summary>
    /// <param name="maxRange">Total length of both pipes including the gap (in meters).</param>
    /// <param name="pipeGap">The length of the gap between both pipes(in meters).</param>
    /// <param name="gapOffset">how far the gap wull go up or down (in meters).</param>
    public void SetPipeHeight(float maxRange, float pipeGap, float gapOffset)
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        bottomPipe = transforms[1].gameObject.GetComponent<PipeController>();
        topPipe = transforms[5].gameObject.GetComponent<PipeController>();
        trigger = transforms[9].gameObject;
        bottomPipe.SetPipeHeight(((maxRange - pipeGap) + (gapOffset * 2)) / 4, Vector3.down * maxRange / 2);
        topPipe.SetPipeHeight(((maxRange - pipeGap) - (gapOffset * 2)) / 4, Vector3.down * maxRange / 2);
        topPipe.gameObject.transform.Rotate(180, 0, 0);
        trigger.transform.localScale = new Vector3(1, pipeGap, 1);
        trigger.transform.position += Vector3.up * gapOffset;
    }
}
