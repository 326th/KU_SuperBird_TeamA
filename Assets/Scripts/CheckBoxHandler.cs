using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxHandler : MonoBehaviour
{
    private Transform checkBox;
    private void Awake()
    {
        checkBox = gameObject.GetComponentsInChildren<Transform>()[1];
        checkBox.gameObject.SetActive(false);
    }
    public void SwitchActive(bool status)
    {
        checkBox.gameObject.SetActive(status);
    }
}
