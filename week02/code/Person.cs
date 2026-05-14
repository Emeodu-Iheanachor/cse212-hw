public class Person
{
    /// <summary>
    /// The person's name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Number of turns remaining.
    /// 0 or negative means infinite turns.
    /// </summary>
    public int Turns { get; set; }

    /// <summary>
    /// Create a new person with a name and number of turns
    /// </summary>
    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public override string ToString()
    {
        return $"{Name} ({Turns})";
    }
}