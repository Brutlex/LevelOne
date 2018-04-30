using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject PauseUI;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GamePaused = false;
    }
    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        GamePaused = true;

    }
}
