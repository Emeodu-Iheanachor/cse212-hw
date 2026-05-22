using System;
using System.Collections.Generic;

public class PersonQueue
{
    private readonly Queue<Person> _queue = new();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        _queue.Enqueue(person);
    }

    public Person Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        return _queue.Dequeue();
    }
}