using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    // Use this for initialization
    public int EnemyMaxHealth = 100;
    public int EnemyCurrentHealth = 100;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "Spawns" && gameObject.tag !="BigEnemy" )
        {
            Destroy(gameObject);
        }




    }





}
