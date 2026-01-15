using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Add multiple items with different priorities to the queue and dequeue one item.
    // Expected Result:
    // The item with the highest priority should be removed and returned.
    // Defect(s) Found:
    // Initially failed because the queue returned the first item added instead of
    // the item with the highest priority.
    public void TestPriorityQueue_HighestPriorityIsDequeued()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario:
    // Add multiple items with the same highest priority and dequeue one item.
    // Expected Result:
    // The item with the highest priority that was added first should be removed (FIFO).
    // Defect(s) Found:
    // Initially failed because FIFO order was not respected for equal priorities.
    public void TestPriorityQueue_FIFOWhenPrioritiesAreEqual()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 4);
        priorityQueue.Enqueue("Second", 4);
        priorityQueue.Enqueue("Third", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario:
    // Attempt to dequeue from an empty priority queue.
    // Expected Result:
    // An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found:
    // Initially failed because the exception was either not thrown or the message was incorrect.
    public void TestPriorityQueue_DequeueFromEmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
