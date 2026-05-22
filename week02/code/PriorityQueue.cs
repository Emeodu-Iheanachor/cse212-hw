﻿using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue regardless
    /// of the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the item with the highest priority.
    /// If multiple items have the same priority, return the one
    /// closest to the front of the queue.
    /// </summary>
    /// <returns>The value of the removed item</returns>
    public string Dequeue()
    {
        // Requirement #4
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Start by assuming first item has highest priority
        int highestPriorityIndex = 0;

        // Find highest priority item
        for (int i = 1; i < _queue.Count; i++)
        {
            // Use > so first matching highest priority remains first (FIFO)
            if (_queue[i].Priority > _queue[highestPriorityIndex].Priority)
            {
                highestPriorityIndex = i;
            }
        }

        string value = _queue[highestPriorityIndex].Value;

        _queue.RemoveAt(highestPriorityIndex);

        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs,
    // so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs,
    // so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}