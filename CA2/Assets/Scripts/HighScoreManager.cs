using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{

    public int getHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public void setHighScore(int score)
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
