using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChar : MonoBehaviour {


    public float turnSpeed = 10.0f;
    public float moveSpeed = 10.0f;
    public float mouseTurnMultiplier = 1.0f;

    private float x;
    private float z;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



        // x is used for the x axis.  set it to zero so it doesn't automatically rotate
        x = 0;

        // check to see if the W or S key is being pressed.  
        z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Move the character forwards or backwards
        transform.Translate(0, 0, z);

        // Check to see if the A or S key are being pressed
        if (Input.GetAxis("Horizontal") !=0)
        {
            // Get the A or S key (-1 or 1)
            x = Input.GetAxis("Horizontal");
        }

        // Check to see if the right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            // Get the difference in horizontal mouse movement
            x = Input.GetAxis("Mouse X") * turnSpeed * mouseTurnMultiplier;
        }

        // rotate the character based on the x value
        transform.Rotate(0, x, 0);


/*  Test movement

        // Check to see if the A or S key are being pressed
        if (Input.GetAxis("Horizontal") !=0)
        {
            // Get the A or S key (-1 or 1)
            x = Input.GetAxis("Horizontal");
        }

        // Check to see if the right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            // Get the difference in horizontal mouse movement
            x = Input.GetAxis("Mouse X") * turnSpeed * mouseTurnMultiplier;
        }

		
		*/
		



    }
}
