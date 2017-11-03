using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPowerManager : MonoBehaviour {

    public GameObject volcanoSpawner;
    public GameObject sunStrikeSpawner;
    public GameObject knockBackSpawner;
    public GameObject miniSpawnSpawner;

    public Material playerGround;
    public Material playerFire;
    public Material playerWater;

    private Renderer matComponent;
    private int attackType = 0;                                             // 0:Ground, 1:Fire, 2:Water
	// Use this for initialization
	void Start () {

        matComponent = gameObject.GetComponent<Renderer>();


        volcanoSpawner.GetComponent<VolcanoSpawn>().enabled = false;
        sunStrikeSpawner.GetComponent<SunStrikeSpawn>().enabled = false;
        knockBackSpawner.GetComponent<KnockBack>().enabled = false;
        miniSpawnSpawner.GetComponent<SpawnMinis>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (attackType == 0)
        {

            matComponent.material = playerGround;

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

            knockBackSpawner.GetComponent<KnockBack>().enabled = true;
            miniSpawnSpawner.GetComponent<SpawnMinis>().enabled = true;
        }

        if (attackType == 1)
        {
            matComponent.material = playerFire;

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

            knockBackSpawner.GetComponent<KnockBack>().enabled = false;
            miniSpawnSpawner.GetComponent<SpawnMinis>().enabled = false;
        }

        if (attackType == 2)
        {
            matComponent.material = playerWater;

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

            knockBackSpawner.GetComponent<KnockBack>().enabled = false;
            miniSpawnSpawner.GetComponent<SpawnMinis>().enabled = false;
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
