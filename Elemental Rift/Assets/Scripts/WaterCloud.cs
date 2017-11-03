using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* If something is not working. For e.g. objects going through each other. Then check "Mass value" of Rigidbody component of all objects involved in the interaction.
 * Object having 0 mass allows other objects to pass through itself.  */





public class WaterCloud : MonoBehaviour {

    public float liftSpeed=2.0f;
    public float liftDistance=5.0f;


    int upFlag;

    float startPositionY;
    float destinationPositionY;

    public Color mouseOverColor;
    public Color mouseExitColor;




    void Start () {
      //  liftSpeed = 2.0f;
        upFlag = 0;
      //  liftDistance = 10.0f;
    }
	

	void Update () {
		if(upFlag==1 && IsReachedtoDestination())
        {
            //Debug.Log("moving");
            transform.Translate(Vector3.up * Time.deltaTime * liftSpeed);
        }
        else
        {
            // GetComponent<Rigidbody>().mass = 1;
        }
     //   if(upFlag==0)
     //   {
      //      GetComponent<Rigidbody>().mass = 1;
       // }
	}



    private void OnMouseDown()
    {
       // Debug.Log("Clicked");
        upFlag = 1;
        GetComponent<Rigidbody>().useGravity = false;
        startPositionY = transform.position.y;
        destinationPositionY = startPositionY + liftDistance;
    }

    bool IsReachedtoDestination()
    {
        if (transform.position.y < destinationPositionY)
        {
         
            return true;
        }
        else
        {
            upFlag = 0;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
      
            return false;
            
        }
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            if (upFlag == 1)
            {
                collision.gameObject.GetComponent<Rigidbody>().mass = 0;
            }
            if (upFlag == 0)
            {
                collision.gameObject.GetComponent<Rigidbody>().mass = 1;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().mass = 1;
    }



    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", mouseExitColor);
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

}
