using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpawner : MonoBehaviour
{
    // public GameObject gridManager;

    public GameObject earthSquare;

    private GridManager gridM;

    public GameObject motherTree;

    private void Awake()
    {
        int i = -14;    //13
        int j = -6;     //5
        for (i = -14; i < 14; i++)
        {
            Vector3 location = new Vector3(i, j, 0);

            Instantiate(earthSquare, location, Quaternion.identity, motherTree.transform);

            for (j = -6; j <= 5; j++)
            {
                location = new Vector3(i, j, 0);

                Instantiate(earthSquare, location, Quaternion.identity, motherTree.transform);
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
