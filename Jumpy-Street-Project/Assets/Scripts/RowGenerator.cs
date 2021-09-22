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
    [SerializeField] private List<int> waterRowTypes = new List<int>();
    [SerializeField] private List<GameObject> currentObstacleRows = new List<GameObject>();
    [SerializeField] private List<float> xPositions = new List<float>();

    // Instantiates the starting amount of rows
    private void Start()
    {
        for (int i = 0; i < maxRowCount - 2; i++)
        {
            CreateGround();
        }

        waterRowTypes.Add(0);
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
        int waterType = 0;
        GameObject obstacle;

        switch (row)
        {
            // Spawns the tree in a random position on the row
            case 0:
                obstacle = Instantiate(obstacleTypes[0], new Vector2(RandomizeTreePosition(), currentRow.y), Quaternion.identity, rowHolder);
                break;

            case 1:
                obstacle = Instantiate(obstacleTypes[3], currentRow, Quaternion.identity, rowHolder);
                row = checkIfValidWaterRow(row);
                waterType = row;
                break;
            case 2:
                obstacle = Instantiate(obstacleTypes[3], currentRow, Quaternion.identity, rowHolder);
                row = checkIfValidWaterRow(row);
                waterType = row;
                break;
            case 3:
                obstacle = Instantiate(obstacleTypes[3], currentRow, Quaternion.identity, rowHolder);
                row = checkIfValidWaterRow(row);
                waterType = row;
                break;

            // Checks which side the car starts on and spawns the correct vehicle
            case 4:
                float xPosition = RandomizeCarPosition();

                if (xPosition > 0)
                {
                    obstacle = Instantiate(obstacleTypes[1], new Vector2(xPosition, currentRow.y), Quaternion.identity, rowHolder);
                }
                else
                {
                    obstacle = Instantiate(obstacleTypes[2], new Vector2(xPosition, currentRow.y), Quaternion.identity, rowHolder);
                }
                break;

            // Spawns an empty game object for the obstacle
            default:
                obstacle = Instantiate(obstacleTypes[3], currentRow, Quaternion.identity, rowHolder);
                break;
        }

        GameObject ground = Instantiate(groundTypes[row], currentRow, Quaternion.identity, rowHolder);

        currentGroundRows.Add(ground);
        currentObstacleRows.Add(obstacle);
        waterRowTypes.Add(waterType);

        if (currentGroundRows.Count > maxRowCount)
        {
            Destroy(currentGroundRows[0]);
            Destroy(currentObstacleRows[0]);

            currentGroundRows.RemoveAt(0);
            currentObstacleRows.RemoveAt(0);
            waterRowTypes.RemoveAt(0);
        }
        
        currentRow.y += 2.5f;
    }

    // Randomizes x position of the tree
    private float RandomizeTreePosition()
    {
        float xPosition;
        int random = Random.Range(0, 8);

        if (random < xPositions.Count / 2 || random > xPositions.Count / 2)
        {
            xPosition = xPositions[random];
        }
        else
        {
            xPosition = 0f;
        }

        return xPosition;
    }

    // Randomizes starting position of the car
    private float RandomizeCarPosition()
    {
        float xPosition;
        int random = Random.Range(0, 100);

        if (random >= 50)
        {
            xPosition = xPositions[xPositions.Count - 1];
        }
        else
        {
            xPosition = xPositions[0];
        }

        return xPosition;
    }

    // Checks to make sure the row added connects with a valid water row
    private int checkIfValidWaterRow(int row)
    {
        switch (row)
        {
            case 2:
                if (waterRowTypes[waterRowTypes.Count - 1] == 3)
                {
                    row = 1;
                }
                break;
            case 3:
                if (waterRowTypes[waterRowTypes.Count - 1] == 2)
                {
                    row = 1;
                }
                break;
            default:
                break;
        }

        return row;
    }
}
