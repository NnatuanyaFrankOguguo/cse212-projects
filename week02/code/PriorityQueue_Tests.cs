using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities and dequeue. The highest priority item should be returned.
    // Expected Result: "Sue" (priority 5) should be dequeued first.
    // Defect(s) Found: Three bugs: (1) Loop used Count-1 so the last element was never checked.
    //   (2) Used >= instead of > which broke FIFO order for same-priority items.
    //   (3) The item was never actually removed from the queue after finding it.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 3);
        priorityQueue.Enqueue("Sue", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Sue", result);
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority. The first one enqueued (FIFO) should be dequeued first.
    // Expected Result: "Bob" should be dequeued first since Bob and Sue both have priority 3 but Bob was added first.
    // Defect(s) Found: The >= comparison caused the last same-priority item to be selected instead of the first (broke FIFO).
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Tim", 1);
        priorityQueue.Enqueue("Sue", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with message "The queue is empty."
    // Defect(s) Found: None — the empty queue exception was implemented correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items, dequeue all of them in priority order.
    // Expected Result: Items come out in order: Sue(5), Bob(3), Tim(1)
    // Defect(s) Found: The item was not removed from the queue, so repeated Dequeue returned the same item.
    public void TestPriorityQueue_DequeueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Tim", 1);
        priorityQueue.Enqueue("Sue", 5);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: The highest priority item is at the end of the queue.
    // Expected Result: "Last" (priority 10) should still be dequeued first even though it was added last.
    // Defect(s) Found: The loop used Count-1 which skipped the last element entirely, so it was never considered.
    public void TestPriorityQueue_HighestPriorityAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Middle", 5);
        priorityQueue.Enqueue("Last", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Last", result);
    }
}
