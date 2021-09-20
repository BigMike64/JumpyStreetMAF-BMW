using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] new private GameObject camera;
    private Vector3 currentPosition;
    [SerializeField] Sprite[] chickenSpriteArray;
    private SpriteRenderer spriteRenderer;
    [SerializeField] GameObject deathPanel;
    [SerializeField] Text scoreText;
    private int currentScore = 0;

    // Gets the sprite renderer component of the chicken
    private void Start()
    {
        scoreText.text = "Score: " + currentScore;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        deathPanel.SetActive(false);
    }

    // Allows the player to move up, right, and left within the confines of the screen
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = chickenSpriteArray[3];
            currentPosition = transform.position;
            transform.position = transform.position + new Vector3(0, 2.5f);
            camera.transform.position = camera.transform.position + new Vector3(0, 2.5f);

            currentScore += 1;
            scoreText.text = "Score: " + currentScore;
        }
        /*if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = chickenSpriteArray[0];
            currentPosition = transform.position;
            transform.position = transform.position + new Vector3(0, -2.5f);
            camera.transform.position = camera.transform.position + new Vector3(0, -2.5f);
        }*/
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = chickenSpriteArray[2];
            currentPosition = transform.position;
            transform.position = transform.position + new Vector3(2.5f, 0);
            
            if (transform.position.x > 10)
            {
                Debug.Log("Chicken crossed the death barrier");
                deathPanel.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = chickenSpriteArray[1];
            currentPosition = transform.position;
            transform.position = transform.position + new Vector3(-2.5f, 0);

            if (transform.position.x < -10)
            {
                Debug.Log("Chicken crossed the death barrier");
                deathPanel.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
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

        if (collision.CompareTag("Tree"))
        {
            transform.position = currentPosition;
        }
    }
}
