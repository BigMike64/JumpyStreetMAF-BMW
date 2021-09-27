using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Vector3 startingPos;
    
    private void Awake()
    {
        startingPos = transform.position;
        StartCoroutine(movement(4f));
    }

    private void OnBecameInvisible()
    {
        transform.position = startingPos;
        StartCoroutine(movement(4f));
    }

    public IEnumerator movement(float time)
    {
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
