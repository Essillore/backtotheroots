using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPiece : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridPosition;
    private Vector2Int tempVector2;
    // Start is called before the first frame update
    void Start()
    {


    int x = Mathf.RoundToInt(gameObject.transform.position.x);
        int y = Mathf.RoundToInt(gameObject.transform.position.y);
        tempVector2 = new Vector2Int(x, y);
        
        gridPosition = tempVector2;
        
        gridManager.RegisterObject(gridPosition, gameObject);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
