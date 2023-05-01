using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIDisplayEarthStats : MonoBehaviour
{
    public GameObject mouseHolder;
    public MouseMovement mouseMovement;
    public Vector2Int gridPosition;
    public GameObject grid;
    public GridManager gridManager;
    public GameObject earthObject;
    public float waterInTile = 30f;
    public float phosphorusInTile = 7f;
    public float nitrogenInTile = 15f;
    public float calciumInTile = 5f;
    public float potassiumInTile = 3f;


    public TMP_Text tmp_text;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = grid.GetComponent<GridManager>();
        mouseMovement = mouseHolder.GetComponent<MouseMovement>();
        gridPosition = mouseMovement.GetGridPosition();


    }

    // Update is called once per frame
    void Update()
    {   
        gridPosition = mouseMovement.GetGridPosition();
        
        earthObject = gridManager.GetEarthObject(gridPosition);
        if (earthObject != null)
        {
            tmp_text.text = earthObject.GetComponent<EarthStats>().GetNutrientLevels();
        }

  
    }
}
