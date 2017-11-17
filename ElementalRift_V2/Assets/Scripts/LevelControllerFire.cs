using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerFire : MonoBehaviour {


    public bool AllRunesActivated = false;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public GameObject TakeDownThisModel;
    public GameObject AshOfFireHolder;

    public float LiftDownSpeed= 2.0f;

    private void Update()
    {
        if(!button1.activeInHierarchy && !button2.activeInHierarchy && !button3.activeInHierarchy && !button4.activeInHierarchy)
        {
            AllRunesActivated = true;
        }

        if(AllRunesActivated)
        {
            TakeDownThisModel.transform.Translate(-Vector3.up * Time.deltaTime * LiftDownSpeed);
            AshOfFireHolder.SetActive(true);
        }

  
    }


}
