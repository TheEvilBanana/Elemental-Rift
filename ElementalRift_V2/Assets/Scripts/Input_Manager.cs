using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour {
    public GameObject volcano;
    //public GameObject volcanoSpawner;

    public GameObject sunStrike;
    //public GameObject sunStrikeSpawner;
    public GameObject freezeEffect;
    public GameObject knockBackEffect;
    //private Transform volcanoTransform;
    //private Transform sunStrikeTransform;

    public Camera camera;
    public GameObject target;

    private Vector3 rayDir;

    Resource_Manager resource_Manager;
    //CrossHair crossHairScript;

    private bool sunStrikeFlag = false;
    private bool volcanoFlag = false;
    private bool freezeFlag = false;
    private bool knockBackFlag = false;
    // Use this for initialization
    void Start()
    {
        resource_Manager = gameObject.GetComponent<Resource_Manager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //crossHairPos = crossHairScript.crossHairScreenpos;
        rayDir = target.transform.position - camera.transform.position;

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (resource_Manager.fireRune >= 2)
            {
                //ppc.fireRune -= 2;
                //Instantiate(volcano, volcanoTransform.position, volcanoTransform.rotation);
                volcanoFlag = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            if (resource_Manager.fireRune >= 3)
            {
                //ppc.fireRune -= 3;
                //Instantiate(sunStrike, sunStrikeTransform.position, sunStrikeTransform.rotation);
                sunStrikeFlag = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(resource_Manager.waterRune >= 2)
            {
                freezeFlag = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (resource_Manager.earthRune >= 2)
            {
                resource_Manager.earthRune -= 2;
                GameObject knock = Instantiate(knockBackEffect, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(knock, 2f);
            }
        }

        if (Input.GetMouseButtonDown(0) && sunStrikeFlag == true)
        {
            sunStrikeFlag = false;
            resource_Manager.fireRune -= 3;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, rayDir, out hit))
            {
                Instantiate(sunStrike, hit.point + Vector3.up * 0.2f, Quaternion.identity);
            }

        }

        if (Input.GetMouseButtonDown(0) && volcanoFlag == true)
        {
            volcanoFlag = false;
            resource_Manager.fireRune -= 2;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, rayDir, out hit))
            {
                Instantiate(volcano, hit.point + Vector3.up * 2.5f, Quaternion.identity);
            }

        }

        if (Input.GetMouseButtonDown(0) && freezeFlag == true)
        {
            freezeFlag = false;
            resource_Manager.waterRune -= 2;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, rayDir, out hit))
            {
                if (hit.transform.tag == "Enemy")
                {
                    Enemy enemyHit = hit.transform.GetComponent<Enemy>();
                    enemyHit.TakeDamage();
                    GameObject impactGO = Instantiate(freezeEffect, hit.point, Quaternion.identity);
                    Destroy(impactGO, 2f);
                }
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            sunStrikeFlag = false;
            volcanoFlag = false;
            freezeFlag = false;
            knockBackFlag = false;
        }
    }
}
