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

    public void RestartLevel()
    {
        SceneManager.LoadScene("Scenes/GameBoard");
    }

    public void LevelFinished()
    {
        Manager.level++;
        if (Manager.level == 6)
        {
            Manager.gridSize = 6;
            Manager.blackTiles = 2;
            Manager.speed = 135;
        } else if (Manager.level == 9)
        {
            Manager.gridSize = 6;
            Manager.blackTiles = 3;
            Manager.speed = 150;
        } else if (Manager.level == 12)
        {
            Manager.gridSize = 6;
            Manager.blackTiles = 3;
            Manager.speed = 120;
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
