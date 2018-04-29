using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;

	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void LevelFinished()
    {
        if (Manager.gridSize == 8)
        {
            Manager.gridSize = 6;
            Manager.blackTiles = 2;
            Manager.colorsAndBeat = 4;
        } else
        {
            Manager.gridSize++;
            if (Manager.gridSize % 2 == 0)
            {
                Manager.blackTiles+=2;
            }
        }

        SceneManager.LoadScene("Scenes/GameBoard");
    }
}
