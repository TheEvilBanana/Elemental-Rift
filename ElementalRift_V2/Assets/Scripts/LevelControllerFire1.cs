using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerFire1 : MonoBehaviour {


  //  public bool FireAshCollected = false;
    public GameObject ReturnPortal;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            ReturnPortal.SetActive(true);
            StaticScriptGlobalVariables.AshOfFire = 1;
            gameObject.SetActive(false);
        }
           

    }



}
