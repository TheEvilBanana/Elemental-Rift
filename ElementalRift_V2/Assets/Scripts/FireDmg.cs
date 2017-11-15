using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDmg : MonoBehaviour {

    public float radius = 2.0f;

    private Transform transform;
    private Vector3 location;
    private Collider[] objectsInRange;
    // Use this for initialization
    void Start () {
        transform = GetComponent<Transform>();
       
        location = transform.position;
      

        objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
            if (col.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        
	}

}
