using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.position = transform.position + new Vector3(0, 2.5f);
            camera.transform.position = camera.transform.position + new Vector3(0, 2.5f);
        }
        /*if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0, -2.5f);
        } */
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(2.5f, 0);
            
            if (transform.position.x > 10)
            {
                Debug.Log("Chicken crossed the death barrier");
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
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
    }
}
