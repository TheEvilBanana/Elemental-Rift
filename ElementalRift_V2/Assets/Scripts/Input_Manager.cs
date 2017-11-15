using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour {
    public GameObject volcano;
    //public GameObject volcanoSpawner;

    public GameObject sunStrike;
    //public GameObject sunStrikeSpawner;

    //private Transform volcanoTransform;
    //private Transform sunStrikeTransform;

    public Camera camera;
    public GameObject CrossHair;
    private Vector3 crossHairPos;

    Resource_Manager resource_Manager;
    //CrossHair crossHairScript;

    private bool sunStrikeFlag = false;
    private bool volcanoFlag = false;
    // Use this for initialization
    void Start()
    {
        //volcanoTransform = volcanoSpawner.GetComponent<Transform>();
        //sunStrikeTransform = sunStrikeSpawner.GetComponent<Transform>();
        resource_Manager = gameObject.GetComponent<Resource_Manager>();
       // crossHairScript = CrossHair.GetComponent<CrossHair>();


    }

    // Update is called once per frame
    void Update()
    {
        //crossHairPos = crossHairScript.crossHairScreenpos;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (resource_Manager.fireRune >= 2)
            {
                //ppc.fireRune -= 2;
                //Instantiate(volcano, volcanoTransform.position, volcanoTransform.rotation);
                volcanoFlag = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (resource_Manager.fireRune >= 3)
            {
                //ppc.fireRune -= 3;
                //Instantiate(sunStrike, sunStrikeTransform.position, sunStrikeTransform.rotation);
                sunStrikeFlag = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && sunStrikeFlag == true)
        {
            sunStrikeFlag = false;
            resource_Manager.fireRune -= 3;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {
                Instantiate(sunStrike, hit.point + Vector3.up * 0.2f, Quaternion.identity);
            }

        }

        if (Input.GetMouseButtonDown(0) && volcanoFlag == true)
        {
            volcanoFlag = false;
            resource_Manager.fireRune -= 2;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(volcano, hit.point + Vector3.up * 2.5f, Quaternion.identity);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            sunStrikeFlag = false;
            volcanoFlag = false;
        }
    }
}
