using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = GetHighScore("HighScore");
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void SetHighScore(string HighScore, int Score)
    {
        PlayerPrefs.SetInt(HighScore, Score);
    }

    public int GetHighScore(string HighScore)
    {
        return PlayerPrefs.GetInt(HighScore);
    }    
}
