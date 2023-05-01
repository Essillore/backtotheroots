using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MotherTree : MonoBehaviour
{
    
    public float waterInTree = 30f;
    public float sugarInTree = 100f;
    public float phosphorusInTree = 7f;
    public float nitrogenInTree = 15f;
    public float calciumInTree = 5f;
    public float potassiumInTree = 3f;

    public GameObject sliderforWater;
    public UIMotherTree UImothertree;

    // Start is called before the first frame update
    void Start()
    {
        UImothertree = sliderforWater.GetComponent<UIMotherTree>();
        StartCoroutine(UpdateUI());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UpdateUI()
    {
        for (int i = 0; i < 500; i++)
        {
            
            UImothertree.SetWater((int)waterInTree);
            print("set water to " + waterInTree);
            yield return new WaitForSeconds(1f);

        }
    }

}
