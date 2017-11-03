using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinis : MonoBehaviour
{
    static SpawnMinis Instance;

    //Reference to player gameobject position
    public Transform playerTransform;

    //Reference to the prefab to be instantiated
    public GameObject objectToClone;
    private GameObject[] clonedObject;
    public bool[] cloneCreated = new bool[] { false, false, false };

    public float moveSpeed = 0.5f;

    public float fireRate = 1.5f;
    private float nextFire = 0.0f;

    private Transform trans;
    private float z;
    private void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        z = trans.position.z;
        z -= 2;
        Instance = this;
    }
    void Update()
    {
        clonedObject = new GameObject[3];
        if(Input.GetKeyDown(KeyCode.E) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject clone0 = (GameObject)Instantiate(objectToClone, new Vector3(trans.position.x, trans.position.y, trans.position.z - 2), trans.rotation);
            clonedObject[0] = clone0;
            cloneCreated[0] = true;

            GameObject clone1 = (GameObject)Instantiate(objectToClone, new Vector3(trans.position.x, trans.position.y, trans.position.z), trans.rotation);
            clonedObject[1] = clone1;
            cloneCreated[1] = true;

            GameObject clone2 = (GameObject)Instantiate(objectToClone, new Vector3(trans.position.x, trans.position.y, trans.position.z + 2), trans.rotation);
            clonedObject[2] = clone2;
            cloneCreated[2] = true;
            //for (int i = 0; i < 3; i++)
            //{
            //    GameObject clone = (GameObject)Instantiate(objectToClone, new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z + 1 + i), playerTransform.rotation);
            //    GameObject clone = (GameObject)Instantiate(objectToClone, new Vector3(trans.position.x, trans.position.y, z + i ), trans.rotation);
            //    clonedObject[i] = clone;
            //    cloneCreated[i] = true;

            //}

        }

    }
}