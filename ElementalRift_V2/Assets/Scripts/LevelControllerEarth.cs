using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerEarth : MonoBehaviour {


   // public bool EarthAshCollected = false;
    public GameObject ReturnPortal;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            ReturnPortal.SetActive(true);
            StaticScriptGlobalVariables.AshOfEarth = 1;
            gameObject.SetActive(false);
        }
    }

}
