using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Dictionary<Vector2Int, GameObject> gridObjects = new Dictionary<Vector2Int, GameObject>();

    public void RegisterObject(Vector2Int position, GameObject obj)
    {
        if (!gridObjects.ContainsKey(position))
        {
            gridObjects[position] = obj;
        }
   
    }

    public GameObject GetAdjacentObject(Vector2Int currentPosition, Vector2Int direction)
    {
        Vector2Int adjacentPosition = currentPosition + direction;

        if (gridObjects.TryGetValue(adjacentPosition, out GameObject adjacentObject))
        {
            return adjacentObject;
        }
        else
        {
            return null;
        }
    }

    public GameObject GetEarthObject(Vector2Int currentPosition)
    {
        if (gridObjects.TryGetValue(currentPosition, out GameObject earthObject))
        {
            return earthObject;
        }
        else
        {
            return null;
        }
    }


    public bool CheckIfAdjacentHasRoot(Vector2Int currentPosition, Vector2Int direction)
    {
        Vector2Int adjacentPosition = currentPosition + direction;

        if (gridObjects.TryGetValue(adjacentPosition, out GameObject adjacentObject))
        {
            if (adjacentObject.GetComponentInChildren<RootPiece>() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
