using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public int gridSize = 4;
    public int blackTiles = 1;
    public int colorsAndBeat = 2;
    public int speed = 120;

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
        gridSize++;
        SceneManager.LoadScene("Scenes/GameBoard");
    }
}
