using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Vector3 cameraOffset;
    public float damping;
    public Transform cameraLookTarget;
    public GameObject Player;

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

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player = GameObject.FindGameObjectWithTag("Player");
        //cameraLookTarget = Player.transform.Find("CameraLookTarget");
    }

    private void Update()
    {
        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //screenPosition.y = Screen.height - screenPosition.y;

        //cameraLookTarget.transform.position = new Vector3(screenPosition.x, screenPosition.y, cameraLookTarget.transform.position.z);

        Vector3 targetPosition = cameraLookTarget.position+Player.transform.forward*cameraOffset.z+Player.transform.up*cameraOffset.y+ Player.transform.right * cameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);

    }

}
