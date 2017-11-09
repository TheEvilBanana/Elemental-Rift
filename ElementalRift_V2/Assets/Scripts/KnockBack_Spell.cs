using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack_Spell : MonoBehaviour {
    [SerializeField]
    private ParticleSystem[] knockBackParticleSystem;

    private GameObject Player;
    
	void Start ()
    {
        knockBackParticleSystem = gameObject.GetComponentsInChildren<ParticleSystem>();
        Player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E))
        {
            foreach(ParticleSystem childParticleSystem in knockBackParticleSystem)
            {
                childParticleSystem.Play();                
            }

           
        }
	}
}
