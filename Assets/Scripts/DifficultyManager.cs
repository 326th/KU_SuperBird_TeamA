using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    private Text buttonText;
    private void Awake()
    {
        buttonText = gameObject.GetComponentInChildren<Text>();
    }
    public void SwitchActive(bool status)
    {
        if (status)
        {
            buttonText.text = "Abnormal";
        }
        else
        {
            buttonText.text = "Normal";
        }
    }
}
