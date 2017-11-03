using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoSpawn : MonoBehaviour {

    public GameObject volcano;

    public float fireRate = 1.5f;
    private float nextFire = 0.0f;

    private Transform transform;
    //private Vector3 spawnPosition;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        //spawnPosition = transform.forward * 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(volcano, transform.position, transform.rotation);
        }
	}
}
