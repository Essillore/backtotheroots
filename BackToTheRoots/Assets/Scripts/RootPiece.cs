using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPiece : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridPosition;
    private Vector2Int tempVector2;
    public EarthStats earthstats;
    public GameObject motherTree;
    public MotherTree motherTreeScript;

    private float waterInRootpiece = 0f;
    private float phosphorusInRootpiece = 0f;
    private float nitrogenInRootpiece = 0f;
    private float calciumInRootpiece = 0f;
    private float potassiumInRootpiece = 0f;

    public Vector2 vectorToMotherTree;
    public Vector2Int vToMotherTree;
    public float distanceToMotherTree = 1f;

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

        motherTreeScript = motherTree.GetComponent<MotherTree>();

        StartCoroutine(AbsorbRatio(1f));

        vectorToMotherTree = gameObject.transform.position - motherTree.transform.position;
        vToMotherTree = Vector2Int.CeilToInt(vectorToMotherTree);
        distanceToMotherTree = vToMotherTree.magnitude;

        StartCoroutine(SendNutrientsToMotherRatio(distanceToMotherTree));

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public IEnumerator SendNutrientsToMotherRatio(float howOften)
    {
            float amountToSend = 0.1f;
            for (int i = 0; i <= 120; i +=1)
            {
            yield return new WaitForSeconds(howOften);
            SendNutrientsToMotherTree(amountToSend);
            print("Sent nutrients" + amountToSend);
        }
        yield break;
    }

    public IEnumerator AbsorbRatio(float howOften)
    {
        int upto = 120;
        if (earthstats.phosphorusInTile > 1)
        {
            for (int i = 0; i <= upto; i += 1)
            {
                yield return new WaitForSeconds(howOften);
                RootAbsorbsNutrients();
            }
        } else
        {
            yield break;
        }
       
        
    }

    public void SendNutrientsToMotherTree(float amount)
    {
        if (waterInRootpiece>0)
        {
            waterInRootpiece -= amount;
            motherTreeScript.waterInTree += amount;
        }
        if (phosphorusInRootpiece > 0)
        {
            phosphorusInRootpiece -= amount;
            motherTreeScript.phosphorusInTree += amount;
        }
        if (nitrogenInRootpiece > 0)
        {
            nitrogenInRootpiece -= amount;
            motherTreeScript.nitrogenInTree += amount;
        }
        if (calciumInRootpiece > 0)
        {
            calciumInRootpiece -= amount;
            motherTreeScript.calciumInTree += amount;
        }
        if (potassiumInRootpiece > 0)
        {
            potassiumInRootpiece -= amount;
            motherTreeScript.potassiumInTree += amount;
        }
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

