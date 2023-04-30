using UnityEngine;

public class AdjacentObjectFinder : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridPosition;
    private Vector2Int tempVector2;

    private void Start()
    {
     
        int x = Mathf.RoundToInt(gameObject.transform.position.x);
        int y = Mathf.RoundToInt(gameObject.transform.position.y);
        tempVector2 = new Vector2Int(x, y);
        Debug.Log($"tempVector2 is {tempVector2}");
        gridPosition = tempVector2;
        
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
