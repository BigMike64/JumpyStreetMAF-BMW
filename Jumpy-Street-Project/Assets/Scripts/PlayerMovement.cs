using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.position = transform.position + new Vector3(0, 2.5f);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0, -2.5f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(2.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-2.5f, 0);
        }
    }
}
