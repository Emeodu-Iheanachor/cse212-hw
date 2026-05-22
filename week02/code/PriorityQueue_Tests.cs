using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]

    // Scenario:
    // Add several items with different priorities.
    // Remove one item from the queue.
    //
    // Expected Result:
    // The item with the highest priority should be removed first.
    //
    // Defect(s) Found:
    // Original code removed the first item in the queue instead of
    // searching for the highest priority item.

    // Test Case: Verify highest priority item is removed first.
    // Expected Result: Highest priority value returned.
    // Test Result: Failed initially because queue removed first item instead
    // of highest priority item.
    // Fix Applied: Updated Dequeue logic to search the queue for the
    // highest priority item before removing.
    public void TestPriorityQueue_1()
    {
        PriorityQueue queue = new();

        queue.Enqueue("A", 1);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        Assert.AreEqual("B", queue.Dequeue());
    }

    [TestMethod]

    // Scenario:
    // Add multiple items with the same highest priority.
    // Remove items from the queue.
    //
    // Expected Result:
    // The item inserted first among equal priorities should be removed first
    // following FIFO order.
    //
    // Defect(s) Found:
    // Original implementation did not correctly verify FIFO behavior
    // for matching priorities.

    // Test Case: Verify FIFO order for same priority.
    // Expected Result: First inserted item with same priority removed first.
    // Test Result: Failed initially because FIFO behavior was not tested.
    // Fix Applied: Added FIFO test case and corrected queue logic.
    public void TestPriorityQueue_2()
    {
        PriorityQueue queue = new();

        queue.Enqueue("A", 5);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 5);

        Assert.AreEqual("A", queue.Dequeue());
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
    }

    [TestMethod]

    // Scenario:
    // Attempt to dequeue from an empty queue.
    //
    // Expected Result:
    // An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    //
    // Defect(s) Found:
    // Exception handling for empty queue was missing or incorrect.

    // Test Case: Verify empty queue throws exception.
    // Expected Result: InvalidOperationException thrown.
    // Test Result: Passed after adding proper exception handling.
    // Fix Applied: Added InvalidOperationException in Dequeue method.
    public void TestPriorityQueue_Empty()
    {
        PriorityQueue queue = new();

        Exception ex = Assert.ThrowsException<InvalidOperationException>(
            () => queue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]

    // Scenario:
    // Add items in mixed priority order and remove all items.
    //
    // Expected Result:
    // Items should always be removed from highest priority to lowest priority.
    //
    // Defect(s) Found:
    // Original implementation did not consistently remove highest priorities.

    // Test Case: Verify ordering across multiple priorities.
    // Expected Result: Items dequeued in proper priority order.
    // Test Result: Failed before fixing Dequeue logic.
    // Fix Applied: Corrected search for highest priority item.
    public void TestPriorityQueue_3()
    {
        PriorityQueue queue = new();

        queue.Enqueue("Low", 1);
        queue.Enqueue("Medium", 3);
        queue.Enqueue("High", 10);
        queue.Enqueue("Higher", 7);

        Assert.AreEqual("High", queue.Dequeue());
        Assert.AreEqual("Higher", queue.Dequeue());
        Assert.AreEqual("Medium", queue.Dequeue());
        Assert.AreEqual("Low", queue.Dequeue());
    }
}