using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mycelium : MonoBehaviour
{
    public GridManager gridManager;
    public AdjacentObjectFinder aof;
    public Vector2Int gridPosition;
    public GameObject myceliumPrefab;

    // Start is called before the first frame update
    void Start()
    {

        int x = Mathf.RoundToInt(gameObject.transform.position.x);
        int y = Mathf.RoundToInt(gameObject.transform.position.y);
        gridPosition = new Vector2Int(x, y);
                
        //gridManager.RegisterObject(gridPosition, gameObject);
        StartCoroutine(Grow());
    }

    // Update is called once per frame
    void Update()
    {
        print ("Mycelium is starting");
    }

    private IEnumerator Grow()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            Debug.Log("Mycelium is growing");
            FindTileToGrowTo();
            
        }
    }
    private void FindTileToGrowTo()
    {

        List<GameObject> adjacentTiles = gridManager.GetAdjacentObjects(gridPosition);
        List<Vector2Int> emptyTiles = new List<Vector2Int>();
        foreach (GameObject tile in adjacentTiles)
        {   
            // we need to know if the tile already has a mycelium on it,
            // we need a method that tells us if there already is mycelium on the tile
            // tile is a GameObject, we need to know its position in the grid
            Vector2Int gridPosition = gridManager.GetGridPosition(tile);
            if (gridManager.TileContainsMycelium(gridPosition) == false)
            {
                Debug.Log($"Found empty tile at {gridPosition}");
                if (Random.Range(0f, 1f) < 0.5f)
                {
                    
                           
                    Vector3 earthSquarePlace = new Vector3(gridPosition.x, gridPosition.y, 0f);
        
                    GameObject rootParentEarthtile = gridManager.GetEarthObject(gridPosition);
                    Instantiate(myceliumPrefab, earthSquarePlace, Quaternion.identity, rootParentEarthtile.transform);
                    
                }
            }   
        }   

    }
}