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
    [SerializeField] private List<int> grassRowTypes = new List<int>();
    [SerializeField] private List<GameObject> currentObstacleRows = new List<GameObject>();
    [SerializeField] private float carStartingPos;
    [SerializeField] private PlayerMovement playerMovement;

    // Instantiates the starting amount of rows
    private void Start()
    {
        for (int i = 0; i < maxRowCount - 2; i++)
        {
            CreateGround();
        }

        waterRowTypes.Add(0);
        grassRowTypes.Add(0);
    }

    // Creates rows and removes previous rows in the list, keeping the total the same
    public void CreateGround()
    {
        int row = Random.Range(0, groundTypes.Count);
        int waterType = 0;
        int grassType = 0;
        GameObject obstacle;

        int randomRow = Random.Range(0, 50);
        
        if (playerMovement.GetCurrentScore() % 50 < randomRow)
        {
            row = groundTypes.Count - 1;
        }
        
        switch (row)
        {
            // If the row selected was a grass row, tells the computer which row was selected
            case 0:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                grassType = row;
                break;
            case 1:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                grassType = row;
                break;
            case 2:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                grassType = row;
                break;

            // If the row selected was a water row, tells the computer which row was selected
            case 3:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                row = CheckIfValidWaterRow(row);
                waterType = row;
                break;
            case 4:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                row = CheckIfValidWaterRow(row);
                waterType = row;
                break;
            case 5:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                row = CheckIfValidWaterRow(row);
                waterType = row;
                break;

            // Checks which side the car starts on and spawns the correct vehicle
            case 6:
                float xPosition = RandomizeCarPosition();

                if (xPosition > 0)
                {
                    obstacle = Instantiate(obstacleTypes[0], new Vector2(xPosition, currentRow.y), Quaternion.identity, rowHolder);
                }
                else
                {
                    obstacle = Instantiate(obstacleTypes[1], new Vector2(xPosition, currentRow.y), Quaternion.identity, rowHolder);
                }
                break;

            // Spawns an empty game object for the obstacle
            default:
                obstacle = Instantiate(obstacleTypes[2], currentRow, Quaternion.identity, rowHolder);
                break;
        }

        GameObject ground = Instantiate(groundTypes[row], currentRow, Quaternion.identity, rowHolder);

        // Adds the game objects and int values to their lists
        currentGroundRows.Add(ground);
        currentObstacleRows.Add(obstacle);
        waterRowTypes.Add(waterType);
        grassRowTypes.Add(grassType);

        // Removes the ground and object of the last row once the player moves forward
        if (currentGroundRows.Count > maxRowCount)
        {
            Destroy(currentGroundRows[0]);
            Destroy(currentObstacleRows[0]);

            currentGroundRows.RemoveAt(0);
            currentObstacleRows.RemoveAt(0);
            waterRowTypes.RemoveAt(0);
            grassRowTypes.RemoveAt(0);
        }
        
        currentRow.y += 2.5f;
    }

    // Randomizes starting position of the car
    private float RandomizeCarPosition()
    {
        float xPosition;
        int random = Random.Range(0, 100);

        if (random >= 50)
        {
            xPosition = carStartingPos;
        }
        else
        {
            xPosition = -carStartingPos;
        }

        return xPosition;
    }

    // Checks to make sure the row added connects with a valid water row
    private int CheckIfValidWaterRow(int row)
    {
        switch (row)
        {
            case 4:
                if (waterRowTypes[waterRowTypes.Count - 1] == 5 || grassRowTypes[grassRowTypes.Count - 1] == 1 || grassRowTypes[grassRowTypes.Count - 1] == 2)
                {
                    row = 3;
                }
                break;
            case 5:
                if (waterRowTypes[waterRowTypes.Count - 1] == 4 || grassRowTypes[grassRowTypes.Count - 1] == 1 || grassRowTypes[grassRowTypes.Count - 1] == 2)
                {
                    row = 3;
                }
                break;
            default:
                break;
        }

        return row;
    }
}
