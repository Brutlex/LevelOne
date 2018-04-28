using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour {

    public Sprite initialCellSprite;
    public int gridSize = 8;
    public int blackTiles = 4;

    private List<GridCell>[] colorLists;
    private AudioSource audio;


    public BoardGrid boardGrid;

    // Use this for initialization
    void Start () {

        boardGrid = new BoardGrid(gridSize, blackTiles, initialCellSprite);

        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                boardGrid.getCellGrid()[i, j].CreateCellTile(gridSize);
                boardGrid.getCellGrid()[i, j].RenderCellTile(boardGrid.getCellGrid()[i, j].getCellType());
            }
        }

        colorLists = boardGrid.getColorLists();

        audio = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float timePassed = audio.time / 60 * 120;
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
