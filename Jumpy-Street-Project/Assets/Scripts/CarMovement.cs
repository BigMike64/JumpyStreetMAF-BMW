using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Vector3 startingPos;
    
    private void Awake()
    {
        StartCoroutine(movement(4f));
        transform.position = startingPos;
    }

    public IEnumerator movement(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = new Vector3(-transform.position.x, transform.position.y);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
