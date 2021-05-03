using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoader : MonoBehaviour
{
    private int highScore = 0;
    private int score = 0;

    public Text highScoreText;
    public Text scoreText;
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        highScoreText.text = highScore.ToString();
        scoreText.text = score.ToString();
    }
}