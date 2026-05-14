using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
[TestMethod]
// Scenario: Highest priority item should always be dequeued first
// Expected Result: Item with highest priority is returned
// Defect(s) Found: Incorrect comparison logic caused wrong item selection
public void TestPriorityQueue_HighestPriority()
{
var queue = new PriorityQueue();

    queue.Enqueue("Bob", 1);
    queue.Enqueue("Tim", 5);
    queue.Enqueue("Sue", 3);

    var result = queue.Dequeue();

    Assert.AreEqual("Tim", result);
}

[TestMethod]
// Scenario: Items with equal highest priority should follow FIFO order
// Expected Result: First inserted item among same priority values is removed first
// Defect(s) Found: FIFO ordering not preserved for equal priority items
public void TestPriorityQueue_FIFO_SamePriority()
{
    var queue = new PriorityQueue();

    queue.Enqueue("Bob", 5);
    queue.Enqueue("Tim", 5);
    queue.Enqueue("Sue", 5);

    Assert.AreEqual("Bob", queue.Dequeue());
    Assert.AreEqual("Tim", queue.Dequeue());
    Assert.AreEqual("Sue", queue.Dequeue());
}

[TestMethod]
// Scenario: Verify full priority ordering across multiple dequeues
// Expected Result: Items come out in descending priority order
// Defect(s) Found: Queue did not maintain ordering after multiple operations
public void TestPriorityQueue_MultipleDequeue()
{
    var queue = new PriorityQueue();

    queue.Enqueue("A", 2);
    queue.Enqueue("B", 10);
    queue.Enqueue("C", 5);
    queue.Enqueue("D", 10);

    Assert.AreEqual("B", queue.Dequeue());
    Assert.AreEqual("D", queue.Dequeue());
    Assert.AreEqual("C", queue.Dequeue());
    Assert.AreEqual("A", queue.Dequeue());
}

[TestMethod]
// Scenario: Attempt to dequeue from empty queue
// Expected Result: InvalidOperationException with correct message
// Defect(s) Found: Queue did not properly handle empty state exception
public void TestPriorityQueue_Empty()
{
    var queue = new PriorityQueue();

    var ex = Assert.ThrowsException<InvalidOperationException>(() =>
    {
        queue.Dequeue();
    });

    Assert.AreEqual("The queue is empty.", ex.Message);
}

}