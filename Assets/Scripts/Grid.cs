using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject cellPrefab; 
    public int rows = 20; 
    public int columns = 20; 
    public float cellSize = 1f; 

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 cellPosition = new Vector3(col * cellSize, row * -cellSize, 0);

                GameObject cell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                cell.transform.SetParent(transform); 

                cell.name = "Cell_" + row + "_" + col;
            }
        }
    }
}
