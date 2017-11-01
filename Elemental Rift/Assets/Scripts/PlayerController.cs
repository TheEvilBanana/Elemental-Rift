using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static CharacterController CharacterController;
    public static PlayerController Instance;
	
	void Awake ()
    {
        CharacterController = GetComponent<CharacterController>() as CharacterController;
        Instance = this;
        CameraController.UseExistingOrCreateNewCamera();
	}
	
	void Update ()
    {
        if (Camera.main == null)
            return;

        //Take Player Inputs
        GetInput();

        //Forcing Update of PlayerMotor
        PlayerMotor.Instance.UpdateMotor();

	}


    void GetInput()
    {
        var deadZone = 0.1f;

        PlayerMotor.Instance.MoveVector = Vector3.zero;

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
            PlayerMotor.Instance.MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
            PlayerMotor.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal"),0,0);
    }
}
