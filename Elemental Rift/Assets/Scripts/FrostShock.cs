using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostShock : MonoBehaviour {


    UnityEngine.AI.NavMeshAgent agent;
    AudioSource AudioFreezeEffect;

    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        AudioFreezeEffect = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseOver()
    {
        // Debug.Log("Clicked");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            agent.Stop();
            //agent.Resume();                           // Use this to unfreeze and continue nav mesh movement
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
             Debug.Log("Freeze!");
            AudioFreezeEffect.Play();
        }

    }


 


}
