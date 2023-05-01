using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Dictionary<Vector2Int, GameObject> gridObjects = new Dictionary<Vector2Int, GameObject>();
    // we need a method for finding the position of the tile in the grid
    public Vector2Int GetGridPosition(GameObject obj)
    {
        return new Vector2Int(
            Mathf.RoundToInt(obj.transform.position.x),
            Mathf.RoundToInt(obj.transform.position.y)
        );
    }
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

    public bool TileContainsMycelium(Vector2Int currentPosition)
    {
        if (gridObjects.TryGetValue(currentPosition, out GameObject earthObject))
        {
            if (earthObject.GetComponentInChildren<Mycelium>() != null)
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
    public List<GameObject> GetAdjacentObjects(Vector2Int position) {
        Vector2Int[] directions = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };
        List<GameObject> adjacentObjects = new List<GameObject>();
        foreach (Vector2Int direction in directions)
        {
            GameObject adjacentObject = GetAdjacentObject(position, direction);
            if (adjacentObject != null)
            {
                adjacentObjects.Add(adjacentObject);
            }
        }
        return adjacentObjects;
    }


}
