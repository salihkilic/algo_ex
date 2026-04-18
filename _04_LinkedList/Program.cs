using _04_LinkedList;
using AlgorithmTestFramework;

Console.WriteLine("--- Singly Linked List Algorithms Exercise Runner --- \n");

// --- Basic Operations Tests ---
Console.WriteLine("Testing Basic Operations (AddFirst, AddLast, Count)...");

TestRunner.RunTest("AddFirst: Add to Empty and Non-Empty", () =>
{
    var list = new SinglyLinkedList<int>();
    Assertions.AssertEqual(list.Count, 0);

    list.AddFirst(10);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.Head?.Value, 10);

    list.AddFirst(5);
    Assertions.AssertEqual(list.Count, 2);
    Assertions.AssertEqual(list.Head?.Value, 5);
    Assertions.AssertEqual(list.Head?.Next?.Value, 10);
}, "Hint: AddFirst should set Head to new node, pointing Next to old Head.");

TestRunner.RunTest("AddLast: Add to Empty and Non-Empty", () =>
{
    var list = new SinglyLinkedList<int>();
    
    list.AddLast(10);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.Head?.Value, 10);

    list.AddLast(20);
    Assertions.AssertEqual(list.Count, 2);
    // Head should remain same
    Assertions.AssertEqual(list.Head?.Value, 10);
    // Tail check (traverse)
    Assertions.AssertEqual(list.Head?.Next?.Value, 20);
}, "Hint: AddLast traverses to the end and appends a new node. If empty, it becomes Head.");

TestRunner.RunTest("Count: Matches Node Count", () =>
{
    var list = new SinglyLinkedList<int>();
    
    // Test count on empty list
    Assertions.AssertEqual(list.Count, 0);
    
    // Add nodes and verify count matches
    list.AddLast(1);
    Assertions.AssertEqual(list.Count, 1);
    
    list.AddLast(2);
    Assertions.AssertEqual(list.Count, 2);
    
    list.AddLast(3);
    Assertions.AssertEqual(list.Count, 3);
    
    list.AddFirst(0);
    Assertions.AssertEqual(list.Count, 4);
    
    // Manually verify by traversing and counting nodes
    int nodeCount = 0;
    var current = list.Head;
    while (current != null)
    {
        nodeCount++;
        current = current.Next;
    }
    
    Assertions.AssertEqual(list.Count, nodeCount);
}, "Hint: Count should accurately reflect the number of nodes in the list. Verify by manual traversal.");


// --- Enumeration Tests ---
Console.WriteLine("\nTesting Enumeration...");

TestRunner.RunTest("GetEnumerator: Foreach Support", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    list.AddLast(3);

    int[] expected = [1, 2, 3];
    int[] actual = new int[3];
    int i = 0;
    
    foreach(var item in list)
    {
        actual[i++] = item;
    }
    
    Assertions.AssertSorted(actual, expected);
}, "Hint: Implement IEnumerable<T> by yielding values from Head to null.");


// --- Removal Tests ---
Console.WriteLine("\nTesting Remove...");

TestRunner.RunTest("Remove: Head", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    
    bool removed = list.Remove(1);
    
    Assertions.AssertEqual(removed, true);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.Head?.Value, 2);
}, "Hint: Special case checking if Head matches value.");

TestRunner.RunTest("Remove: Middle/Tail", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    list.AddLast(3); // Tail
    
    // Remove Middle
    bool removedMid = list.Remove(2);
    Assertions.AssertEqual(removedMid, true);
    Assertions.AssertEqual(list.Count, 2);
    // Check link integrity (1 -> 3)
    Assertions.AssertEqual(list.Head?.Value, 1);
    Assertions.AssertEqual(list.Head?.Next?.Value, 3);
    
    // Remove Tail
    bool removedTail = list.Remove(3);
    Assertions.AssertEqual(removedTail, true);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.Head?.Value, 1);
    Assertions.AssertEqual(list.Head?.Next == null, true);
}, "Hint: Iterate with 'current' and 'previous' (or just current.Next) to unlink the node.");

TestRunner.RunTest("Remove: Not Found", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddLast(1);
    
    bool removed = list.Remove(99);
    Assertions.AssertEqual(removed, false);
    Assertions.AssertEqual(list.Count, 1);
});

TestRunner.RunTest("Remove: From Empty", () =>
{
    var list = new SinglyLinkedList<int>();
    bool removed = list.Remove(1);
    Assertions.AssertEqual(removed, false);
});


// --- Search/Contains Tests ---
Console.WriteLine("\nTesting Search & Contains...");

TestRunner.RunTest("Contains: Basic", () =>
{
    var list = new SinglyLinkedList<string>();
    list.AddLast("A");
    list.AddLast("B");
    
    Assertions.AssertEqual(list.Contains("B"), true);
    Assertions.AssertEqual(list.Contains("Z"), false);
});

TestRunner.RunTest("Search: Basic", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddLast(10);
    list.AddLast(20);
    
    var node = list.Search(20);
    Assertions.AssertEqual(node != null, true);
    Assertions.AssertEqual(node?.Value, 20);
    
    var missing = list.Search(99);
    Assertions.AssertEqual(missing == null, true);
});


// --- AddSorted Tests ---
Console.WriteLine("\nTesting AddSorted...");

TestRunner.RunTest("AddSorted: Empty List", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddSorted(10);
    
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.Head?.Value, 10);
});

TestRunner.RunTest("AddSorted: Insert at Head", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddSorted(20);
    list.AddSorted(10); // Should go before 20
    
    int[] expected = [10, 20];
    int[] actual = new int[2];
    int i = 0; foreach(var x in list) actual[i++] = x;

    Assertions.AssertSorted(actual, expected);
}, "Hint: Check if value < Head.Value, insert before head.");

TestRunner.RunTest("AddSorted: Insert in Middle", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddSorted(10);
    list.AddSorted(30);
    list.AddSorted(20); // Should go between 10 and 30
    
    int[] expected = [10, 20, 30];
    int[] actual = new int[3];
    int i = 0; foreach(var x in list) actual[i++] = x;

    Assertions.AssertSorted(actual, expected);
}, "Hint: Iterate until current.Next.Value > value, then insert.");

TestRunner.RunTest("AddSorted: Insert at Tail", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddSorted(10);
    list.AddSorted(20);
    list.AddSorted(30); // Should go last
    
    int[] expected = [10, 20, 30];
    int[] actual = new int[3];
    int i = 0; foreach(var x in list) actual[i++] = x;

    Assertions.AssertSorted(actual, expected);
});

// --- Clear Tests ---
Console.WriteLine("\nTesting Clear...");
TestRunner.RunTest("Clear: Reset List", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    
    list.Clear();
    
    Assertions.AssertEqual(list.Count, 0);
    Assertions.AssertEqual(list.Head == null, true);
}, "Hint: Set Head to null. Don't forget to reset Count to 0!");

TestRunner.RunTest("Clear: Reuse After Clear", () =>
{
    var list = new SinglyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    list.AddLast(3);
    
    // Clear the list
    list.Clear();
    Assertions.AssertEqual(list.Count, 0);
    Assertions.AssertEqual(list.Head == null, true);
    
    // Add new elements after clearing
    list.AddLast(10);
    list.AddLast(20);
    
    Assertions.AssertEqual(list.Count, 2);
    Assertions.AssertEqual(list.Head?.Value, 10);
    Assertions.AssertEqual(list.Head?.Next?.Value, 20);
}, "Hint: After clearing, the list should be fully usable again.");

TestRunner.RunTest("Clear: Empty List", () =>
{
    var list = new SinglyLinkedList<int>();
    
    // Should not fail on empty list
    list.Clear();
    
    Assertions.AssertEqual(list.Count, 0);
    Assertions.AssertEqual(list.Head == null, true);
}, "Hint: Clearing an already empty list should not throw an error.");

Console.WriteLine();
Console.WriteLine("Done.");
