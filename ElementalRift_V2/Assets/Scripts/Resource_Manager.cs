using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Manager : MonoBehaviour {

    public Material baseMaterial;
    public Material fireMaterial;
    public Material waterMaterial;

    //public GameObject go;

    public Text earthRunesCount;
    public Text fireRunesCount;
    public Text waterRunesCount;

    public float increasePerSecond = 1.0f;
    public float decreasePerSecond = 0.5f;

    public float earthRune = 0.0f;
    public float fireRune = 0.0f;
    public float waterRune = 0.0f;

    public float maxRunes = 5.0f;

    Renderer matComponent;

    private bool earthflag = true;
    private bool fireflag = false;
    private bool waterflag = false;

    private float startTime;
    private float checkTimer;

    
    // Use this for initialization
    void Start()
    {

        startTime = Time.time;
        matComponent = gameObject.GetComponent<Renderer>();
        matComponent.material = baseMaterial;
        
    }

    // Update is called once per frame
    void Update()
    {
        checkTimer += Time.deltaTime;
        if (checkTimer > 2.0f)
        {
            checkTimer = 0.0f;
            ManageRunes();
        }


        earthRunesCount.text = earthRune.ToString();
        fireRunesCount.text = fireRune.ToString();
        waterRunesCount.text = waterRune.ToString();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            print("Light");
            matComponent.material = fireMaterial;
            SetFireFlag();

        }

        if (other.gameObject.tag == "Water")
        {
            matComponent.material = waterMaterial;
            SetWaterFlag();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            print("LightExit");
            matComponent.material = baseMaterial;
            SetEarthFlag();
        }

        if (other.gameObject.tag == "Water")
        {

            matComponent.material = baseMaterial;
            SetEarthFlag();
        }
    }

    void SetEarthFlag()
    {
        earthflag = true;
        fireflag = false;
        waterflag = false;
    }

    void SetFireFlag()
    {
        earthflag = false;
        fireflag = true;
        waterflag = false;
    }

    void SetWaterFlag()
    {
        earthflag = false;
        fireflag = false;
        waterflag = true;
    }

    void ManageRunes()
    {
        if (earthflag == true && fireflag == false && waterflag == false)
        {
            if (earthRune < maxRunes)
            {
                earthRune += increasePerSecond;
            }
            if (fireRune > 0.0f)
            {
                fireRune -= decreasePerSecond;
            }
            if (waterRune > 0.0f)
            {
                waterRune -= decreasePerSecond;
            }

            return;
        }

        if (earthflag == false && fireflag == true && waterflag == false)
        {
            if (earthRune > 0.0f)
            {
                earthRune -= decreasePerSecond;
            }
            if (fireRune < maxRunes)
            {
                fireRune += increasePerSecond;
            }
            if (waterRune > 0.0f)
            {
                waterRune -= decreasePerSecond;
            }

            return;
        }

        if (earthflag == false && fireflag == false && waterflag == true)
        {
            if (earthRune > 0.0f)
            {
                earthRune -= decreasePerSecond;
            }
            if (fireRune > 0.0f)
            {
                fireRune -= decreasePerSecond;
            }
            if (waterRune < maxRunes)
            {
                waterRune += increasePerSecond;
            }

            return;
        }
    }
}
