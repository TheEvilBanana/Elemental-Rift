﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FissureDamage : MonoBehaviour {

    private Vector3 colRange;

    private Transform transform;
    private Vector3 location;
    private Collider[] objectsInRange;

    // Use this for initialization
    void Start () {
        colRange.x = 0.75f;
        colRange.y = 0.5f;
        colRange.z = 2.0f;

        transform = GetComponent<Transform>();

        location = transform.position;

        objectsInRange = Physics.OverlapBox(location, colRange);
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