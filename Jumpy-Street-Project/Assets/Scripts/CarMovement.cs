using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // The starting position of the car
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private float movementTime;
    
    // When the car spawns, the car moves to the opposite side of the screen
    private void Awake()
    {
        startingPos = transform.position;
        StartCoroutine(Movement(movementTime));
    }

    // When the car gets to the opposite side,
    // the car's position is reset and then moved to the opposite side again
    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position = startingPos;
            StartCoroutine(Movement(4f));
        }
    }

    // Moves the car to the opposite side of the screen
    public IEnumerator Movement(float time)
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
