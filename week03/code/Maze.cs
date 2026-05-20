using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _maze;
    private int _x;
    private int _y;

    public Maze(Dictionary<(int, int), bool[]> maze)
    {
        _maze = maze;

        // Start position must match the test setup
        _x = 1;
        _y = 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_x}, y={_y})";
    }

    private bool CanMove(int direction)
    {
        return _maze[(_x, _y)][direction];
    }

    public void MoveLeft()
    {
        if (!CanMove(0))
            throw new InvalidOperationException("Can't go that way!");

        _x--;
    }

    public void MoveRight()
    {
        if (!CanMove(1))
            throw new InvalidOperationException("Can't go that way!");

        _x++;
    }

    public void MoveUp()
    {
        if (!CanMove(2))
            throw new InvalidOperationException("Can't go that way!");

        _y--;
    }

    public void MoveDown()
    {
        if (!CanMove(3))
            throw new InvalidOperationException("Can't go that way!");

        _y++;
    }
}