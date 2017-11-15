using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera camera;
    public GameObject freezeEffect;
    public GameObject knockBackEffect;

    void Start()
    {

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
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform);
            Enemy target = hit.transform.GetComponent<Enemy>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(freezeEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    //For the knockback attack
    void KnockBack()
    {
        GameObject knock = Instantiate(knockBackEffect, camera.transform.position, camera.transform.rotation);
        Destroy(knock, 2f);
    }
}