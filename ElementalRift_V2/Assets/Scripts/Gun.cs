using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    public float range = 100f;
    public float spawnDistance;

    public Camera camera;
    public GameObject target;
    private GameObject Player;
    public GameObject freezeEffect;
    public GameObject knockBackEffect;
    public GameObject knockBackCollider;

    private Vector3 rayDir;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        rayDir = target.transform.position - camera.transform.position;
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
        if (Physics.Raycast(camera.transform.position, rayDir, out hit, range))
        {
            Debug.Log(hit.transform);
            //Enemy target = hit.transform.GetComponent<Enemy>();
            
            if (hit.transform.tag == "Enemy")
            {
                Enemy target = hit.transform.GetComponent<Enemy>();
                target.TakeDamage();
                GameObject impactGO = Instantiate(freezeEffect, hit.point, Quaternion.identity);
                Destroy(impactGO, 2f);
            }

            //GameObject impactGO = Instantiate(freezeEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //GameObject impactGO = Instantiate(freezeEffect, hit.point, Quaternion.identity);
            //Destroy(impactGO, 2f);
        }
    }

    //For the knockback attack
    void KnockBack()
    {

        Vector3 playerPos = Player.transform.position;
        Vector3 playerDirection = Player.transform.forward;
        spawnDistance = 8.0f;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        GameObject knock = Instantiate(knockBackEffect, spawnPos, Player.transform.rotation);
        Destroy(knock, 2f);
    }
}