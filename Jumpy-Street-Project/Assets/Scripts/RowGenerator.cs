using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowGenerator : MonoBehaviour
{
    private Vector2 currentRow = new Vector2(0, -5);
    private int maxRowCount = 5;
    
    [SerializeField] private Transform rowHolder;
    [SerializeField] private List<RowData> rowDatas = new List<RowData>();
    [SerializeField] private List<GameObject> currentGroundRows = new List<GameObject>();

    // Instantiates the starting amount of rows
    private void Start()
    {
        for (int i = 0; i < maxRowCount; i++)
        {
            CreateGround(true);
        }

        maxRowCount = currentGroundRows.Count;
    }

    // When the player moves forward, creates new rows
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            CreateGround(false);
        }
    }

    // Creates rows and removes previous rows in the list, keeping the total the same
    private void CreateGround(bool isStart)
    {
        int groundChosen = Random.Range(0, rowDatas.Count);
        int rowsInSuccession = Random.Range(1, rowDatas[groundChosen].maxInSuccession);

        for (int i = 0; i < rowsInSuccession; i++)
        {
            GameObject ground = Instantiate(rowDatas[groundChosen].row, currentRow, Quaternion.identity, rowHolder);
            currentGroundRows.Add(ground);

            // Checks if the game is starting, if it's not, removes rows
            if (!isStart)
            {
                if (currentGroundRows.Count > maxRowCount)
                {
                    Destroy(currentGroundRows[0]);
                    currentGroundRows.RemoveAt(0);
                }
            }

            currentRow.y += 2.5f;
        }
    }
}
