using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class UIMotherTree : MonoBehaviour
{
    public MotherTree motherTree;

    public Slider water;
    public Gradient gradient;
    public Image fill; 

    public Slider sugar;
    public Slider phosphorus;
    public Slider nitrogen;
    public Slider calcium;
    public Slider potassium;


    public void SetMaxWater(int maxWater)
    {
        water.maxValue = maxWater; 
    }

    public void SetWater(int waterUpdate)
    {
        water.value = waterUpdate;
        fill.color = gradient.Evaluate(1f);
    }

}
