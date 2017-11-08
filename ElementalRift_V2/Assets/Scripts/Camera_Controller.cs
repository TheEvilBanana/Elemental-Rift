using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

   [SerializeField]
    private Transform PlayerTransform;
    [SerializeField]
    private Transform PivotTransform;

    private float moveSpeed = 1f;                        //how fast the camera will keep up with the player's position.
    private float turnSpeed = 1.5f;                      //How fast will the camera rotate from the user input.
    [SerializeField]
    private float turnSmoothing = 0.0f;                 // How much smoothing to apply to the turn input, to reduce mouse-turn jerkiness
    [SerializeField]
    private float tiltMax = 75f;                       // The maximum value of the x axis rotation of the pivot.
    [SerializeField]
    private float tiltMin = 45f;                       // The minimum value of the x axis rotation of the pivot.
    private bool lockCursor = false;                   //Whether the cursor should be hidden and locked
    [SerializeField]
    private bool verticalAutoReturn = false;

    private float lookAngle;                            //camera's y axis rotation;
    private float tiltAngle;                            // The pivot's x axis rotation.
    private const float lookDistance = 100f;            // How far in front of the pivot the character's look target is.
    private Vector3 PivotEuler;
    private Quaternion TransformTargetRot;
    private Quaternion PivotTargetRot;

    private void Awake()
    {
        //Lock or unlock the cursor
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;

        PivotEuler = PivotTransform.rotation.eulerAngles;

        //Get the local rotation for the pivot and the camera gameobject
        PivotTargetRot = PivotTransform.localRotation;
        TransformTargetRot = transform.localRotation;

    }

    void Start ()
    {

        //Find the target player transform
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = playerObj.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleRotationMovement();
        if(lockCursor && Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !lockCursor;
        }

	}

    private void OnDisable()
    {
        //On escape make the cursor visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LateUpdate()
    {
        //Find the target player transform
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = playerObj.transform;

        FollowTarget();
    }



    private void FollowTarget()
    {
        if (PlayerTransform == null)
            return;

        transform.position = Vector3.Lerp(transform.position, PlayerTransform.position, Time.deltaTime * moveSpeed);
    }

    private void HandleRotationMovement()
    {
        //Read the user input
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");

        // Adjust the look angle by an amount proportional to the turn speed and horizontal input.
        lookAngle += x * turnSpeed;

        //ROtate the camera around the Y axis
        TransformTargetRot = Quaternion.Euler(0.0f, lookAngle, 0.0f);

        if (verticalAutoReturn)
        {
            // For tilt input, we need to behave differently depending on whether we're using mouse or touch input:
            // on mobile, vertical input is directly mapped to tilt value, so it springs back automatically when the look input is released
            // we have to test whether above or below zero because we want to auto-return to zero even if min and max are not symmetrical.
            tiltAngle = y > 0 ? Mathf.Lerp(0, -tiltMin, y) : Mathf.Lerp(0, tiltMax, -y);
        }
        else
        {
            // we adjust the current angle based on Y mouse input and turn speed
            tiltAngle -= y * turnSpeed;
            // and make sure the new value is within the tilt range
            tiltAngle = Mathf.Clamp(tiltAngle, -tiltMin, tiltMax);
        }

        // Tilt input around X is applied to the pivot (the child of this object)
        PivotTargetRot = Quaternion.Euler(tiltAngle, PivotEuler.y, PivotEuler.z);

        if (turnSmoothing > 0)
        {
            PivotTransform.localRotation = Quaternion.Slerp(PivotTransform.localRotation, PivotTargetRot, turnSmoothing * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, TransformTargetRot, turnSmoothing * Time.deltaTime);
        }
        else
        {
            PivotTransform.localRotation = PivotTargetRot;
            transform.localRotation = TransformTargetRot;
        }
    }

}
