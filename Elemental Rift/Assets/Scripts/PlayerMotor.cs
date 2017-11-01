using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor Instance;

    public float MoveSpeed = 10f;

    public Vector3 MoveVector { get; set; }
	
	void Awake ()
    {
        Instance = this;
	}
	
	
	public void UpdateMotor ()
    {
        SnapAlignCharacterWithCamera();
        ProcessMotion();
	}

    void ProcessMotion()
    {
        //Transform MoveVector to WorldSpace
        MoveVector = transform.TransformDirection(MoveVector);

        //Normalize MoveVector if Magnitude > 1
        if (MoveVector.magnitude > 1)
            MoveVector = Vector3.Normalize(MoveVector);

        //Multiple MoveVEctor by MoveSpeed
        MoveVector *= MoveSpeed;

        //Multiply MoveVEctor by deltaTime
        MoveVector *= Time.deltaTime;

        //Move the Character in World Space
        PlayerController.CharacterController.Move(MoveVector);
    }

    void SnapAlignCharacterWithCamera()
    {
        if(MoveVector.x!=0 || MoveVector.z!=0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
