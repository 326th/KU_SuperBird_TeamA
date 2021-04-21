using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderSFX;
    public Slider sliderBGM;

    // Start is called before the first frame update
    void Start()
    {
        LoadOptions();
    }

    public void ChangeVolBGM(float vol)
    {
        mixer.SetFloat("VolBGM", vol);
    }

    public void ChangeVolSFX(float vol)
    {
        mixer.SetFloat("VolSFX", vol);
    }

    public void SaveOptions()
    {

        PlayerPrefs.SetFloat("PlayerVolBGM", sliderBGM.value);
        PlayerPrefs.SetFloat("PlayerVolSFX", sliderSFX.value);
        PlayerPrefs.Save();
    }

    public void LoadOptions()
    {
        float volBGM, volSFX;
        if (PlayerPrefs.HasKey("PlayerVolBGM"))
        {
            volBGM =  PlayerPrefs.GetFloat("PlayerVolBGM");
            mixer.SetFloat("VolBGM", volBGM);
            sliderBGM.value = volBGM;
        }

        if (PlayerPrefs.HasKey("PlayerVolSFX"))
        {
            volSFX = PlayerPrefs.GetFloat("PlayerVolSFX");
            mixer.SetFloat("VolSFX", volSFX);
            sliderSFX.value = volSFX;
        }
    }
}
