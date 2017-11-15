using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    private CrossHair _Crosshair;
    private CrossHair Crosshair
    {
        get
        {
            if (_Crosshair == null)
                _Crosshair = GetComponentInChildren<CrossHair>();
            return _Crosshair;
        }
    }



    public float speed;
    public Vector2 Damping;
    public Vector2 Sensitivity;

    private Player_Movement localPlayer;
    Vector2 mouseInput;

    public GameObject cameraLookTarget;
    public GameObject RotateY;

    float rotationY = 0f;
    public float maxAngle;
    public float minAngle;

    private void Awake()
    {
        localPlayer = this;

    }

    private void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Vertical") * speed, Input.GetAxis("Horizontal") * speed);
        transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime;

        var x = Input.GetAxisRaw("Mouse X");
        var y = Input.GetAxisRaw("Mouse Y");

        mouseInput.x = Mathf.Lerp(mouseInput.x, x, 1f / Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, y, 1f /Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * Sensitivity.x);

        RotateY.transform.Rotate(Vector3.left * mouseInput.y * Sensitivity.y);
        //RotationAlongY(mouseInput.y*Sensitivity.y);

        Crosshair.LookHeight(mouseInput.y * Sensitivity.y);

    }

    private void RotationAlongY(float value)
    {
        rotationY += value;
        if (rotationY > 30 || rotationY < -30)
            rotationY -= value;

        transform.Rotate(Vector3.right * rotationY);

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);

    }

}
