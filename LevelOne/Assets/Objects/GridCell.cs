
using UnityEngine;

public class GridCell  {

    private CellType cellType;
    private int width;
    private int height;
    private Vector2 cellPos;
    private Sprite cellSprite;
    GameObject cellTile;
    SpriteRenderer sr;


    public enum CellType {Yellow, Red, Green, Blue, Black}

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
        CreateCellTile(10);
        RenderCellTile(CellType.Red);
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

    private void CreateCellTile(int tileSize)
    {      

        cellTile = new GameObject("tile" + cellPos.x.ToString() + "_" + cellPos.y.ToString());
        cellTile.transform.localScale = Vector2.one * (tileSize - 3);
        sr = cellTile.AddComponent<SpriteRenderer>();//add a sprite renderer
        sr.size = new Vector2(10, 10);
        sr.sprite = this.cellSprite;//tileSprite;//assign tile sprite
        cellTile.transform.position = new Vector2(cellPos.x-5, cellPos.y-5);        
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
            default:
                sr.color = Color.black;
                break;
        }
    }

}
