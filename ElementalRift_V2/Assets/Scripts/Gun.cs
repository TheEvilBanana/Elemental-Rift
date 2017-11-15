using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    public float range = 100f;

    public Camera camera;
    private GameObject Player;
    public GameObject freezeEffect;
    public GameObject knockBackEffect;
    public GameObject knockBackCollider;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        //For the left mouse click play - the freeze attack
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        //For Alpha1 playe the ground - knockback attack
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            KnockBack();
        }
    }

    //For the freeze attack
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform);
            Enemy target = hit.transform.GetComponent<Enemy>();

            if (target != null)
            {
                target.TakeDamage();
            }

            GameObject impactGO = Instantiate(freezeEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    //For the knockback attack
    void KnockBack()
    {
        GameObject knock = Instantiate(knockBackEffect, Player.transform.position, Player.transform.rotation);
       // GameObject collider = Instantiate(knockBackCollider, Player.transform.position, Player.transform.rotation);
        Destroy(knock, 2f);
        //Destroy(collider, 2f);
    }
}