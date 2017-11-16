using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackCollider : MonoBehaviour {

    // Use this for initialization
    private GameObject knockBackObject;
    public GameObject knockColliderObject;


	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject colliderObj = (GameObject)Instantiate(knockColliderObject, transform.position, transform.rotation);
        Destroy(colliderObj, 5.0f);   
    }
}
