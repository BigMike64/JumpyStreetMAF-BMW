using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowGenerator : MonoBehaviour
{
    private Vector2 currentRow = new Vector2(0, -2.5f);
    private int maxRowCount = 5;
    
    [SerializeField] private Transform rowHolder;
    [SerializeField] private List<GameObject> groundTypes = new List<GameObject>();
    [SerializeField] private List<GameObject> objectTypes = new List<GameObject>();
    [SerializeField] private List<GameObject> currentGroundRows = new List<GameObject>();

    // Instantiates the starting amount of rows
    private void Start()
    {
        for (int i = 0; i < maxRowCount - 1; i++)
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
        currentGroundRows.Add(ground);

        if (currentGroundRows.Count > maxRowCount)
        {
            Destroy(currentGroundRows[0]);
            currentGroundRows.RemoveAt(0);
        }
        
        currentRow.y += 2.5f;
    }
}
