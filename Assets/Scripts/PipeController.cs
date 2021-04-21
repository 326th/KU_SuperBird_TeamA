using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    GameObject pipeBody;
    GameObject pipeHead;
    private float headHeight = 0.2f;

    /// <summary>
    /// This Function set the Pipe to that height to any given point relative to it's parent.
    /// </summary>
    /// <param name="height">How tall do you want the pipe to be (in meters).</param>
    /// <param name="pipeBottom">Pipe's starting location Relative to it's parent.</param>
    public void SetPipeHeight(float height,Vector3 pipeBottom)
    {
        
        BoxCollider[] childs = gameObject.GetComponentsInChildren<BoxCollider>();
        pipeBody = childs[0].gameObject;
        pipeHead = childs[1].gameObject;
        gameObject.transform.localPosition = Vector3.zero;
        pipeBody.transform.localScale = new Vector3(1, height, 1);
        pipeBody.transform.position += ( Vector3.up * height);
        pipeBody.transform.position += pipeBottom;
        pipeHead.transform.localPosition = Vector3.zero;
        pipeHead.transform.position += ((Vector3.up * ((height)- headHeight) ) + new Vector3(0,pipeBody.transform.position.y,0));
    }
}
