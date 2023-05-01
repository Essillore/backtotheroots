using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIDisplayEarthStats : MonoBehaviour
{
    public float waterInTile = 30f;
    public float phosphorusInTile = 7f;
    public float nitrogenInTile = 15f;
    public float calciumInTile = 5f;
    public float potassiumInTile = 3f;

    public TMP_Text earthStats;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        earthStats.text= "\n" + waterInTile.ToString() + "\n" + phosphorusInTile.ToString() + "\n" +
            nitrogenInTile.ToString() + "\n" + calciumInTile.ToString() + "\n" +
            potassiumInTile.ToString();
        
    }
}
