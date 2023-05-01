using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPiece : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridPosition;
    private Vector2Int tempVector2;
    public EarthStats earthstats;

    private float waterInRootpiece = 0f;
    private float phosphorusInRootpiece = 0f;
    private float nitrogenInRootpiece = 0f;
    private float calciumInRootpiece = 0f;
    private float potassiumInRootpiece = 0f;


    // Start is called before the first frame update
    void Start()
    {


    int x = Mathf.RoundToInt(gameObject.transform.position.x);
        int y = Mathf.RoundToInt(gameObject.transform.position.y);
        tempVector2 = new Vector2Int(x, y);
        
        gridPosition = tempVector2;
        
        gridManager.RegisterObject(gridPosition, gameObject);

        earthstats = GetComponentInParent<EarthStats>();

        earthstats.RootHasBeenAttached();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RootAbsorbsNutrients()
    {
        float rootAbsorbRatio = 0.01f;

        float rootAbsorbsWater = earthstats.waterInTile * rootAbsorbRatio;
        earthstats.waterInTile -= rootAbsorbsWater;
        absorbWater(rootAbsorbsWater);

        float rootAbsorbsPhosphorus = earthstats.phosphorusInTile * rootAbsorbRatio;
        earthstats.phosphorusInTile -= rootAbsorbsPhosphorus;
        absorbPhosphorus(rootAbsorbsPhosphorus);

        float rootAbsorbsNitrogen = earthstats.nitrogenInTile * rootAbsorbRatio;
        earthstats.nitrogenInTile -= rootAbsorbsNitrogen;
        absorbNitrogen(rootAbsorbsNitrogen);

        float rootAbsorbsCalcium = earthstats.calciumInTile * rootAbsorbRatio;
        earthstats.calciumInTile -= rootAbsorbsCalcium;
        absorbCalcium(rootAbsorbsCalcium);

        float rootAbsorbsPotassium = earthstats.potassiumInTile * rootAbsorbRatio;
        earthstats.potassiumInTile -= rootAbsorbsPotassium;
        absorbPotassium(rootAbsorbsPotassium);
    }

    public void absorbWater(float amount)
    {
        waterInRootpiece += amount;
    }

    public void absorbPhosphorus(float amount)
    {
        phosphorusInRootpiece += amount;
    }

    public void absorbNitrogen(float amount)
    {
        nitrogenInRootpiece += amount;
    }

    public void absorbCalcium(float amount)
    {
        calciumInRootpiece += amount;
    }

    public void absorbPotassium(float amount)
    {
        potassiumInRootpiece += amount;
    }

    
}

