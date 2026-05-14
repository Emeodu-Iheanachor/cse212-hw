using System.Collections.Generic;

public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the BACK of the queue (FIFO behavior)
    /// </summary>
    public void Enqueue(Person person)
    {
        _queue.Add(person);
    }

    /// <summary>
    /// Remove and return the person at the FRONT of the queue
    /// </summary>
    public Person Dequeue()
    {
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    /// <summary>
    /// Check if queue is empty
    /// </summary>
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}