using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkyBoxController : MonoBehaviour
{
    public List<Material> Skyboxes;
    private void Awake()
    {
        int ran = Random.Range(0, Skyboxes.Count);
        RenderSettings.skybox  = Skyboxes[ran];
    }

}
