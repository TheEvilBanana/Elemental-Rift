using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCloud : MonoBehaviour {

    public float liftSpeed = 2.0f;
    public float streamSpeed = 20.0f;
    public float liftDistance = 5.0f;




    int upFlag;
    int Water_Door1_up;
    int Water_Door2_up;
    int Water_Door3_up;

    float startPositionY;
    float destinationPositionY;

    private bool Water_Door1_Move=false;
    private bool Water_Door2_Move=false;
    private bool Water_Door3_Move=false;

    public Transform Water_Stream1;
    public Transform Water_Stream2;
    public Transform Water_Stream3;

    public GameObject WaterFall;
    public GameObject AshOfWater;


    float Water_Stream1_DestinationPositionZ;
    float Water_Stream2_DestinationPositionZ;
    float Water_Stream3_DestinationPositionX;

    public GameObject waterButton1;
    public GameObject waterButton2;

    void Start()
    {
     
        upFlag = 0;
        Water_Door1_up = 0;
        Water_Door2_up = 0;
        Water_Door3_up = 0;


        Water_Stream1_DestinationPositionZ = 143.5f;
        Water_Stream2_DestinationPositionZ = 1.2f;
        Water_Stream3_DestinationPositionX = 184.0f;
    }

    void Update()
    {
        CheckDoor();
        if (upFlag == 1 && IsReachedtoDestination())
        {

            transform.Translate(Vector3.forward * Time.deltaTime * liftSpeed);
        }


        if (Water_Door1_Move == true)
        {
            Water_Stream1.Translate(-Vector3.forward * Time.deltaTime * streamSpeed);
        }

        if (Water_Stream1.transform.position.z < Water_Stream1_DestinationPositionZ)
        {
            Water_Door1_Move = false;
        }



        if (Water_Door2_Move == true)
        {
            Water_Stream2.Translate(Vector3.forward * Time.deltaTime * streamSpeed);
        }

        if (Water_Stream2.transform.position.z > Water_Stream2_DestinationPositionZ)
        {
            Water_Door2_Move = false;
        }

 

        if ((Water_Stream1.transform.position.z < Water_Stream1_DestinationPositionZ) && (Water_Stream2.transform.position.z > Water_Stream2_DestinationPositionZ))
        {
            if (Water_Stream3.transform.position.x > Water_Stream3_DestinationPositionX)
            {
                Water_Stream3.Translate(-Vector3.right * Time.deltaTime * streamSpeed);
            }


        }

    }

    void CheckDoor()
    {
        if (!waterButton1.activeInHierarchy && !waterButton2.activeInHierarchy)
        {
            if (upFlag != 1)
            {
                // Debug.Log("Clicked");
                upFlag = 1;
                //      GetComponent<Rigidbody>().useGravity = false;
                startPositionY = transform.position.y;
                destinationPositionY = startPositionY + liftDistance;
            }


            if (gameObject.tag == "Water_Door1" && Water_Door1_up == 0)
            {
                if (Water_Stream1.transform.position.z > Water_Stream1_DestinationPositionZ)
                {
                    Water_Door1_Move = true;
                }
                else
                {

                    Water_Door1_Move = false;
                    Water_Door1_up = 1;
                }
            }



            if (gameObject.tag == "Water_Door2" && Water_Door2_up == 0)
            {
                if (Water_Stream2.transform.position.z < Water_Stream2_DestinationPositionZ)
                {
                    Water_Door2_Move = true;
                }
                else
                {

                    Water_Door2_Move = false;
                    Water_Door2_up = 1;
                }
            }


            if (gameObject.tag == "Water_Door3")
            {
                WaterFall.SetActive(true);
                AshOfWater.SetActive(true);
            }

        }
    }

    private void OnMouseDown()
    {
        if (upFlag != 1)
        {
            // Debug.Log("Clicked");
            upFlag = 1;
            //      GetComponent<Rigidbody>().useGravity = false;
            startPositionY = transform.position.y;
            destinationPositionY = startPositionY + liftDistance;
        }


        if (gameObject.tag == "Water_Door1" && Water_Door1_up == 0)
        {
            if (Water_Stream1.transform.position.z > Water_Stream1_DestinationPositionZ)
            {
                Water_Door1_Move = true;
            }
            else
            {
                
                Water_Door1_Move = false;
                Water_Door1_up = 1;
            }
        }



        if (gameObject.tag == "Water_Door2" && Water_Door2_up == 0)
        {
            if (Water_Stream2.transform.position.z < Water_Stream2_DestinationPositionZ)
            {
                Water_Door2_Move = true;
            }
            else
            {

                Water_Door2_Move = false;
                Water_Door2_up = 1;
            }
        }


        if (gameObject.tag == "Water_Door3")
        {
            WaterFall.SetActive(true);
            AshOfWater.SetActive(true);
        }
        



        }




    bool IsReachedtoDestination()
    {
        if (transform.position.y < destinationPositionY)
        {

            return true;
        }
        else
        {
           // upFlag = 0;
        //    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            return false;

        }
    }



}
