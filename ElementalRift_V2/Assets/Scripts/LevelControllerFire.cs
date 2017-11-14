using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerFire : MonoBehaviour {


    public bool AllRunesActivated = false;

    public GameObject TakeDownThisModel;
    public GameObject AshOfFireHolder;

    public float LiftDownSpeed= 2.0f;

    private void Update()
    {
        
        if(AllRunesActivated)
        {
            TakeDownThisModel.transform.Translate(-Vector3.up * Time.deltaTime * LiftDownSpeed);
            AshOfFireHolder.SetActive(true);
        }

  
    }


}
