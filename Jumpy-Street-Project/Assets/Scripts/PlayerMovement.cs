using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] new private GameObject camera;

    [SerializeField] GameObject deathPanel;
    [SerializeField] Text scoreText;
    private int currentScore = 0;
    [SerializeField] private HighScore hs;
    private int highScore;

    [SerializeField] Sprite[] chickenSpriteArray;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private RowGenerator rowGenerator;

    // Faces the chosen chicken sprite the correct direction, and then displays the score
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chickenSpriteArray[PlayerPrefs.GetInt("PlayerCharacter", 12)];

        scoreText.text = "Score: " + currentScore;
        highScore = hs.GetHighScore("HighScore");
        deathPanel.SetActive(false);
    }

    // Allows the player to move up, right, and left within the confines of the screen
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
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

            currentScore += 1;
            scoreText.text = "Score: " + currentScore;

            CheckHighScore();
            hs.highScoreText.text = "High Score: " + highScore;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = chickenSpriteArray[PlayerPrefs.GetInt("PlayerCharacter", 12) - 4];

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 3f);

            if (hit.collider != null && hit.collider.CompareTag("Tree"))
            {
                return;
            }

            transform.position = transform.position + new Vector3(2.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = chickenSpriteArray[PlayerPrefs.GetInt("PlayerCharacter", 12) - 8];

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 3f);

            if (hit.collider != null && hit.collider.CompareTag("Tree"))
            {
                return;
            }

            transform.position = transform.position + new Vector3(-2.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Debug.Log("Chicken drowned");
            currentScore -= 1;
            deathPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Car"))
        {
            Debug.Log("Chicken got ran over");
            deathPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // If the chicken goes off screen, kill the chicken and show the death screen
    private void OnBecameInvisible()
    {
        Debug.Log("Chicken crossed the death barrier");
        deathPanel.SetActive(true);
        gameObject.SetActive(false);

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
}
