using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitProgram : MonoBehaviour {

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Progam terminated.");
    }
}
