using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSpawnMovement : MonoBehaviour
{

    public GameObject playerObject;


    public Transform MiniSpawn;
    private int damage = 10;

    private void Start()
    {
        
    }

    private void Awake()
    {
        Destroy(gameObject, 10.0f);
    }

    private void Update()
    {
        MiniSpawn.Translate(playerObject.transform.forward * 0.5f * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().EnemyCurrentHealth -= damage;
            Destroy(gameObject);
        }
         if(collision.gameObject.name == "Environment")
        {
            Destroy(gameObject);
        }
    }
}