using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject titlePanel, helpPanel, creditsPanel, changeCharacterPanel;

    [SerializeField] private GameObject chicken;
    [SerializeField] List<Sprite> chickenSprites;
    private int currentCharacter;

    void Start()
    {
        titlePanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
        changeCharacterPanel.SetActive(false);

        currentCharacter = 0;
        chicken.GetComponent<Image>().sprite = chickenSprites[currentCharacter];
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
        changeCharacterPanel.SetActive(false);
    }

    public void OnCreditsButtonClick()
    {
        creditsPanel.SetActive(true);
        helpPanel.SetActive(false);
        titlePanel.SetActive(false);
        changeCharacterPanel.SetActive(false);
    }

    public void OnBackButtonClick()
    {
        titlePanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
        changeCharacterPanel.SetActive(false);
    }

    public void OnChangeCharacterButtonClick()
    {
        creditsPanel.SetActive(false);
        helpPanel.SetActive(false);
        titlePanel.SetActive(false);
        changeCharacterPanel.SetActive(true);
    }

    // Cycles through the available characters
    public void OnLeftButtonClick()
    {
        if (currentCharacter - 1 >= 0)
        {
            print("switching to next character");
            chicken.GetComponent<Image>().sprite = chickenSprites[currentCharacter - 1];
            currentCharacter -= 1;
        }
    }

    // Cycles through the available characters
    public void OnRightButtonClick()
    {
        if (currentCharacter + 1 <= chickenSprites.Count - 1)
        {
            print("switching to next character");
            chicken.GetComponent<Image>().sprite = chickenSprites[currentCharacter + 1];
            currentCharacter += 1;
        }
    }

    // Sets the chosen character for use in the main game
    public void OnConfirmButtonClick()
    {
        ChooseCharacter();

        titlePanel.SetActive(true);
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
        changeCharacterPanel.SetActive(false);
    }

    // Correctly chooses the character
    private void ChooseCharacter()
    {
        if (currentCharacter < 4)
        {
            PlayerPrefs.SetInt("PlayerCharacter", currentCharacter + 12);
        }
        else
        {
            PlayerPrefs.SetInt("PlayerCharacter", currentCharacter + 24);
        }
    }
}
