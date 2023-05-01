using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMotherTree : MonoBehaviour
{
    public Slider water;
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
    }

}
