using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunStrike : MonoBehaviour {
    
    public GameObject strikeCollider;

    public float strikeTime = 2.5f;
    float startTime;
    float checkTime;

    private GameObject explosionObject;
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
        if (checkTime >= strikeTime)
        {
            colliderObj = (GameObject)Instantiate(strikeCollider, transform.position, transform.rotation);
            Destroy(colliderObj, 1);
            Destroy(gameObject);
        }
    }
}
