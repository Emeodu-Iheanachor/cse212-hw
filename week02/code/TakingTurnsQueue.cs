using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    // Needed by the tests
    public int Length => _people.Length;

    /// <summary>
    /// Add a person into the queue.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        Person person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Remove and return the next person.
    /// Re-add them if they still have turns remaining
    /// or if they have infinite turns (0 or less).
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Length == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person current = _people.Dequeue();

        // Infinite turns
        if (current.Turns <= 0)
        {
            _people.Enqueue(current);
        }
        else
        {
            current.Turns--;

            // Re-add only if turns remain
            if (current.Turns > 0)
            {
                _people.Enqueue(current);
            }
        }

        return current;
    }
}