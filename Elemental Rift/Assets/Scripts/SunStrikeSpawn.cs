using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunStrikeSpawn : MonoBehaviour {
    public GameObject sunStrike;

    public float fireRate = 1.5f;
    private float nextFire = 0.0f;

    private Transform transform;
    //private Vector3 spawnPosition;
    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
        //spawnPosition = transform.forward * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(sunStrike, transform.position, transform.rotation);
        }
    }
}
