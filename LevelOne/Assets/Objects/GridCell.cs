﻿
using UnityEngine;

public class GridCell
{

    private CellType cellType;
    private int width;
    private int height;
    private Vector2 cellPos;
    private Sprite cellSprite;
    GameObject cellTile;
    SpriteRenderer sr;

    private ColourController colourController;


    public enum CellType {Yellow, Red, Green, Blue, Cyan, Magenta, Black, White}


    public GridCell(CellType cellType, Vector2 cellPos, int size, Sprite cellSprite)
    {
        this.cellType = cellType;
        this.width = size;
        this.height = size;
        this.cellPos = cellPos;
        this.cellSprite = cellSprite;


        InitGridCell();
    }

    public void InitGridCell()
    {
        //CreateCellTile(10);
        
    }

    public CellType getCellType()
    {
        return this.cellType;
    }

    public void setCellType(CellType cellType)
    {
        this.cellType = cellType;
    }

    public Vector2 getCellPos()
    {
        return cellPos;
    }

    public void setCellPos(Vector2 cellPos)
    {
        this.cellPos = cellPos;
    }

    public Sprite getCellSprite()
    {
        return cellSprite;
    }

    public void setCellSprite(Sprite cellSprite)
    {
        this.cellSprite = cellSprite;
    }

    public GameObject getCellTile()
    {
        return this.cellTile;
    }

    public void CreateCellTile(int gridSize)
    {
        float res = (float)(Screen.height) / Screen.width;
        float dist = (float)Screen.height / gridSize;
        float posX = (cellPos.x - (float)(gridSize) / 2 + 0.5f) *  0.6f *res* (20.0f / gridSize) ;
        float posY = (cellPos.y - (float)(gridSize) / 2 + 0.5f) * 0.6f*res*(20.0f/ (float)gridSize) ;
        cellTile = new GameObject("tile" + cellPos.x.ToString() + "_" + cellPos.y.ToString());
        cellTile.transform.localScale = new Vector2(3.2f*(20.0f/gridSize),3.2f*(20.0f/gridSize));
        sr = cellTile.AddComponent<SpriteRenderer>();//add a sprite renderer
        sr.size = new Vector2(10, 10);
        sr.sprite = this.cellSprite;//tileSprite;//assign tile sprite
        cellTile.transform.position = new Vector2(posX, posY);
        colourController = cellTile.AddComponent<ColourController>();
        cellTile.AddComponent<TriggerTest>();
        BoxCollider2D boxCollider = cellTile.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        if (cellType != CellType.Black && cellType != CellType.White)
        {
            colourController.Hide();
        }
    }

    public void RecalculatePosition(int gridSize)
    {
        float res = (float)(Screen.height) / Screen.width;
        float posX = (cellPos.x - (float)(gridSize) / 2 + 0.5f) * 0.6f * res * (20.0f / gridSize) ;
        float posY = (cellPos.y - (float)(gridSize) / 2 + 0.5f) * 0.6f * res * (20.0f / (float)gridSize) ;
        cellTile.transform.position = new Vector2(posX, posY);
    }

    public void AddFinishScript()
    {
        cellTile.AddComponent<TriggerFinish>();
    }

    public void RenderCellTile(CellType cellType)
    {
        switch (cellType)
        {
            case CellType.Blue:
                sr.color = Color.blue;
                break;
            case CellType.Red:
                sr.color = Color.red;
                break;
            case CellType.Green:
                sr.color = Color.green;
                break;
            case CellType.Yellow:
                sr.color = Color.yellow;
                break;
            case CellType.White:
                sr.color = Color.white;
                break;
            case CellType.Cyan:
                sr.color = Color.cyan;
                break;
            case CellType.Magenta:
                sr.color = Color.magenta;
                break;
            default:
                sr.color = new Color(113/255f, 125/255f, 126/255f);
                break;
        }
    }

    public void FadeOut()
    {
        //colourController.StartShake();
        colourController.FadeOut();
    }

    public void FadeIn(int gridSize)
    {
        RecalculatePosition(gridSize);
        //colourController.FadeIn();
        colourController.Show();
    }

}
