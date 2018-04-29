using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager
{
    public static BoardGrid boardGrid;

    public static int level = 1;

    public static int gridSize = 4;
    public static int blackTiles = 1;
    public static int colorsAndBeat = 2;
    public static int speed = 120;

    public static void ResetLevel()
    {
        Manager.level = 1;
        Manager.gridSize = 4;
        Manager.blackTiles = 1;
        Manager.speed = 120;
        Manager.colorsAndBeat = 2;
    }
}
