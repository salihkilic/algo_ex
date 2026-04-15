using AlgorithmTestFramework;

namespace _07_Queue;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Queue Algorithms Exercise Runner --- \n");
        RunTests();
    }

    private static void RunTests()
    {
        Console.WriteLine("Testing Basic Operations...");
        TestRunner.RunTest("Queue Enqueue/Dequeue", TestQueueEnqueueDequeue, 
            "Ensure Enqueue adds to back and Dequeue removes from front (FIFO). Check Count updates.");

        Console.WriteLine("\nTesting Capacity Limits...");
        TestRunner.RunTest("Queue Full State", TestQueueFull, 
            "Queue should report Full=true when capacity reached. Enqueue should not add if full.");

        TestRunner.RunTest("Queue Empty State", TestQueueEmpty, 
            "Queue should report Empty=true when count is 0. Dequeue on empty should return default.");

        Console.WriteLine("\nTesting Circular Logic...");
        TestRunner.RunTest("Queue Circular Behavior", TestQueueCircularBehavior, 
            "Indices should wrap around the array length. Verify items are retrieved in correct order after wrap.");

        TestRunner.RunTest("Repeated Enqueue/Dequeue", TestQueueClearOrResetImplicitly, 
            "Repeatedly adding and removing should work indefinitely without index out of bounds.");

        TestRunner.RunTest("Queue: Full After Circular Wrapping", TestQueueFullAfterCircularWrapping,
            "Queue should correctly identify Full state after wrapping around. Verify FIFO order is preserved.");
    }

    /// <summary>
    /// Tests basic Enqueue and Dequeue functionality.
    /// Ensures that items are added and removed in FIFO (First-In, First-Out) order.
    /// </summary>
    private static void TestQueueEnqueueDequeue()
    {
        // Create a queue with capacity 5
        var queue = new Queue<int>(5);

        // Check initial state
        Assertions.AssertEqual(0, queue.Count, "New queue should be empty count."); 
        Assertions.AssertEqual(true, queue.Empty, "New queue should be empty.");

        // Enqueue items
        queue.Enqueue(10);
        Assertions.AssertEqual(1, queue.Count, "Count should be 1 after one enqueue.");
        Assertions.AssertEqual(false, queue.Empty, "Queue should not be empty after enqueue.");

        queue.Enqueue(20);
        queue.Enqueue(30);
        Assertions.AssertEqual(3, queue.Count, "Count should be 3 after three enqueues.");

        // Dequeue items
        int val1 = queue.Dequeue();
        Assertions.AssertEqual(10, val1, "First dequeued item should be the first enqueued (10).");
        Assertions.AssertEqual(2, queue.Count, "Count should decrement after dequeue.");

        int val2 = queue.Dequeue();
        Assertions.AssertEqual(20, val2, "Second dequeued item should be 20.");
        
        int val3 = queue.Dequeue();
        Assertions.AssertEqual(30, val3, "Third dequeued item should be 30.");
        
        Assertions.AssertEqual(0, queue.Count, "Queue should be empty after dequeuing all items.");
        Assertions.AssertEqual(true, queue.Empty, "Queue.Empty should be true when count is 0.");
    }

    /// <summary>
    /// Tests the behavior when the queue becomes full.
    /// Ensures that the queue correctly reports it is Full and handles over-capacity enqueue attempts gracefully
    /// (by not adding, based on the implementation description/inference).
    /// </summary>
    private static void TestQueueFull()
    {
        int capacity = 3;
        var queue = new Queue<int>(capacity);

        Assertions.AssertEqual(capacity, queue.Size, $"Queue Size property should return capacity {capacity}.");

        queue.Enqueue(1);
        queue.Enqueue(2);
        Assertions.AssertEqual(false, queue.Full, "Queue should not be full yet.");
        
        queue.Enqueue(3);
        Assertions.AssertEqual(true, queue.Full, "Queue should be full after adding capacity number of items.");
        Assertions.AssertEqual(capacity, queue.Count, "Count should equal capacity.");

        // Try to enqueue when full
        queue.Enqueue(4);
        Assertions.AssertEqual(capacity, queue.Count, "Count should not increase when enqueueing to a full queue.");
        Assertions.AssertEqual(true, queue.Full, "Queue should remain full.");

        // Ensure the item '4' was not actually added in a way that displaces '1'
        // Next dequeue should be '1'
        int val = queue.Dequeue();
        Assertions.AssertEqual(1, val, "After failed over-capacity enqueue, '1' should still be at front.");
        Assertions.AssertEqual(false, queue.Full, "Queue should no longer be full after dequeue.");
    }

    /// <summary>
    /// Tests the Empty property and Dequeue behavior on an empty queue.
    /// Dequeue on empty should return default(T).
    /// </summary>
    private static void TestQueueEmpty()
    {
        var queue = new Queue<string>(3);

        Assertions.AssertEqual(true, queue.Empty, "New queue should be Empty.");

        string? val = queue.Dequeue();
        Assertions.AssertEqual(null, val, "Dequeue on empty queue should return default/null.");
        
        queue.Enqueue("A");
        Assertions.AssertEqual(false, queue.Empty, "Queue should not be empty after adding item.");
        
        queue.Dequeue();
        Assertions.AssertEqual(true, queue.Empty, "Queue should be empty after removing the only item.");
    }

    /// <summary>
    /// Tests the circular buffer behavior.
    /// This tests if the queue wraps around the internal array when items are added and removed continuously.
    /// </summary>
    private static void TestQueueCircularBehavior()
    {
        // Capacity 3
        var queue = new Queue<int>(3);

        // Fill queue: [1, 2, 3]
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assertions.AssertEqual(true, queue.Full, "Queue is full.");

        // Remove two: [_, _, 3] (conceptually)
        Assertions.AssertEqual(1, queue.Dequeue(), "Dequeue 1.");
        Assertions.AssertEqual(2, queue.Dequeue(), "Dequeue 2.");
        
        // Count should be 1
        Assertions.AssertEqual(1, queue.Count, "Count should be 1.");

        // Queue has space now. Add two more: [4, 5, 3] (conceptually 3 is front, 4, 5 wrapped)
        // If circular logic is wrong, this might fail (index out of bounds or overwriting wrong index).
        queue.Enqueue(4);
        queue.Enqueue(5);

        Assertions.AssertEqual(3, queue.Count, "Count should be 3.");
        Assertions.AssertEqual(true, queue.Full, "Queue should be full again.");

        // Verify order: should be 3, 4, 5
        Assertions.AssertEqual(3, queue.Dequeue(), "Expect 3 (oldest remaining).");
        Assertions.AssertEqual(4, queue.Dequeue(), "Expect 4.");
        Assertions.AssertEqual(5, queue.Dequeue(), "Expect 5.");
        
        Assertions.AssertEqual(true, queue.Empty, "Queue should be empty.");
    }

    /// <summary>
    /// Checks a scenario where we enqueue and dequeue repeatedly to ensure indices are updated correctly.
    /// </summary>
    private static void TestQueueClearOrResetImplicitly()
    {
        var queue = new Queue<int>(2);
        
        for (int i = 0; i < 10; i++)
        {
            queue.Enqueue(i);
            Assertions.AssertEqual(1, queue.Count, "Count should be 1.");
            int val = queue.Dequeue();
            Assertions.AssertEqual(i, val, "Should get back the value just pushed.");
            Assertions.AssertEqual(true, queue.Empty, "Should be empty.");
        }
    }

    /// <summary>
    /// Tests the queue's behavior and state reporting after the internal array has been wrapped around.
    /// Specifically checks if the queue still reports full correctly and maintains FIFO order.
    /// </summary>
    private static void TestQueueFullAfterCircularWrapping()
    {
        var queue = new Queue<int>(4);  // Increased capacity to 4

        // Fill the queue to capacity
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        Assertions.AssertEqual(true, queue.Full, "Queue should be full.");

        // Dequeue two items to create wrapping space
        queue.Dequeue();
        queue.Dequeue();
        Assertions.AssertEqual(2, queue.Count, "Count should be 2 after 2 dequeues.");

        // Enqueue two more items to wrap around
        queue.Enqueue(5);
        queue.Enqueue(6);
        Assertions.AssertEqual(true, queue.Full, "Queue should be full after wrapping around.");

        // Dequeue all items to check order (should be 3,4,5,6 in FIFO order)
        Assertions.AssertEqual(queue.Dequeue(), 3, "Expect 3 (FIFO order).");
        Assertions.AssertEqual(queue.Dequeue(), 4, "Expect 4.");
        Assertions.AssertEqual(queue.Dequeue(), 5, "Expect 5.");
        Assertions.AssertEqual(queue.Dequeue(), 6, "Expect 6.");

        Assertions.AssertEqual(true, queue.Empty, "Queue should be empty after dequeuing all items.");
    }

}
