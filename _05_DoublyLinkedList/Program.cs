﻿using DoublyLinkedList;
using AlgorithmTestFramework;

Console.WriteLine("--- Doubly Linked List Exercise Runner --- \n");

// --- Basic Operations Tests ---
Console.WriteLine("Testing Basic Operations (AddFirst, AddLast, Count)...");

TestRunner.RunTest("AddFirst: Add to Empty and Non-Empty", () =>
{
    var list = new DoublyLinkedList<int>();
    Assertions.AssertEqual(list.Count, 0);

    list.AddFirst(10);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.First?.Value, 10);
    Assertions.AssertEqual(list.Last?.Value, 10); // First == Last

    list.AddFirst(5);
    Assertions.AssertEqual(list.Count, 2);
    Assertions.AssertEqual(list.First?.Value, 5);
    Assertions.AssertEqual(list.First?.Next?.Value, 10); // Forward link
    Assertions.AssertEqual(list.First?.Next?.Previous?.Value, 5); // Backward link verification
}, "Hint: Ensure Previous and Next pointers are correctly updated when inserting at Head.");

TestRunner.RunTest("AddLast: Add to Empty and Non-Empty", () =>
{
    var list = new DoublyLinkedList<int>();
    
    list.AddLast(10);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.First?.Value, 10);
    Assertions.AssertEqual(list.Last?.Value, 10);

    list.AddLast(20);
    Assertions.AssertEqual(list.Count, 2);
    Assertions.AssertEqual(list.Last?.Value, 20);
    Assertions.AssertEqual(list.Last?.Previous?.Value, 10); // Backward link
    Assertions.AssertEqual(list.Last?.Previous?.Next?.Value, 20); // Forward verification
}, "Hint: Ensure Previous pointer of new node points to old Tail.");


// --- Enumeration Tests ---
Console.WriteLine("\nTesting Enumeration...");

TestRunner.RunTest("GetEnumerator: Foreach Support", () =>
{
    var list = new DoublyLinkedList<int>();
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
});


// --- Removal Tests ---
Console.WriteLine("\nTesting Remove...");

TestRunner.RunTest("Remove: Head", () =>
{
    var list = new DoublyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    
    bool removed = list.Remove(1);
    
    Assertions.AssertEqual(removed, true);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.First?.Value, 2);
    Assertions.AssertEqual(list.First?.Previous == null, true); // New head should have no Previous
}, "Hint: Determine if Head needs valid Previous reference (usually null).");

TestRunner.RunTest("Remove: Tail", () =>
{
    var list = new DoublyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);

    bool removed = list.Remove(2);
    
    Assertions.AssertEqual(removed, true);
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.Last?.Value, 1);
    Assertions.AssertEqual(list.Last?.Next == null, true); // New tail should have no Next
}, "Hint: Update Last pointer and ensure old previous node has Next=null.");

TestRunner.RunTest("Remove: Middle", () =>
{
    var list = new DoublyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    list.AddLast(3); 
    
    bool removed = list.Remove(2); // Remove 2
    Assertions.AssertEqual(removed, true);
    Assertions.AssertEqual(list.Count, 2);
    
    // Check integrity: 1 <-> 3
    Assertions.AssertEqual(list.First?.Value, 1);
    Assertions.AssertEqual(list.First?.Next?.Value, 3);
    Assertions.AssertEqual(list.Last?.Value, 3);
    Assertions.AssertEqual(list.Last?.Previous?.Value, 1);
}, "Hint: Link current.Previous.Next to current.Next AND current.Next.Previous to current.Previous.");

TestRunner.RunTest("Delete: Node Reference (Tail)", () =>
{
    var list = new DoublyLinkedList<int>();
    list.AddLast(10);
    list.AddLast(20);
    
    var tailNode = list.Last;
    // Assuming Delete is public and available on class
    list.Delete(tailNode);
    
    Assertions.AssertEqual(list.Count, 1);
    Assertions.AssertEqual(list.Last?.Value, 10);
});

// --- Search/Contains Tests ---
Console.WriteLine("\nTesting Search & Contains...");

TestRunner.RunTest("Search: Find Existing Node", () =>
{
    // Manually construct: 10 <-> 20 <-> 30
    var node10 = new DoubleNode<int>(10);
    var node20 = new DoubleNode<int>(20);
    var node30 = new DoubleNode<int>(30);
    
    node10.Next = node20;
    node20.Previous = node10;
    node20.Next = node30;
    node30.Previous = node20;
    
    var list = new DoublyLinkedList<int>();
    list.First = node10;
    list.Last = node30;
    
    var found = list.Search(20);
    Assertions.AssertEqual(found != null, true);
    Assertions.AssertEqual(found?.Value, 20);
    Assertions.AssertEqual(found?.Previous?.Value, 10);
    Assertions.AssertEqual(found?.Next?.Value, 30);
});

TestRunner.RunTest("Search: Non-Existent Value Returns Null", () =>
{
    // Manually construct: 10 <-> 20
    var node10 = new DoubleNode<int>(10);
    var node20 = new DoubleNode<int>(20);
    
    node10.Next = node20;
    node20.Previous = node10;
    
    var list = new DoublyLinkedList<int>();
    list.First = node10;
    list.Last = node20;
    
    var notFound = list.Search(99);
    Assertions.AssertEqual(notFound == null, true);
});

TestRunner.RunTest("Search: Empty List Returns Null", () =>
{
    var list = new DoublyLinkedList<int>();
    var result = list.Search(10);
    Assertions.AssertEqual(result == null, true);
});

TestRunner.RunTest("Contains: Basic", () =>
{
    // Manually construct: "A" <-> "B"
    var nodeA = new DoubleNode<string>("A");
    var nodeB = new DoubleNode<string>("B");
    
    nodeA.Next = nodeB;
    nodeB.Previous = nodeA;
    
    var list = new DoublyLinkedList<string>();
    list.First = nodeA;
    list.Last = nodeB;
    
    Assertions.AssertEqual(list.Contains("B"), true);
    Assertions.AssertEqual(list.Contains("Z"), false);
});


// --- AddSorted Tests ---
Console.WriteLine("\nTesting AddSorted...");

TestRunner.RunTest("AddSorted: Insert at Head", () =>
{
    var list = new DoublyLinkedList<int>();
    list.AddSorted(20);
    list.AddSorted(10); // Should go before 20
    
    // Check order 10 -> 20
    Assertions.AssertEqual(list.First?.Value, 10);
    Assertions.AssertEqual(list.First?.Next?.Value, 20);
    // Check backward 20 -> 10
    Assertions.AssertEqual(list.Last?.Value, 20);
    Assertions.AssertEqual(list.Last?.Previous?.Value, 10);
});

TestRunner.RunTest("AddSorted: Insert in Middle", () =>
{
    var list = new DoublyLinkedList<int>();
    list.AddSorted(10);
    list.AddSorted(30);
    list.AddSorted(20); // 10 <-> 20 <-> 30
    
    Assertions.AssertEqual(list.Count, 3);
    // Check 20's links
    var mid = list.First?.Next;
    Assertions.AssertEqual(mid?.Value, 20);
    Assertions.AssertEqual(mid?.Previous?.Value, 10);
    Assertions.AssertEqual(mid?.Next?.Value, 30);
});


// --- Clear Tests ---
Console.WriteLine("\nTesting Clear...");
TestRunner.RunTest("Clear: Reset List", () =>
{
    var list = new DoublyLinkedList<int>();
    list.AddLast(1);
    list.AddLast(2);
    
    list.Clear();
    
    Assertions.AssertEqual(list.Count, 0); 
    Assertions.AssertEqual(list.First == null, true);
    Assertions.AssertEqual(list.Last == null, true);
});

Console.WriteLine();
Console.WriteLine("Done.");
