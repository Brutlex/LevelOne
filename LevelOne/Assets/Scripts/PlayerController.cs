using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2.0f;
    public bool continousMovement = false;
    public Vector2 position;
    private bool resized = false;
    Vector2 newPos = new Vector2(0, 0);

    private BoardGrid boardGrid;

    private void Start()
    {
        position = new Vector2(0, 0);
    }

    void Update()
    {
        if (boardGrid == null)
        {
            boardGrid = Manager.boardGrid;
        }
        else
        {
            if(!resized)
            {
                newPos.x = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.x;
                newPos.y = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.y;
                transform.position = newPos;
                transform.localScale = new Vector2(8.0f/boardGrid.getGridSize(), 8.0f/ boardGrid.getGridSize());
                resized = true;
            }

            if (continousMovement)
            {
                if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(position.x < 1))
                {
                    transform.Translate(-Vector2.right * speed);
                }
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && !(position.y >= boardGrid.getGridSize()-1))
                {
                    transform.Translate(Vector2.up * speed);
                }
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && !(position.y < 1))
                {
                    transform.Translate(-Vector2.up * speed);
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && !(position.x >= boardGrid.getGridSize() - 1))
                {
                    transform.Translate(Vector2.right * speed);
                }
            }
            else
            {
                
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && !(position.x < 1))
                {
                    position.x -= 1;
                    newPos.x = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.x;
                    newPos.y = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.y;
                    transform.position = newPos;
                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && !(position.y >= boardGrid.getGridSize() - 1))
                {
                    position.y += 1;
                    newPos.x = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.x;
                    newPos.y = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.y;
                    transform.position = newPos;
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && !(position.y < 1))
                {
                    position.y -= 1;
                    newPos.x = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.x;
                    newPos.y = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.y;
                    transform.position = newPos;

                }
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && !(position.x >= boardGrid.getGridSize() - 1))
                {
                    position.x += 1;
                    newPos.x = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.x;
                    newPos.y = boardGrid.getGridCell((int)position.x, (int)position.y).getCellTile().transform.position.y;
                    transform.position = newPos;
                }
            }
        }
    }
}
