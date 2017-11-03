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


    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        clonedObject = new GameObject[3];
        if(Input.GetKeyDown(KeyCode.R))
        {
         
            for(int i = 0; i < 3; i++)
            {
                GameObject clone = (GameObject)Instantiate(objectToClone, new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z + 1 + i), playerTransform.rotation);
                clonedObject[i] = clone;
                cloneCreated[i] = true;

            }
      
        }

    }
}