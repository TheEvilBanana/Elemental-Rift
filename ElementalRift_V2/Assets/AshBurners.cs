using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshBurners : MonoBehaviour {


    public GameObject WaterAsh;
    public GameObject FireAsh;
    public GameObject EarthAsh;


   
    void Start () {
		

	}


	void Update () {
		
        if(StaticScriptGlobalVariables.AshOfWater == 1 && !WaterAsh.activeInHierarchy)
        {
            WaterAsh.SetActive(true);
        }


        if (StaticScriptGlobalVariables.AshOfFire == 1 && !FireAsh.activeInHierarchy)
        {
            FireAsh.SetActive(true);
        }


        if (StaticScriptGlobalVariables.AshOfEarth == 1 && !EarthAsh.activeInHierarchy)
        {
            EarthAsh.SetActive(true);
        }


    }
}
