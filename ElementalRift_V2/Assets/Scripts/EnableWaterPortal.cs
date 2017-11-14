using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWaterPortal : MonoBehaviour {

    public GameObject ReturnPortal;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
            ReturnPortal.SetActive(true);
        StaticScriptGlobalVariables.AshOfWater = 1;
        gameObject.SetActive(false);

    }


}
