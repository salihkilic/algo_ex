using _06_Stack;
using AlgorithmTestFramework;

Console.WriteLine("--- Stack Exercise Runner --- \n");

// --- Basic Operations Tests ---
Console.WriteLine("Testing Basic Operations (Push, Pop, Peek)...");

TestRunner.RunTest("Push & Peek: Standard", () =>
{
    var stack = new _06_Stack.Stack<int>(5);
    stack.Push(10);
    stack.Push(20);

    Assertions.AssertEqual(stack.Peek(), 20);
    Assertions.AssertEqual(stack.Count, 2);
    Assertions.AssertEqual(stack.Empty, false);
}, "Hint: Peek should return the most recently pushed item.");

TestRunner.RunTest("Pop: LIFO Order", () =>
{
    var stack = new _06_Stack.Stack<int>(5);
    stack.Push(10);
    stack.Push(20);
    stack.Push(30);

    Assertions.AssertEqual(stack.Pop(), 30);
    Assertions.AssertEqual(stack.Pop(), 20);
    Assertions.AssertEqual(stack.Pop(), 10);
    Assertions.AssertEqual(stack.Count, 0);
    Assertions.AssertEqual(stack.Empty, true);
}, "Hint: Stack is Last-In-First-Out. Pop should return items in reverse order of Push.");

// --- State Property Tests ---
Console.WriteLine("\nTesting State Properties...");

TestRunner.RunTest("Properties: Empty and Full", () =>
{
    var stack = new _06_Stack.Stack<int>(2); // Capacity 2
    Assertions.AssertEqual(stack.Empty, true);
    
    stack.Push(1);
    Assertions.AssertEqual(stack.Empty, false);
    Assertions.AssertEqual(stack.Full, false);
    
    stack.Push(2);
    Assertions.AssertEqual(stack.Full, true);
    Assertions.AssertEqual(stack.Count, 2);
    
    stack.Pop();
    Assertions.AssertEqual(stack.Full, false);
}, "Hint: Check conditions: _top == -1 for Empty, _top == capacity - 1 for Full.");


// --- Resizing Tests ---
Console.WriteLine("\nTesting Resizing...");

TestRunner.RunTest("Push: Auto-Resizing", () =>
{
    var stack = new _06_Stack.Stack<int>(2); // Start small
    stack.Push(1);
    stack.Push(2);
    
    Assertions.AssertEqual(stack.Size, 2);
    Assertions.AssertEqual(stack.Full, true);
    
    // Force resize
    stack.Push(3);
    
    Assertions.AssertEqual(stack.Count, 3);
    Assertions.AssertEqual(stack.Peek(), 3);
    
    // Size should have increased (implementation increases by 1)
    // We check if Size >= 3
    if (stack.Size < 3) 
        throw new TestFailedException($"Expected stack to resize. Size is {stack.Size}, expected >= 3");
    
}, "Hint: If stack is Full, create a new larger array and copy elements before pushing.");

TestRunner.RunTest("Push: Multiple Resizes", () =>
{
    var stack = new _06_Stack.Stack<int>(2);
    
    // Push 10 items, forcing multiple resizes
    for (int i = 1; i <= 10; i++)
    {
        stack.Push(i);
    }
    
    Assertions.AssertEqual(stack.Count, 10);
    Assertions.AssertEqual(stack.Peek(), 10);
    Assertions.AssertEqual(stack.Size >= 10, true);
}, "Hint: Stack should handle multiple consecutive resizes correctly.");

TestRunner.RunTest("Push/Pop: Consistency After Resize", () =>
{
    var stack = new _06_Stack.Stack<int>(2);
    
    // Push beyond capacity to trigger resize
    stack.Push(10);
    stack.Push(20);
    stack.Push(30);
    stack.Push(40);
    
    // Pop all and verify LIFO order is preserved
    Assertions.AssertEqual(stack.Pop(), 40);
    Assertions.AssertEqual(stack.Pop(), 30);
    Assertions.AssertEqual(stack.Pop(), 20);
    Assertions.AssertEqual(stack.Pop(), 10);
    Assertions.AssertEqual(stack.Empty, true);
}, "Hint: LIFO order must be maintained even after resize.");

TestRunner.RunTest("Push: Verify All Data Preserved After Resize", () =>
{
    var stack = new _06_Stack.Stack<int>(3);
    
    // Fill to capacity
    stack.Push(100);
    stack.Push(200);
    stack.Push(300);
    
    // Verify full
    Assertions.AssertEqual(stack.Full, true);
    
    // Push new item (triggers resize)
    stack.Push(400);
    
    // Verify all previous items are still accessible by popping in reverse order
    Assertions.AssertEqual(stack.Pop(), 400);
    Assertions.AssertEqual(stack.Pop(), 300);
    Assertions.AssertEqual(stack.Pop(), 200);
    Assertions.AssertEqual(stack.Pop(), 100);
    Assertions.AssertEqual(stack.Count, 0);
}, "Hint: Array copying during resize must preserve all existing elements correctly.");

// --- Edge Case Tests ---
Console.WriteLine("\nTesting Edge Cases...");

TestRunner.RunTest("Pop: From Empty", () =>
{
    var stack = new _06_Stack.Stack<string>(5);
    var result = stack.Pop();
    
    // Expect default (null for string)
    Assertions.AssertEqual(result, null);
}, "Hint: Return default(T) if stack is empty.");

TestRunner.RunTest("Peek: From Empty", () =>
{
    var stack = new _06_Stack.Stack<int>(5);
    var result = stack.Peek();
    
    // Expect default (0 for int)
    Assertions.AssertEqual(result, 0);
}, "Hint: Return default(T) if stack is empty.");

Console.WriteLine();
Console.WriteLine("Done.");
