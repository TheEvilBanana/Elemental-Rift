using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChangeToFire : MonoBehaviour {


    
    void OnTriggerEnter(Collider col)
    {
       
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("PrototypeLevel1_Fire");
        }

    }
}
