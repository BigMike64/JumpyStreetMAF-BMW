using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] new private GameObject camera;

    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] Text scoreText;
    [SerializeField] Text deathText;
    [SerializeField] Text finalScoreText;
    [SerializeField] Text highestScoreText;
    private int currentScore = 0;
    [SerializeField] private HighScore hs;
    private int highScore;

    [SerializeField] Sprite[] chickenSpriteArray;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private RowGenerator rowGenerator;
    [SerializeField] BgMusic backgroundMusic;

    // Faces the chosen chicken sprite the correct direction, and then displays the score
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chickenSpriteArray[PlayerPrefs.GetInt("PlayerCharacter", 12)];

        scoreText.text = "Score: " + currentScore;
        highScore = hs.GetHighScore("HighScore");
        deathPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    // Allows the player to move up, right, and left within the confines of the screen
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow) && !pausePanel.activeInHierarchy)
        {
            spriteRenderer.sprite = chickenSpriteArray[PlayerPrefs.GetInt("PlayerCharacter", 12)];

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 3f);

            if (hit.collider != null && hit.collider.CompareTag("Tree"))
            {
                return;
            }

            rowGenerator.CreateGround();

            transform.position = transform.position + new Vector3(0, 2.5f);
            camera.transform.position = camera.transform.position + new Vector3(0, 2.5f);

            FindObjectOfType<AudioManager>().Play("Jump");

            currentScore += 1;
            scoreText.text = "Score: " + currentScore;

            CheckHighScore();
            hs.GetHighscoreText().text = "High Score: " + highScore;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !pausePanel.activeInHierarchy)
        {
            spriteRenderer.sprite = chickenSpriteArray[PlayerPrefs.GetInt("PlayerCharacter", 12) - 4];

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 3f);

            if (hit.collider != null && hit.collider.CompareTag("Tree"))
            {
                return;
            }

            transform.position = transform.position + new Vector3(2.5f, 0);
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !pausePanel.activeInHierarchy)
        {
            spriteRenderer.sprite = chickenSpriteArray[PlayerPrefs.GetInt("PlayerCharacter", 12) - 8];

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 3f);

            if (hit.collider != null && hit.collider.CompareTag("Tree"))
            {
                return;
            }

            transform.position = transform.position + new Vector3(-2.5f, 0);
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (pausePanel.activeInHierarchy)
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            currentScore -= 1;

            FindObjectOfType<AudioManager>().Play("Splash");
            deathText.text = "The chicken could not cross the road.\nTry again?";
            Death();
        }

        if (collision.CompareTag("Car"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
            deathText.text = "The chicken could not cross the road.\nTry again?";
            Death();
        }
    }

    // If the chicken goes off screen, kill the chicken and show the death screen
    private void OnBecameInvisible()
    {
        if(!deathPanel.activeInHierarchy)
        {
            deathText.text = "Don't give up!\nTry again?";
            Death();
        }
    }

    public void CheckHighScore()
    {
        if(currentScore > highScore)
        {
            hs.SetHighScore("HighScore", currentScore);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    // Displays the death screen and the final and highest score
    private void Death()
    {
        deathPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + currentScore;
        highestScoreText.text = "High Score: " + highScore;

        gameObject.SetActive(false);
        backgroundMusic.Stop();
    }
}
