using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoBlast : MonoBehaviour {

    public GameObject explosion;
    public GameObject blastCollider;

    public float blastTime = 3.0f;
    float startTime;
    float checkTime;

    private GameObject explosionObject;
    private GameObject colliderObj;
    private Transform transform;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        transform = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {

        
        checkTime = Time.time - startTime;
        if(checkTime >= blastTime)
        {
            colliderObj = (GameObject) Instantiate(blastCollider, transform.position, transform.rotation);
            explosionObject = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosionObject, 1);
            Destroy(colliderObj, 1);
            Destroy(gameObject);
        }
	}

    
}
