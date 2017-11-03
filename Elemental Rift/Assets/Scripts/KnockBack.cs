using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

    // Use this for initialization
    public ParticleSystem fissureAttack;
    
    public Transform playerTransform;

   

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.C))
        {
            fissureAttack.transform.position = playerTransform.position + playerTransform.forward * 5;
            fissureAttack.Play();
            
        }
		
	}
}
