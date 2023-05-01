using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class UIMotherTree : MonoBehaviour
{
    public MotherTree motherTree;

    public Gradient gradient;
    public Image fill;

    public Slider slider;

    public void SetSlider(int sliderUpdate)
    {
        slider.value = sliderUpdate;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
   

}
