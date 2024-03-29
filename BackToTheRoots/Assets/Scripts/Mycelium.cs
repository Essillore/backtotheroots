using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mycelium : MonoBehaviour
{
    public GridManager gridManager;
    public AdjacentObjectFinder aof;
    public Vector2Int gridPosition;
    public GameObject myceliumPrefab;
    public EarthStats earthStats;

    public float waterInMycelium;
    public float sugarInMycelium = 2f;
    public float phosphorusInMycelium;
    public float nitrogenInMycelium;
    public float potassiumInMycelium = 2f;
    public float calciumInMycelium;


    private float sugarAbsorbionRation = 0.5f;
    private bool connectedToRoots = false;
    private bool exchangeRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        gridPosition = gridManager.GetGridPosition(gameObject);
        int x = Mathf.RoundToInt(gameObject.transform.position.x);
        int y = Mathf.RoundToInt(gameObject.transform.position.y);
        gridPosition = new Vector2Int(x, y);
        earthStats = GetComponentInParent<EarthStats>();
        //earthstats.MyceliumHasBeenAttached();

        
        //gridManager.RegisterObject(gridPosition, gameObject);
        StartCoroutine(Grow());
        StartCoroutine(AbsorbTimer(1f));
    }

    // Update is called once per frame
    void Update()
    {
         if (gridManager.CheckIfTileHasRootPiece(gridPosition))
        {
            RootPiece rootPiece = gridManager.GetRootPiece(gridPosition);
            Debug.Log("Mycelium is on the same tile as a rootpiece");
            //ExchangeNutrients(rootPiece);
            connectedToRoots = true;
        }

        // We want to start this exactly once when the mycelium is connected to roots,
        // not on every frame
        if (connectedToRoots && !exchangeRunning)
        {
            Debug.Log("Starting exchange");
            StartCoroutine(ExchangeTimer(1f));
            exchangeRunning = true;
        }
        
    }

    private IEnumerator Grow()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 8f));
            Debug.Log("Mycelium is growing");
            FindTileToGrowTo();
            
        }
    }
    private void FindTileToGrowTo()
    {

        List<GameObject> adjacentTiles = gridManager.GetAdjacentObjects(gridPosition);
        foreach (GameObject tile in adjacentTiles)
        {   
            // we need to know if the tile already has a mycelium on it,
            // we need a method that tells us if there already is mycelium on the tile
            // tile is a GameObject, we need to know its position in the grid
            Vector2Int gridPosition = gridManager.GetGridPosition(tile);
            if (gridManager.TileContainsMycelium(gridPosition) == false)
            {
                Debug.Log($"Found empty tile at {gridPosition}");
                if (Random.Range(0f, 1f) < 0.3f)
                {
                    sugarInMycelium -= 1f;
                           
                    Vector3 earthSquarePlace = new Vector3(gridPosition.x, gridPosition.y, 0f);
        
                    GameObject rootParentEarthtile = gridManager.GetEarthObject(gridPosition);
                    Instantiate(myceliumPrefab, earthSquarePlace, Quaternion.identity, rootParentEarthtile.transform);
                    
                    
                }
            }   
        }   

    }

    public void AbsorbNutrientsFromEarth() 
    {
        float absorpRatio = 0.01f;

        waterInMycelium += earthStats.waterInTile * absorpRatio;
        earthStats.waterInTile -= earthStats.waterInTile * absorpRatio;
        
        nitrogenInMycelium += earthStats.nitrogenInTile * absorpRatio;
        earthStats.nitrogenInTile -= earthStats.nitrogenInTile * absorpRatio;

        phosphorusInMycelium += earthStats.phosphorusInTile * absorpRatio;  
        earthStats.phosphorusInTile -= earthStats.phosphorusInTile * absorpRatio;

        potassiumInMycelium += earthStats.potassiumInTile * absorpRatio;
        earthStats.potassiumInTile -= earthStats.potassiumInTile * absorpRatio;

        calciumInMycelium += earthStats.calciumInTile * absorpRatio;
        earthStats.calciumInTile -= earthStats.calciumInTile * absorpRatio;
    }

    public IEnumerator AbsorbTimer(float howOften)
    {
        while(true)
        {
            yield return new WaitForSeconds(howOften);
            AbsorbNutrientsFromEarth();
        }
    }   
    
    private void ExchangeNutrients(RootPiece rootPiece) 
    {
        float exchangeRatio = 0.05f;
        rootPiece.GetComponent<RootPiece>().waterInRootpiece += waterInMycelium * exchangeRatio;
        waterInMycelium -= waterInMycelium * exchangeRatio;
        
        rootPiece.GetComponent<RootPiece>().nitrogenInRootpiece += nitrogenInMycelium * exchangeRatio;
        nitrogenInMycelium -= nitrogenInMycelium * exchangeRatio;

        rootPiece.GetComponent<RootPiece>().phosphorusInRootpiece += phosphorusInMycelium * exchangeRatio;
        phosphorusInMycelium -= phosphorusInMycelium * exchangeRatio;

        rootPiece.GetComponent<RootPiece>().potassiumInRootpiece += potassiumInMycelium * exchangeRatio;
        potassiumInMycelium -= potassiumInMycelium * exchangeRatio;

        rootPiece.GetComponent<RootPiece>().calciumInRootpiece += calciumInMycelium * exchangeRatio;
        calciumInMycelium -= calciumInMycelium * exchangeRatio;

        if (rootPiece.GetComponent<RootPiece>().sugarInRootpiece >= sugarAbsorbionRation)
        {
            rootPiece.GetComponent<RootPiece>().sugarInRootpiece -= sugarAbsorbionRation;
            sugarInMycelium += sugarAbsorbionRation;
        };
        

        // todo: add exchange of sugars
    }

    IEnumerator ExchangeTimer(float howOften)
    {
        while(true)
        {
            yield return new WaitForSeconds(howOften);
            ExchangeNutrients(gridManager.GetRootPiece(gridPosition));
        }
    }
}