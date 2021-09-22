using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowGenerator : MonoBehaviour
{
    private Vector2 currentRow = new Vector2(0, 0);
    private int maxRowCount = 5;
    
    [SerializeField] private Transform rowHolder;
    [SerializeField] private List<GameObject> groundTypes = new List<GameObject>();
    [SerializeField] private List<GameObject> obstacleTypes = new List<GameObject>();
    [SerializeField] private List<GameObject> currentGroundRows = new List<GameObject>();
    [SerializeField] private List<GameObject> currentObstacleRows = new List<GameObject>();

    // Instantiates the starting amount of rows
    private void Start()
    {
        
        for (int i = 0; i < maxRowCount - 2; i++)
        {
            CreateGround();
        }
    }

    // When the player moves forward, creates new rows
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CreateGround();
        }
    }

    // Creates rows and removes previous rows in the list, keeping the total the same
    private void CreateGround()
    {
        int row = Random.Range(0, groundTypes.Count);

        GameObject ground = Instantiate(groundTypes[row], currentRow, Quaternion.identity, rowHolder);
        GameObject obstacle;

        switch (row)
        {
            case 0:
                obstacle = Instantiate(obstacleTypes[0], new Vector2(RandomizeObstaclePosition(), currentRow.y), Quaternion.identity, rowHolder);
                break;
            case 4:
                obstacle = Instantiate(obstacleTypes[1], new Vector2(RandomizeObstaclePosition(), currentRow.y), Quaternion.identity, rowHolder);
                break;
            default:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                break;
        }

        currentGroundRows.Add(ground);
        currentObstacleRows.Add(obstacle);

        if (currentGroundRows.Count > maxRowCount)
        {
            Destroy(currentGroundRows[0]);
            Destroy(currentObstacleRows[0]);

            currentGroundRows.RemoveAt(0);
            currentObstacleRows.RemoveAt(0);
        }
        
        currentRow.y += 2.5f;
    }

    // Randomizes x position of the obstacle
    private float RandomizeObstaclePosition()
    {
        float xPosition = 0f;
        int random = Random.Range(0, 8);

        switch (random)
        {
            case 0:
                xPosition = -10f;
                break;
            case 1:
                xPosition = -7.5f;
                break;
            case 2:
                xPosition = -5f;
                break;
            case 3:
                xPosition = -2.5f;
                break;
            case 5:
                xPosition = 2.5f;
                break;
            case 6:
                xPosition = 5f;
                break;
            case 7:
                xPosition = 7.5f;
                break;
            case 8:
                xPosition = 10f;
                break;
            default:
                xPosition = 0f;
                break;
        }

        return xPosition;
    }
}
