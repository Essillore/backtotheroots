
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseMovement : MonoBehaviour
{
    public GameObject rootSquare;
    // RootGrower rootGrower;
    [SerializeField] private Transform mouseObject;

    [SerializeField]
    private LayerMask placementLayermask;

    [SerializeField]
    private Camera sceneCamera;

    public Grid grid;
    public Tilemap treeRoots;

    public TileBase rootTilePrefab;

    public float gridSize = 1f;

    public Vector3 worldMousePosition;
    public Vector3Int tempVectore;

    private Vector3 lastPosition;

    public Vector3Int tileCoordinates;

    public Vector3Int rootPlacementLenght;

    public List<Vector3Int> tilesPassed;
    public AdjacentObjectFinder aof;
    public GridManager gridManager;
    public float i;
    private Vector2Int gridPosition;
    private Vector2Int oldPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        setGridPosition();

                gridManager.RegisterObject(gridPosition, gameObject);

        tilesPassed = new List<Vector3Int>();
    }

    // Update is called once per frame
    void Update()
    {
        oldPosition = gridPosition;
        
        MousePosition();
        setGridPosition();
        if (oldPosition != gridPosition)
        {
            // mouse has moved!
            Debug.Log("Mouse has moved!");
            GetAdjacentObjects();
            oldPosition = gridPosition;
        }

        if (Input.GetButtonDown("PlaceRoot"))
        {
            PlaceRoot();
        }

        if (Input.GetButton("PlaceRoot")) 
        {
            DragRoot();
        }
        if (Input.GetButtonUp("PlaceRoot"))
        {
            foreach (Vector3Int tile in tilesPassed)
            {
                Debug.Log(tile);
                AddRoot(tile);
            }
            tilesPassed.Clear();
        }
    }

    private void setGridPosition()
    {
        int x = Mathf.RoundToInt(gameObject.transform.position.x);
        int y = Mathf.RoundToInt(gameObject.transform.position.y);
        gridPosition = new Vector2Int(x, y);

    }


    private void GetAdjacentObjects() 
    {
        Debug.Log("GetAdjacentObjects called");

        if (gridManager.CheckIfAdjacentHasRoot(gridPosition, Vector2Int.up)) {
            Debug.Log("Adjacent up has root");   
        }
        if (gridManager.CheckIfAdjacentHasRoot(gridPosition, Vector2Int.right)) {
            Debug.Log("Adjacent right has root");   
        }
        if (gridManager.CheckIfAdjacentHasRoot(gridPosition, Vector2Int.down)) {
            Debug.Log("Adjacent down has root");   
        }
        if (gridManager.CheckIfAdjacentHasRoot(gridPosition, Vector2Int.left)) {
            Debug.Log("Adjacent left has root");   
        }
        return;
    }

    public void AddRoot(Vector3Int tile)
    {
      
            treeRoots.SetTile(tile, rootTilePrefab);
            Debug.Log("Root added");
    
    }
    public void MousePosition()
    {

        // Vector3Int gridPosition = grid.WorldToCell(mousePosition);//

        // MouseToSelectedMapPosition();
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        worldMousePosition = sceneCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, sceneCamera.nearClipPlane));

        // Update the object's position to match the world mouse position (only X and Y axes for a 2D game)
        //mouseObject.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);

        // Snap the object's position to the grid
        float snappedX = Mathf.Round(worldMousePosition.x / gridSize) * gridSize;
        float snappedY = Mathf.Round(worldMousePosition.y / gridSize) * gridSize;

        // Update the object's position to match the snapped world mouse position (only X and Y axes for a 2D game)
        transform.position = new Vector3(snappedX, snappedY, transform.position.z);

        //GetAdjacentObjects();
    }

    public void DragRoot() 
    {
        
            Vector3Int tileLocation = treeRoots.WorldToCell(worldMousePosition);
            // if current location is not in the list, add it
            if (!tilesPassed.Contains(tileLocation)) 
            {

                tilesPassed.Add(tileLocation);
            }
            

   
    }
    public void PlaceRoot()
    {

        tileCoordinates = treeRoots.WorldToCell(worldMousePosition);
        // Convert the world mouse position to grid coordinates using the Tilemap component

        lastPosition = tileCoordinates;


        // Handle the grid tile click (you can replace this with your own logic)
        Debug.Log($"Clicked tile at grid coordinates: ({tileCoordinates.x}, {tileCoordinates.y})");

        Vector2Int whichEarthSquare = Vector2Int.RoundToInt(worldMousePosition);
        Vector3 earthSquarePlace = new Vector3(whichEarthSquare.x, whichEarthSquare.y, 0f);

        //  foreach (var item in gridM.gridObjects)
        GameObject rootParentEarthtile = gridManager.GetEarthObject(whichEarthSquare);
        Instantiate(rootSquare, earthSquarePlace, Quaternion.identity, rootParentEarthtile.transform);

        // Create a tile at the clicked grid coordinates
        // treeRoots.SetTile(tilesPassed, rootTilePrefab);


        // Create a tile at the clicked grid coordinates
        treeRoots.SetTile(tileCoordinates, rootTilePrefab);

        if (Input.GetButton("PlaceRoot"))
        {   
            Debug.Log("button pressed");
            Vector3Int tileLocation = treeRoots.WorldToCell(worldMousePosition);
            
            // where Type is the datatype of the objects to be stored in the list
            if (tileCoordinates != lastPosition)
            {
                tilesPassed.Add(tileLocation);
                lastPosition = tileCoordinates;
            }

            if (Input.GetButtonUp("PlaceRoot"))
            {
            

                foreach (Vector3Int location in tilesPassed)
                {
                    treeRoots.SetTile(location, rootTilePrefab);

                }
                {

                
    
                }





                /*rootPlacementLenght = tileCoordinates - treeRoots.WorldToCell(worldMousePosition);
                i = rootPlacementLenght.magnitude;

                tilesPassed 


                */

            }
        }
    }
    


}
