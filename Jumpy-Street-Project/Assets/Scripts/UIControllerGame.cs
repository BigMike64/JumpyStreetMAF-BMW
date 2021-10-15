using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerGame : MonoBehaviour
{
    [SerializeField] BgMusic backgroundMusic;

    public void OnQuitButtonClick()
    {
        print("Quitting the game");
        Application.Quit();
    }

    public void OnRetryButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        backgroundMusic.Play();
    }

    public void OnMainMenuClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene - 1);
    }
}
