using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour {

    public Sprite initialCellSprite;
    public int gridSize;

    private List<GridCell>[] colorLists;
    private float startTime;

	// Use this for initialization
	void Start () {
        gridSize = 8;


        BoardGrid boardGrid = new BoardGrid(gridSize, 4, initialCellSprite);

        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                boardGrid.getCellGrid()[i, j].CreateCellTile(gridSize);
                boardGrid.getCellGrid()[i, j].RenderCellTile(boardGrid.getCellGrid()[i, j].getCellType());
            }
        }

        colorLists = boardGrid.getColorLists();

        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float timePassed = Time.time - startTime;
        int timePassedInt = (int)timePassed;

        int numColors = colorLists.Length;
        int interval = numColors * 2;

        for (int i = 0; i < numColors; i++)
        {
            if (timePassedInt % interval == i*2 % interval)
            {
                foreach (GridCell cell in colorLists[i])
                {
                    cell.FadeIn(gridSize);
                }
            }
            else if (timePassedInt % interval == (i*2+2) % interval)
            {
                foreach (GridCell cell in colorLists[i])
                {
                    cell.FadeOut();
                }
            }
        }
	}
}
