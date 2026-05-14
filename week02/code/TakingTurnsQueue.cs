using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        _people.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();

        // Infinite turns (0 or negative)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
            return person;
        }

        // Finite turns
        person.Turns--;

        if (person.Turns > 0)
        {
            _people.Enqueue(person);
        }

        return person;
    }
}