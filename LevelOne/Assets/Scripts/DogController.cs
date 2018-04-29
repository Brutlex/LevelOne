using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    public Vector2 position;
    private bool set = false;
    Vector2 newPos = new Vector2(0, 0);

    private BoardGrid boardGrid;

    // Use this for initialization
    void Start () {
        }

    // Update is called once per frame
    void Update()
    {
        if (boardGrid == null)
        {
            boardGrid = Manager.boardGrid;
        }
        else
        {
            if (!set)
            {
                newPos.x = boardGrid.getGridCell(boardGrid.getGridSize()-1, boardGrid.getGridSize()-1).getCellTile().transform.position.x;
                newPos.y = boardGrid.getGridCell(boardGrid.getGridSize() - 1, boardGrid.getGridSize() - 1).getCellTile().transform.position.y;
                transform.position = newPos;
                transform.localScale = new Vector2(8.0f / boardGrid.getGridSize(), 8.0f / boardGrid.getGridSize());
                set = true;
            }
        }
    }
}
