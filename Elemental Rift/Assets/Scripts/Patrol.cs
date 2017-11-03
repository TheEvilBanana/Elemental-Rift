using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {


    public Transform target1;
    public Transform target2;

    UnityEngine.AI.NavMeshAgent agent;


	// Use this for initialization
	void Start () {
        if (gameObject != null)
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.SetDestination(target1.position);
        }
    }
	
	// Update is called once per frame
	void Update () {


     

		
	}

        void OnCollisionEnter(Collision collision)
    {
        if (gameObject != null)
        {
            if (collision.gameObject.tag == "AIPatrolTarget1")
            {
                agent.SetDestination(target2.position);

            }

            if (collision.gameObject.tag == "AIPatrolTarget2")
            {
                agent.SetDestination(target1.position);
            }

        }
    }

}
