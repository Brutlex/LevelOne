using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour {

    public Sprite initialCellSprite;
    public int gridSize = 8;
    public int blackTiles = 4;

    private List<GridCell>[] colorLists;
    private AudioSource audio;

<<<<<<< HEAD
    public BoardGrid boardGrid;

    // Use this for initialization
    void Start () {
        gridSize = 8;

        boardGrid = new BoardGrid(gridSize, blackTiles, initialCellSprite);
=======
    // Use this for initialization
    void Start () {
        BoardGrid boardGrid = new BoardGrid(gridSize, blackTiles, initialCellSprite);
>>>>>>> 726acc100acd1500861d6295e573d61a5d80746b

        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                boardGrid.getCellGrid()[i, j].CreateCellTile(gridSize);
                boardGrid.getCellGrid()[i, j].RenderCellTile(boardGrid.getCellGrid()[i, j].getCellType());
            }
        }

        colorLists = boardGrid.getColorLists();

<<<<<<< HEAD

        audio = gameObject.GetComponent<AudioSource>();
    }

=======
        audio = gameObject.GetComponent<AudioSource>();
    }
	
>>>>>>> 726acc100acd1500861d6295e573d61a5d80746b
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
