using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private int highScore;

    // Gets the highscore playerpref, and displays the highscore as a string
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

    public Text GetHighscoreText()
    {
        return highScoreText;
    }
}
