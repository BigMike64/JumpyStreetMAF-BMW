using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] new private GameObject camera;
    private Vector3 currentPosition;

    // Allows the player to move up, right, and left within the confines of the screen
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentPosition = transform.position;
            transform.position = transform.position + new Vector3(0, 2.5f);
            camera.transform.position = camera.transform.position + new Vector3(0, 2.5f);
        }
        /*if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0, -2.5f);
        } */
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentPosition = transform.position;
            transform.position = transform.position + new Vector3(2.5f, 0);
            
            if (transform.position.x > 10)
            {
                Debug.Log("Chicken crossed the death barrier");
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            currentPosition = transform.position;
            transform.position = transform.position + new Vector3(-2.5f, 0);

            if (transform.position.x < -10)
            {
                Debug.Log("Chicken crossed the death barrier");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Debug.Log("Chicken drowned");
        }

        if (collision.CompareTag("Tree"))
        {
            transform.position = currentPosition;
        }
    }
}
