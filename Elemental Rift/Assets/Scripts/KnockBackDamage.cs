using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackDamage : MonoBehaviour {

    public GameObject knockCollider;

    public float knockBack = 2.0f;
    float startTime;
    float checkTime;

    private GameObject colliderObj;
    private Transform transform;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        checkTime = Time.time - startTime;

        colliderObj = (GameObject)Instantiate(knockCollider, transform.position, transform.rotation);
        Destroy(colliderObj, 1);

        if (checkTime >= knockBack)
        {
            Destroy(gameObject);
        }
    }
}
