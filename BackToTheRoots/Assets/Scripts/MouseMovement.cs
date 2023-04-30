using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseMovement : MonoBehaviour
{
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

    private Vector3 lastPosition;

    public Vector3Int tileCoordinates;

    public Vector3Int rootPlacementLenght;

    public List<Vector3Int> tilesPassed;

    public float i;
    // Start is called before the first frame update
    void Start()
    {
        tilesPassed = new List<Vector3Int>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition();

        if (Input.GetButtonDown("PlaceRoot"))
        {
            PlaceRoot();
        }
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

        
    }

    public void PlaceRoot()
    {

        tileCoordinates = treeRoots.WorldToCell(worldMousePosition);
        // Convert the world mouse position to grid coordinates using the Tilemap component

        lastPosition = tileCoordinates;


        // Handle the grid tile click (you can replace this with your own logic)
        Debug.Log($"Clicked tile at grid coordinates: ({tileCoordinates.x}, {tileCoordinates.y})");

        // Create a tile at the clicked grid coordinates
        treeRoots.SetTile(tileCoordinates, rootTilePrefab);

        if (Input.GetButton("PlaceRoot"))
        {
            Vector3Int tileLocation = treeRoots.WorldToCell(worldMousePosition);
            
            // where Type is the datatype of the objects to be stored in the list
            if (tileCoordinates != lastPosition)
            {
                tilesPassed.Add(tileLocation);
                lastPosition = tileCoordinates;
            }

            if (Input.GetButtonUp("PlaceRoot"))
            {

                /*rootPlacementLenght = tileCoordinates - treeRoots.WorldToCell(worldMousePosition);
                i = rootPlacementLenght.magnitude;

                tilesPassed 

                // Create a tile at the clicked grid coordinates
                treeRoots.SetTile(tilesPassed, rootTilePrefab);
                */

            }
        }
    }
    

    public void FixedUpdate()
    {
        

    }
        
          public Vector3 MouseToSelectedMapPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = sceneCamera.nearClipPlane;
            Ray myRay = sceneCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit, 111, placementLayermask))
            {
                //  transform.position = hit.point;

                // transform.position = Vector3.Lerp(transform.position, hit.point, 0.1f);

                mouseObject.position = hit.point;
              //  lastPosition = hit.point;


            }
            return lastPosition;
        
    }


}
