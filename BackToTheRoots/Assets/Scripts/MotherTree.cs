using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherTree : MonoBehaviour
{
    
    public float waterInTree = 30f;
    public float sugarInTree = 100f;
    public float phosphorusInTree = 7f;
    public float nitrogenInTree = 15f;
    public float calciumInTree = 5f;
    public float potassiumInTree = 3f;

    public UIMotherTree SliderforWater;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateUI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UpdateUI()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            SliderforWater.SetWater((int)waterInTree);
        }
    }

}
