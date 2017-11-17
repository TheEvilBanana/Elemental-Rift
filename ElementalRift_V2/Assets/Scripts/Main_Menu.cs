using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    public void ClickedOnPlayGame()
    {

        SceneManager.LoadScene("GeneralInstructions");
    }


    public void ClickedOnExit()
    {
        Application.Quit();
    }

}
