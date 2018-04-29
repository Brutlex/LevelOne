using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject GameOverUI;
    public GameObject LevelText;

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
        GameOverUI.SetActive(true);
        LevelText.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Scenes/GameBoard");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void ResetLevel()
    {
        Manager.level = 1;
        Manager.gridSize = 4;
        Manager.blackTiles = 1;
        Manager.speed = 120;
        Manager.colorsAndBeat = 2;
    }

    public void LevelFinished()
    {
        Manager.level++;
        if (Manager.level == 6)
        {
            Manager.gridSize = 6;
            Manager.blackTiles = 2;
            Manager.speed = 135;
            Manager.colorsAndBeat = 2;
        } else if (Manager.level == 9)
        {
            Manager.gridSize = 6;
            Manager.blackTiles = 3;
            Manager.speed = 150;
            Manager.colorsAndBeat = 2;
        } else if (Manager.level == 13)
        {
            Manager.gridSize = 6;
            Manager.blackTiles = 3;
            Manager.speed = 120;
            Manager.colorsAndBeat = 3;
        } else if (Manager.level == 16)
        {
            Manager.gridSize = 7;
            Manager.blackTiles = 3;
            Manager.speed = 135;
            Manager.colorsAndBeat = 3;
        } else  if (Manager.level == 19)
        {
            Manager.gridSize = 8;
            Manager.blackTiles = 5;
            Manager.speed = 150;
            Manager.colorsAndBeat = 3;
        } else if (Manager.level == 23)
        {
            Manager.gridSize = 7;
            Manager.blackTiles = 3;
            Manager.speed = 120;
            Manager.colorsAndBeat = 4;
        } else if (Manager.level == 26)
        {
            Manager.gridSize = 7;
            Manager.blackTiles = 3;
            Manager.speed = 135;
            Manager.colorsAndBeat = 4;
        } else if (Manager.level == 29)
        {
            Manager.gridSize = 8;
            Manager.blackTiles = 5;
            Manager.speed = 150;
            Manager.colorsAndBeat = 4;
        } else if (Manager.level == 32)
        {
            Manager.gridSize = 7;
            Manager.blackTiles = 3;
            Manager.speed = 120;
            Manager.colorsAndBeat = 6;
        } else if (Manager.level == 35)
        {
            Manager.gridSize = 7;
            Manager.blackTiles = 3;
            Manager.speed = 135;
            Manager.colorsAndBeat = 6;
        } else if (Manager.level == 38)
        {
            Manager.gridSize = 8;
            Manager.blackTiles = 5;
            Manager.speed = 150;
            Manager.colorsAndBeat = 6;
        } else {
            Manager.gridSize++;
            if (Manager.gridSize % 2 == 0)
            {
                Manager.blackTiles+=2;
            }
        }

        SceneManager.LoadScene("Scenes/GameBoard");
    }
}
