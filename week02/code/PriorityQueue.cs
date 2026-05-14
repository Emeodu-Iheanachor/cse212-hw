using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private class Item
    {
        public string Value;
        public int Priority;
        public int Order;

        public Item(string value, int priority, int order)
        {
            Value = value;
            Priority = priority;
            Order = order;
        }
    }

    private readonly List<Item> _items = new();
    private int _orderCounter = 0;

    public void Enqueue(string value, int priority)
    {
        _items.Add(new Item(value, priority, _orderCounter++));
    }

    public string Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int bestIndex = 0;

        for (int i = 1; i < _items.Count; i++)
        {
            var current = _items[i];
            var best = _items[bestIndex];

            // higher priority wins
            if (current.Priority > best.Priority)
            {
                bestIndex = i;
            }
            // same priority → FIFO (earlier insertion wins)
            else if (current.Priority == best.Priority &&
                     current.Order < best.Order)
            {
                bestIndex = i;
            }
        }

        var item = _items[bestIndex];
        _items.RemoveAt(bestIndex);
        return item.Value;
    }
}