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

    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Vector3Int gridPosition = grid.WorldToCell(mousePosition);//

        // MouseToSelectedMapPosition();
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 worldMousePosition = sceneCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, sceneCamera.nearClipPlane));

        // Update the object's position to match the world mouse position (only X and Y axes for a 2D game)
        //mouseObject.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);

        // Snap the object's position to the grid
        float snappedX = Mathf.Round(worldMousePosition.x / gridSize) * gridSize;
        float snappedY = Mathf.Round(worldMousePosition.y / gridSize) * gridSize;

        // Update the object's position to match the snapped world mouse position (only X and Y axes for a 2D game)
        transform.position = new Vector3(snappedX, snappedY, transform.position.z);

        if (Input.GetButtonDown("PlaceRoot"))
            {
            // Convert the world mouse position to grid coordinates using the Tilemap component
            Vector3Int tileCoordinates = treeRoots.WorldToCell(worldMousePosition);

            // Handle the grid tile click (you can replace this with your own logic)
            Debug.Log($"Clicked tile at grid coordinates: ({tileCoordinates.x}, {tileCoordinates.y})");

            // Create a tile at the clicked grid coordinates
            treeRoots.SetTile(tileCoordinates, rootTilePrefab);
        }

    }

    private void FixedUpdate()
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
