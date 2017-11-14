using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    public void ClickedOnPlayGame()
    {

        SceneManager.LoadScene("PrototypeLevel1");
    }


    public void ClickedOnExit()
    {
        Application.Quit();
    }

}
