using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerEarth1 : MonoBehaviour {


    public GameObject ReturnPortal;
    public float dropSpeed=1.0f;
    private bool isFalling;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(isFalling)
        {
            transform.Translate(-Vector3.up * Time.deltaTime * dropSpeed);
        }


	}



    //void OnTriggerEnter(Collider col)
    //{
       
    //    if (ReturnPortal.activeInHierarchy)
    //    {
    //        if (col.gameObject.tag == "Player")
    //        {
                
    //            isFalling = true;
               
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (ReturnPortal.activeInHierarchy)
        {
            if (collision.gameObject.tag == "Player")
            {

                isFalling = true;

            }
        }
    }

}
