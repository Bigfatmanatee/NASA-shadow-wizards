using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPosition;

    public Node(bool isWalkable, Vector3 isWorldPosition)
    {
        walkable = isWalkable;
        worldPosition = isWorldPosition;
    }
}
