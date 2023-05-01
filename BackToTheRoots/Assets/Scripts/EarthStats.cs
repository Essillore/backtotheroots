using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthStats : MonoBehaviour
{
    public float waterInTile = 30f;
    public float phosphorusInTile = 7f;
    public float nitrogenInTile = 15f;
    public float calciumInTile = 5f;
    public float potassiumInTile = 3f;
    public GridManager gridManager;
    public Vector2Int gridPosition;
        private Vector2Int tempVector2;

    public RootPiece rootPiece;

    // Start is called before the first frame update
    void Start()
    {
        int x = Mathf.RoundToInt(gameObject.transform.position.x);
        int y = Mathf.RoundToInt(gameObject.transform.position.y);
        tempVector2 = new Vector2Int(x, y);
        gridPosition = tempVector2;
        gridManager.RegisterObject(tempVector2, gameObject);

        // at surface, the range is 110-170, at 0, the range is 60-120, at -6 the range is 0-60
        phosphorusInTile = (gridPosition.y * 10 ) + Random.Range(60f, 120f);
        // at surface, the range is 150-220, at 0, the range is 90-160, at -6 the range is 30-100
        nitrogenInTile = (gridPosition.y * 10) + Random.Range(90f, 160f);

        /*if (gameObject.gridPosition.y>0)s
        {
            phosphorusInTile = Random.Range(20f, 50f);
            nitrogenInTile = Random.Range(30f, 80f);
        }
        else
        {
            phosphorusInTile = Random.Range(1f, 20f);
            nitrogenInTile = Random.Range(3f, 50f);
        }*/
        
              
        waterInTile = Random.Range(1f, 20f);
        calciumInTile = Random.Range(3f, 10f);
        potassiumInTile = Random.Range(3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RootHasBeenAttached()
    {
       rootPiece = GetComponentInChildren<RootPiece>();
        Debug.Log("Root Has been Attached");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.GetComponent<EarthStats>())
            {
                print("Touching");
            
        }

       
    }

    public string GetNutrientLevels()
    {
        return "Water: " + (int)waterInTile + "\n" + " Phosphorus: " + (int)phosphorusInTile +"\n" +  " Nitrogen: " + (int)nitrogenInTile + "\n" + 
        " Calcium: " + (int)calciumInTile + "\n" + " Potassium: " + (int)potassiumInTile;
    }

}
