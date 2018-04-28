using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour {

    public Sprite initialCellSprite;
    public int gridSize = 8;
    public int blackTiles = 4;
    public int colorsAndBeat = 2;
    public int audioSpeed = 120;

    public AudioClip[] fourBeat;
    public AudioClip[] twoBeat;

    private List<GridCell>[] colorLists;
    private AudioSource audio;

    public BoardGrid boardGrid;

    // Use this for initialization
    void Start () {

        boardGrid = new BoardGrid(gridSize, blackTiles, colorsAndBeat, initialCellSprite);
        Manager.boardGrid = boardGrid;

        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                boardGrid.getCellGrid()[i, j].CreateCellTile(gridSize);
                boardGrid.getCellGrid()[i, j].RenderCellTile(boardGrid.getCellGrid()[i, j].getCellType());
            }
        }

        colorLists = boardGrid.getColorLists(colorsAndBeat);
        int audioSpeedIndex = (audioSpeed - 120) / 15;
        audio = gameObject.GetComponent<AudioSource>();
        if(colorsAndBeat == 2)
        {
            audio.clip = twoBeat[audioSpeedIndex];
        } else if(colorsAndBeat == 4)
        {
            audio.clip = fourBeat[audioSpeedIndex];
        }
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
        float timePassed = audio.time / 60 * audioSpeed;
        int timePassedInt = (int)timePassed;

        int activeTime = 1;
        int numColors = colorLists.Length;
        int interval = numColors * activeTime;
        

        for (int i = 0; i < numColors; i++)
        {
            if (timePassedInt % interval == (i*activeTime) % interval)
            {
                foreach (GridCell cell in colorLists[i])
                {
                    cell.FadeIn(gridSize);
                }
            }
            else if (timePassedInt % interval == (i*activeTime+activeTime) % interval)
            {
                foreach (GridCell cell in colorLists[i])
                {
                    cell.FadeOut();
                }
            }
        }
	}
}
