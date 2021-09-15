using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject titlePanel, helpPanel, creditsPanel;

    void Start()
    {
        titlePanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void OnPlayButtonClick()
    {
        print("moving to the next scene");

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }

    public void OnQuitButtonClick()
    {
        print("Quitting the game");
        Application.Quit();
    }    

    public void OnHelpButtonClick()
    {
        helpPanel.SetActive(true);
        creditsPanel.SetActive(false);
        titlePanel.SetActive(false);
    }

    public void OnCreditsButtonClick()
    {
        creditsPanel.SetActive(true);
        helpPanel.SetActive(false);
        titlePanel.SetActive(false);
    }

    public void OnBackButtonClick()
    {
        Start();
    }
}
