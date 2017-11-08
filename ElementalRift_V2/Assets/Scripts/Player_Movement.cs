using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Use this for initialization
    public static CharacterController PlayerCharacterController;
    private float moveSpeed = 10f;

    public Vector3 MoveVector { get; set; }

    private void Awake()
    {
        PlayerCharacterController = GetComponent<CharacterController>() as CharacterController;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();

        SnapAlignCharacterWithCamera();

        ProcessMotion();
	}

    void GetInput()
    {
        var deadZone = 0.1f;

        MoveVector = Vector3.zero;

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < deadZone)
            MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < deadZone)
            MoveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }

    void SnapAlignCharacterWithCamera()
    {
        if(MoveVector.x!=0 || MoveVector.z!=0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    void ProcessMotion()
    {
        //Transform MoveVector to WorldSpace
        MoveVector = transform.TransformDirection(MoveVector);

        //Normalze MoveVector if Magnitude >1
        if (MoveVector.magnitude > 1)
            MoveVector = Vector3.Normalize(MoveVector);

        //Multiply MoveVector by moveSpeed
        MoveVector *= moveSpeed;

        //Multiply MoveVector by deltaTime
        MoveVector *= Time.deltaTime;

        //Move the character in world space
        PlayerCharacterController.Move(MoveVector);
    }
}
