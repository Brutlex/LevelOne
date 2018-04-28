using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour {

    public Sprite initialCellSprite;
    public int gridSize;

	// Use this for initialization
	void Start () {
        gridSize = 3;

        BoardGrid boardGrid = new BoardGrid(gridSize, 6, initialCellSprite);

        for(int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                boardGrid.getCellGrid()[i, j].CreateCellTile(gridSize);
                boardGrid.getCellGrid()[i, j].RenderCellTile(boardGrid.getCellGrid()[i, j].getCellType());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
