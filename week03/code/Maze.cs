using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move.
    /// If you can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveLeft()
    {
        // left = index 0
        if (!_mazeMap[(_currX, _currY)][0])
            throw new InvalidOperationException("Can't go that way!");

        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move.
    /// If you can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveRight()
    {
        // right = index 1
        if (!_mazeMap[(_currX, _currY)][1])
            throw new InvalidOperationException("Can't go that way!");

        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move.
    /// If you can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveUp()
    {
        // up = index 2
        if (!_mazeMap[(_currX, _currY)][2])
            throw new InvalidOperationException("Can't go that way!");

        _currY++;
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move.
    /// If you can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveDown()
    {
        // down = index 3
        if (!_mazeMap[(_currX, _currY)][3])
            throw new InvalidOperationException("Can't go that way!");

        _currY--;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
