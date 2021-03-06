﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGrid
{
    private GridCell[,] gridCellArr;
    private Sprite cellSprite;

    private GridCell.CellType[] colors = { GridCell.CellType.Yellow, GridCell.CellType.Blue, GridCell.CellType.Red, GridCell.CellType.Green, GridCell.CellType.Cyan, GridCell.CellType.Magenta };
    public BoardGrid(int gridSize, int blackCells, int colorsAndBeat, Sprite cellSprite)
    {
        ShuffleArray(colors);
        gridCellArr = new GridCell[gridSize, gridSize];
        this.cellSprite = cellSprite;
        AutoGenerateGrid(gridSize, blackCells, colorsAndBeat, cellSprite);
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

    public int getGridSize()
    {
        return gridCellArr.GetLength(0);
    }


    public GridCell[,] getCellGrid()
    {
        return gridCellArr;
    }

    public List<GridCell>[] getColorLists(int colorSize)
    {
        List<GridCell>[] colorLists = new List<GridCell>[colorSize];

        for (int k = 0; k < colorLists.Length; k++)
        {
            List<GridCell> list = new List<GridCell>();
            for (int i = 0; i < gridCellArr.GetLength(0); i++)
            {
                for (int j = 0; j < gridCellArr.GetLength(1); j++)
                {
                    if (gridCellArr[i, j].getCellType() == colors[k])
                    {
                        list.Add(gridCellArr[i, j]);
                    }
                }
            }
            colorLists[k] = list;
        }
        return colorLists;
    }

    private void AutoGenerateGrid(int gridSize, int blackCellAmount, int colorsAmount, Sprite cellSprite)
    {
        try
        {
            //create start and and cell
            gridCellArr[0, 0] = new GridCell(GridCell.CellType.White, new UnityEngine.Vector2(0, 0), 0, cellSprite);
            gridCellArr[gridSize - 1, gridSize - 1] = new GridCell(GridCell.CellType.White, new UnityEngine.Vector2(gridSize - 1, gridSize - 1), 0, cellSprite);

            System.Random rnd = new System.Random();
            Point[] path = CalculatePath(gridSize, rnd);
            Point[] blackCells = CreateBlackFields(gridSize, blackCellAmount, rnd, path);

            // create black cells
            foreach (Point blackPoint in blackCells)
            {
                int i = blackPoint.getX();
                int j = blackPoint.getY();
                gridCellArr[i, j] = new GridCell(GridCell.CellType.Black, new UnityEngine.Vector2(i, j), 0, cellSprite);
            }

            // create cells on path
            int currentColorIndex = rnd.Next(0, colorsAmount);
            foreach (Point pathPoint in path)
            {
                int i = pathPoint.getX();
                int j = pathPoint.getY();
                if (gridCellArr[i, j] == null)
                {
                    gridCellArr[i, j] = new GridCell(colors[currentColorIndex], new UnityEngine.Vector2(i, j), 0, cellSprite);
                    currentColorIndex = (currentColorIndex+1) % colorsAmount;
                }
                else
                {
                    currentColorIndex = rnd.Next(0, colorsAmount);
                }
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if(gridCellArr[i, j] == null)
                    {
                        currentColorIndex = rnd.Next(0, colorsAmount);
                        gridCellArr[i, j] = new GridCell(colors[currentColorIndex], new UnityEngine.Vector2(i, j), 0, cellSprite);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    Point[] CalculatePath(int gridSize, System.Random rnd)
    {
        int pathLength = gridSize * 2 - 1;
        int x = 0;
        int y = 0;
        Point[] path = new Point[pathLength];
        path[0] = new Point(0, 0);
        for (int i = 1; i < pathLength; i++)
        {
            if (x < gridSize - 1 && y < gridSize - 1)
            {
                int random = rnd.Next(1, 3);
                if (random == 1)
                {
                    x++;
                }
                else
                {
                    y++;
                }
            }
            else
            {
                if (x == gridSize - 1)
                {
                    y++;
                }
                else
                {
                    x++;
                }
            }
            path[i] = new Point(x, y);
        }
        return path;
    }

    Point[] CreateBlackFields(int gridSize, int blackCellAmount, System.Random rnd, Point[] path)
    {
        Point[] blackCells = new Point[blackCellAmount];

        int offPath = blackCellAmount / 2;
        int onPath = blackCellAmount - offPath;

        //calculate path positions
        int distance = path.Length / (onPath + 1);
        int variance = distance / 2 - 1;
        if (variance < 0)
        {
            variance = 0;
        }

        for (int i = 0; i < onPath; i++)
        {
            int random = rnd.Next(0, variance * 2 + 1);
            int n = (i + 1) * distance - variance + random;
            blackCells[i] = path[n];
        }
        for (int i = onPath; i < blackCellAmount; i++)
        {
            blackCells[i] = CreateRandomBlackTile(gridSize, rnd, path, blackCells);
        }

        return blackCells;
    }

    Point CreateRandomBlackTile(int gridSize, System.Random rnd, Point[] path, Point[] blackCells)
    {
        Point p = new Point(0, 0);
        do
        {
            int x = rnd.Next(0, gridSize);
            int y = rnd.Next(0, gridSize);
            p = new Point(x, y);
        } while (isInvalidBlackTile(path, blackCells, p));
        return p;
    }

    private bool isInvalidBlackTile(Point[] path, Point[] blackCells, Point newCell)
    {
        foreach (Point pathPoint in path)
        {
            if (pathPoint.Equals(newCell))
            {
                return true;
            }
        }
        foreach (Point blackPoint in blackCells)
        {
            if (blackPoint == null) continue;
            int distX = blackPoint.getX() - newCell.getX();
            int distY = blackPoint.getY() - newCell.getY();

            if (Mathf.Abs(distX) <= 2 && Mathf.Abs(distY) <= 2)
            {
                return true;
            }
        }

        return false;
    }

    private void ShuffleArray(GridCell.CellType[] list)
    {
        System.Random rnd = new System.Random();
        int n = list.Length;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            GridCell.CellType value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    //private class containing x and y position needed for initial board calculation
    private class Point
    {
        int x;
        int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
    }
}
