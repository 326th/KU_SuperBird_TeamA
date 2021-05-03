using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingLoader : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("PlaySetting"))
        {
            int playerSetting = PlayerPrefs.GetInt("PlaySetting");
            if (Mathf.Floor(playerSetting / 4) != 0)
            {
                GameObject.Find("[MenuManager]").GetComponent<MenuController>().timeScaler = 1.85f;
            }
            if (Mathf.Floor(playerSetting / 2) % 2 != 0)
            {
                GameObject.Find("Character").GetComponent<BirdController>().mirror = true ;
            }
            if (playerSetting % 2 != 0)
            {
                GameObject.Find("Character").GetComponent<BirdController>().gravScale = -1 ;
            }
        }
    }
}
