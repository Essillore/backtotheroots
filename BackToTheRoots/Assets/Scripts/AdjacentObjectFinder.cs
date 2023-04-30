using UnityEngine;

public class AdjacentObjectFinder : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridPosition;

    private void Start()
    {
        gridManager.RegisterObject(gridPosition, gameObject);
        FindAdjacentObjects();
    }

    private void FindAdjacentObjects()
    {
        Vector2Int[] directions = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };

        foreach (Vector2Int direction in directions)
        {
            GameObject adjacentObject = gridManager.GetAdjacentObject(gridPosition, direction);

            if (adjacentObject != null)
            {
                Debug.Log($"Found adjacent GameObject '{adjacentObject.name}' at {gridPosition + direction}");
            }
            else
            {
                Debug.Log($"No adjacent GameObject found at {gridPosition + direction}");
            }
        }
    }
}
