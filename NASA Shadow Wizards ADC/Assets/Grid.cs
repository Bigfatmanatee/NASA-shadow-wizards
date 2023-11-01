using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    /*public LayerMask isUnwalkable;
    int gridSizeY, gridSizeX;
    public Vector2 gridWorldSize;
    Node[,] grid = new Node[3201, 3201];
    public float nodeRadius;

    void CreateGrid(float[,] heightValues)
    {
        float nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathd.RoundToInt(gridWorldSize.y / nodeDiameter);

        for (int i = 0; i < 3201; i++)
        {
            for (int j = 0; j < 3201; j++)
            {
                grid[i, j] = new Node(true, worldPoint);
            }       
        }

        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize/2 - Vector3.forward * gridWorldSize/2;

        // adding increments of node diameter (starting at bottom left) until full grid made (on both axis)
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                //Where we are
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                //Collision Check
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius));
                //making grid (array)
                grid[x, y] = new Node(walkable, worldPoint);
            }
        }
    }
    
    void Start ()
    {
        //How many nodes can fit in our grid?
        
    }
    */
}







