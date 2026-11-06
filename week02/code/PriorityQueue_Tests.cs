using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities
    // Expected Result: Dequeue should return the items in descending priority order: High, Medium, Low
    // Defect(s) Found: The Dequeue method does not remove the item after returning it. Also, the for loop does not check the last item in the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same priority
    // Expected Result: Dequeue should return the items in FIFO order: High1, High2
    // Defect(s) Found: The Dequeue method does not remove the item after returning it. Also, using >= instead of > causes the queue to select the last item when priorities are equal
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High1", 4);
        priorityQueue.Enqueue("High2", 4);

        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Attempt to dequeue an item from an empty queue
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: None. The exception type and message match the requirements
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        } catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        } catch (AssertFailedException)
        {
            throw;
        } catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected expcetion of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }
}