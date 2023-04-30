using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthStats : MonoBehaviour
{
    public float waterInTile = 30f;
    public float phosphorusInTile = 7f;
    public float nitrogenInTile = 15f;
    public float calciumInTile = 5f;
    public float potassiumInTile = 3f;


    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.position.y > 0)
        {
            phosphorusInTile = Random.Range(20f, 50f);
            nitrogenInTile = Random.Range(30f, 80f);
        } else
            {
            phosphorusInTile = Random.Range(1f, 20f);
            nitrogenInTile = Random.Range(3f, 50f);
        }

        waterInTile = Random.Range(1f, 20f);
        calciumInTile = Random.Range(3f, 10f);
        potassiumInTile = Random.Range(3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.GetComponent<EarthStats>())
            {
                print("Touching");
            
        }

       
    }

}
