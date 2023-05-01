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
    public GameObject sliderforSugar;
    public GameObject sliderforPhosphorus;
    public GameObject sliderforNitrogen;
    public GameObject sliderforCalcium;
    public GameObject sliderforPotassium;


    private UIMotherTree waterUIslider;
    private UIMotherTree sugarUIslider;
    private UIMotherTree phosphorusUIslider;
    private UIMotherTree nitrogenUIslider;
    private UIMotherTree calciumUIslider;
    private UIMotherTree potassiumUIslider;

    // Start is called before the first frame update
    void Start()
    {
        waterUIslider = sliderforWater.GetComponent<UIMotherTree>();
        sugarUIslider = sliderforSugar.GetComponent<UIMotherTree>();
        phosphorusUIslider = sliderforPhosphorus.GetComponent<UIMotherTree>();
        nitrogenUIslider = sliderforNitrogen.GetComponent<UIMotherTree>();
        calciumUIslider = sliderforCalcium.GetComponent<UIMotherTree>();
        potassiumUIslider = sliderforPotassium.GetComponent<UIMotherTree>();

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

            waterUIslider.SetSlider((int)waterInTree);
            sugarUIslider.SetSlider((int)sugarInTree);
            phosphorusUIslider.SetSlider((int)phosphorusInTree);
            nitrogenUIslider.SetSlider((int)nitrogenInTree);
            calciumUIslider.SetSlider((int)calciumInTree);
            potassiumUIslider.SetSlider((int)potassiumInTree);

            print("set water to " + waterInTree);
            yield return new WaitForSeconds(1f);

        }
    }

}
