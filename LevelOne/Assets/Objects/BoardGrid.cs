
using System;
using UnityEngine;

public class BoardGrid
{
    private GridCell[,] gridCellArr;
    private Sprite cellSprite;

    public BoardGrid(int gridSize, Sprite cellSprite)
    {
        gridCellArr = new GridCell[gridSize, gridSize];
        this.cellSprite = cellSprite;
        AutoGenerateGrid(gridSize, cellSprite);
    }

    public void setGridCell(GridCell gridCell, int idxX, int idxY)
    {
        try
        {
            if (idxX > gridCellArr.GetLength(0) || idxY > gridCellArr.GetLength(1)) throw new System.ArgumentException("Die übergebenen Zellenkoordinaten lagen außerhalb des gültigen Bereichs!");
            if (gridCell == null) throw new System.ArgumentNullException("Keine Zelle übergeben!");

            gridCellArr[idxX, idxY] = gridCell;
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.Log(ex);
        }
    }

    public GridCell getGridCell(int idxX, int idxY)
    {
        GridCell gridCell = null;

        try
        {
            if (idxX > gridCellArr.GetLength(0) || idxY > gridCellArr.GetLength(1)) throw new System.ArgumentException("Die übergebenen Zellenkoordinaten lagen außerhalb des gültigen Bereichs!");

            gridCell = gridCellArr[idxX, idxY];
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.Log(ex);
        }

        return gridCell;
    }

    private void AutoGenerateGrid(int gridSize, Sprite cellSprite)
    {
        try
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    //Sprite uniqueCellSprite = Sprite.Create(cellSprite.texture, cellSprite.rect, cellSprite.pivot);
                    gridCellArr[i, j] = new GridCell(GridCell.CellType.Black, new UnityEngine.Vector2(i, j), 0, cellSprite);
                }
            }
        }
        catch
        {

        }
    }
}
