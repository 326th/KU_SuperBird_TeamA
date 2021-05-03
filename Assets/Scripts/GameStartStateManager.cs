using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartStateManager : MonoBehaviour
{
    [SerializeField] private bool isNormalMode = false;
    [SerializeField] private bool mirror = false;
    [SerializeField] private bool gravity = false;

    public DifficultyManager difficultyButton;
    public CheckBoxHandler mirrorBox;
    public CheckBoxHandler gravityBox;
    private void Start()
    {
        if (PlayerPrefs.HasKey("PlaySetting"))
        {
            int playerSetting = PlayerPrefs.GetInt("PlaySetting");
            if(Mathf.Floor(playerSetting / 4) != 0)
            {
                SwitchDifficulty();
            }
            if(Mathf.Floor(playerSetting / 2) % 2 != 0)
            {
                SwitchMirror();
            }
            if (playerSetting % 2 != 0)
            {
                SwitchGravity();
            }
        }
    }
    public void SwitchMirror()
    {
        mirror = !mirror;
        mirrorBox.SwitchActive(mirror);
    }
    public void SwitchGravity()
    {
        gravity = !gravity;
        gravityBox.SwitchActive(gravity);
    }
    public void SwitchDifficulty()
    {
        isNormalMode = !isNormalMode;
        difficultyButton.SwitchActive(isNormalMode);
    }
    public void SaveGameSetting()
    {
        int playerSetting = 0;
        if (isNormalMode) { playerSetting += 4; }
        if (mirror) { playerSetting += 2; }
        if (gravity) { playerSetting += 1; }
        PlayerPrefs.SetInt("PlaySetting",playerSetting);
    }
}
