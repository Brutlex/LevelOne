using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int gridSize = 10;
    public int blackTiles = 3;
    public int nColors = 3;
    public Color[] colors = { new Color(1, 0, 0), new Color(0, 1, 0), new Color(0, 0, 01) };
    public float rhythmSpeed = 1f;
    public Color[][] grid;
    private Point[] path;
    private System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    void CalculatePath()
    {
        int pathLength = gridSize * 2 - 1;
        int x = 0;
        int y = 0;
        path = new Point[pathLength];
        path[0] = new Point(0, 0);
        for(int i = 1; i<pathLength; i++)
        {
            if(x < gridSize-1 && y < gridSize - 1)
            {
                int random = rnd.Next(1, 3);
                if(random == 1)
                {
                    x++;
                } else
                {
                    y++;
                }
            } else
            {
                if (x == gridSize - 1)
                {
                    y++;
                } else
                {
                    x++;
                }
            }
            path[i] = new Point(x, y);
        }
    }

    void CreateGrid()
    {
        grid = new Color[gridSize][];
        for(int i = 0; i<grid.Length; i++)
        {
            grid[i] = new Color[gridSize];
        }
        grid[0][0] = new Color(1, 1, 1); //white
        grid[gridSize - 1][gridSize - 1] = new Color(1, 1, 1);

        CreateBlackFields();
        CreatePathColors();
        CreateRandomColors();
;    }

    void CreateRandomColors()
    {
        for(int i = 0; i<gridSize; i++)
        {
            for(int j = 0; j<gridSize; j++)
            {
                if(grid[i][j] == null)
                {
                    int colorIndex = rnd.Next(0, colors.Length);
                    grid[i][j] = colors[colorIndex];
                }
            }
        }
    }

    void CreatePathColors()
    {
        int currentColorIndex = rnd.Next(0, colors.Length);
        foreach(Point pathPoint in path)
        {
            int x = pathPoint.getX();
            int y = pathPoint.getY();
            if(grid[x][y] == null)
            {
                grid[x][y] = colors[currentColorIndex];
                currentColorIndex = (currentColorIndex++) % colors.Length;
            } else
            {
                currentColorIndex = rnd.Next(0, colors.Length);
            }
        }
    }

    void CreateBlackFields()
    {
        Point[] blackTilePositions = new Point[blackTiles];

        int offPath = blackTiles / 2;
        int onPath = blackTiles - offPath;

        //calculate path positions
        int distance = path.Length / (onPath + 1);
        int variance = distance / 2 - 1;

        for(int i = 0; i<onPath; i++)
        {
            int random = rnd.Next(0, variance * 2 + 1);
            int n = (i + 1) * distance - variance + random;
            blackTilePositions[i] = path[n];
        }
        for(int i = onPath; i<blackTiles; i++)
        {
            blackTilePositions[i] = CreateRandomBlackTile(blackTilePositions);
        }

        foreach(Point blackPoint in blackTilePositions)
        {
            grid[blackPoint.getX()][blackPoint.getY()] = new Color(0,0,0); //black
        }
    }

    Point CreateRandomBlackTile(Point[] blackTilePositions)
    {
        Point p = new Point(0, 0);
        do
        {
            int x = rnd.Next(0, gridSize);
            int y = rnd.Next(0, gridSize);
            p = new Point(x, y);
        } while (isInvalidBlackTile(blackTilePositions, p));
        return p;
    }

    private bool isInvalidBlackTile(Point[] blackTiles, Point newTile)
    {
        foreach(Point pathPoint in path)
        {
            if (pathPoint.Equals(newTile))
            {
                return true;
            }
        }
        foreach(Point blackPoint in blackTiles)
        {
            int distX = blackPoint.getX() - newTile.getX();
            int distY = blackPoint.getY() - newTile.getY();

            if(Mathf.Abs(distX) <= 2 || Mathf.Abs(distY) <= 2)
            {
                return true;
            }
        }

        return false;
    }

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
