using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

    // Use this for initialization
    //public ParticleSystem fissureAttack;
    
    //public Transform playerTransform;

    public GameObject fissure;
    public GameObject knockCollider;

    private GameObject fis;
    private GameObject colliderObj;

    public float fireRate = 1.5f;
    private float nextFire = 0.0f;

    private Transform transform;
    
    void Start () {
        
        transform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Q) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //fissureAttack.transform.position = playerTransform.position + playerTransform.forward * 5;
            // fissureAttack.Play();
            fis = (GameObject) Instantiate(fissure, transform.position, transform.rotation);
            colliderObj = (GameObject)Instantiate(knockCollider, transform.position, transform.rotation);
        }
       Destroy(colliderObj, 1);
       Destroy(fis, 1);
	}
}
