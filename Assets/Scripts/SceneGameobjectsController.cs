using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGameobjectsController : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectsToHide;

    [SerializeField] bool changeGO; // TRUE drugs, False no drugs
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (changeGO)
            {
                changeGO = false;
            }
            else
            {
                changeGO = true;
            }
        }

        if (changeGO)
        {
            WithDrugs();
        }
        if (!changeGO)
        {
            WithoutDrugs();
        }
    }
    void WithoutDrugs() 
    {
        foreach (GameObject gth in gameObjectsToHide)
        {
            gth.SetActive(false);
        }
    }
    void WithDrugs()
    {
        foreach (GameObject gth in gameObjectsToHide)
        {
            gth.SetActive(true);
        }
    }
}
