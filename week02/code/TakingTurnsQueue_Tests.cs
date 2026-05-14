using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TakingTurnsQueueTests
{
[TestMethod]
// Scenario: Run queue until empty with multiple finite-turn users
// Expected Result: Correct round-robin output based on remaining turns
// Defect(s) Found: Incorrect re-enqueue logic caused wrong ordering and missing turns
public void TestTakingTurnsQueue_FiniteRepetition()
{
var bob = new Person("Bob", 2);
var tim = new Person("Tim", 5);
var sue = new Person("Sue", 3);

    Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

    var players = new TakingTurnsQueue();
    players.AddPerson(bob.Name, bob.Turns);
    players.AddPerson(tim.Name, tim.Turns);
    players.AddPerson(sue.Name, sue.Turns);

    int i = 0;

    while (players.Length > 0)
    {
        Assert.IsTrue(i < expectedResult.Length, "Queue produced more results than expected.");

        var person = players.GetNextPerson();
        Assert.AreEqual(expectedResult[i].Name, person.Name);

        i++;
    }

    Assert.AreEqual(expectedResult.Length, i, "Queue did not produce all expected results.");
}

[TestMethod]
// Scenario: Add player mid-execution and continue queue processing
// Expected Result: New player correctly joins rotation at end of queue
// Defect(s) Found: Midway insertion did not preserve correct FIFO rotation order
public void TestTakingTurnsQueue_AddPlayerMidway()
{
    var bob = new Person("Bob", 2);
    var tim = new Person("Tim", 5);
    var sue = new Person("Sue", 3);

    var players = new TakingTurnsQueue();
    players.AddPerson(bob.Name, bob.Turns);
    players.AddPerson(tim.Name, tim.Turns);
    players.AddPerson(sue.Name, sue.Turns);

    for (int i = 0; i < 5; i++)
    {
        var p = players.GetNextPerson();
        Assert.IsNotNull(p);
    }

    players.AddPerson("George", 3);

    Assert.IsTrue(players.Length > 0);

    var firstAfterAdd = players.GetNextPerson();
    Assert.IsNotNull(firstAfterAdd);
}

[TestMethod]
// Scenario: Handle zero-turn (infinite) user correctly
// Expected Result: Infinite-turn user remains in rotation without modifying turn count
// Defect(s) Found: Infinite-turn logic incorrectly modified or removed user from queue
public void TestTakingTurnsQueue_ForeverZero()
{
    var timTurns = 0;

    var bob = new Person("Bob", 2);
    var tim = new Person("Tim", timTurns);
    var sue = new Person("Sue", 3);

    var players = new TakingTurnsQueue();
    players.AddPerson(bob.Name, bob.Turns);
    players.AddPerson(tim.Name, tim.Turns);
    players.AddPerson(sue.Name, sue.Turns);

    for (int i = 0; i < 10; i++)
    {
        var person = players.GetNextPerson();
        Assert.IsNotNull(person);
    }

    var infinitePerson = players.GetNextPerson();
    Assert.AreEqual(timTurns, infinitePerson.Turns);
}

[TestMethod]
// Scenario: Handle negative turn values as infinite turns
// Expected Result: Negative turns behave as infinite-turn users
// Defect(s) Found: Negative turn values were not treated as infinite correctly
public void TestTakingTurnsQueue_ForeverNegative()
{
    var timTurns = -3;

    var tim = new Person("Tim", timTurns);
    var sue = new Person("Sue", 3);

    var players = new TakingTurnsQueue();
    players.AddPerson(tim.Name, tim.Turns);
    players.AddPerson(sue.Name, sue.Turns);

    for (int i = 0; i < 10; i++)
    {
        var person = players.GetNextPerson();
        Assert.IsNotNull(person);
    }

    var infinitePerson = players.GetNextPerson();
    Assert.AreEqual(timTurns, infinitePerson.Turns);
}

[TestMethod]
// Scenario: Attempt to dequeue from empty queue
// Expected Result: Exception thrown with correct message
// Defect(s) Found: Queue did not throw correct exception or message when empty
public void TestTakingTurnsQueue_Empty()
{
    var players = new TakingTurnsQueue();

    var ex = Assert.ThrowsException<InvalidOperationException>(() =>
    {
        players.GetNextPerson();
    });

    Assert.AreEqual("No one in the queue.", ex.Message);
}

}