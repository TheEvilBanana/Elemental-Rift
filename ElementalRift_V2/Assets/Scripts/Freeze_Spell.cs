using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_Spell : MonoBehaviour {

    // Use this for initialization
    [SerializeField]

    private ParticleSystem[] freezePartcileSystem;

    private Vector3 mousePos;
 

	void Start ()
    {

        freezePartcileSystem = gameObject.GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        { 
            foreach (ParticleSystem childParticleSystem in freezePartcileSystem)
            {
                childParticleSystem.Play();
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(mousePos);
                childParticleSystem.transform.position = mousePos;    
                //Instantiate(childParticleSystem, new Vector3(0, 1, 0), Quaternion.identity);    
            }
        }
	}

    
}
