using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPowerManager : MonoBehaviour {

    public GameObject volcanoSpawner;
    public GameObject sunStrikeSpawner;

    private int attackType = 0;                                             // 0:Ground, 1:Fire, 2:Water
	// Use this for initialization
	void Start () {
        volcanoSpawner.GetComponent<VolcanoSpawn>().enabled = false;
        sunStrikeSpawner.GetComponent<SunStrikeSpawn>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (attackType == 0)
        {
            volcanoSpawner.GetComponent<VolcanoSpawn>().enabled = false;
            sunStrikeSpawner.GetComponent<SunStrikeSpawn>().enabled = false;

            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if(enemy.GetComponent<FrostShock>() != null)
                {
                    enemy.GetComponent<FrostShock>().enabled = false;
                }
            }

            foreach(GameObject floatingObject in GameObject.FindGameObjectsWithTag("FloatingObject"))
            {
                if(floatingObject.GetComponent<WaterCloud>() != null)
                {
                    floatingObject.GetComponent<WaterCloud>().enabled = false;
                }
            }
        }

        if (attackType == 1)
        {
            volcanoSpawner.GetComponent<VolcanoSpawn>().enabled = true;
            sunStrikeSpawner.GetComponent<SunStrikeSpawn>().enabled = true;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.GetComponent<FrostShock>() != null)
                {
                    enemy.GetComponent<FrostShock>().enabled = false;
                }
            }

            foreach (GameObject floatingObject in GameObject.FindGameObjectsWithTag("FloatingObject"))
            {
                if (floatingObject.GetComponent<WaterCloud>() != null)
                {
                    floatingObject.GetComponent<WaterCloud>().enabled = false;
                }
            }
        }

        if (attackType == 2)
        {
            volcanoSpawner.GetComponent<VolcanoSpawn>().enabled = false;
            sunStrikeSpawner.GetComponent<SunStrikeSpawn>().enabled = false;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.GetComponent<FrostShock>() != null)
                {
                    enemy.GetComponent<FrostShock>().enabled = true;
                }
            }

            foreach (GameObject floatingObject in GameObject.FindGameObjectsWithTag("FloatingObject"))
            {
                if (floatingObject.GetComponent<WaterCloud>() != null)
                {
                    floatingObject.GetComponent<WaterCloud>().enabled = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Light")
        {
            attackType = 1;
        }

        if (other.gameObject.tag == "Water")
        {
            attackType = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            attackType = 0;
        }

        if (other.gameObject.tag == "Water")
        {
            attackType = 0;
        }
    }
}
