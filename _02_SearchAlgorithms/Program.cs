using SearchAlgorithms;
using AlgorithmTestFramework;

Console.WriteLine("--- Search Algorithms Exercise Runner ---");
Console.WriteLine();

// Sequential Search Tests
TestRunner.RunTest("Sequential Search: Element present", () =>
{
    int[] arr = { 10, 50, 30, 70, 80, 20 };
    int target = 30;
    int expected = 2;
    // Note: SequentialSearch is static but defined in a generic class.
    // It takes int[] regardless of T, but we invoke it via SearchAlgo<int> for consistency.
    int result = SearchAlgo<int>.SequentialSearch(arr, target);
    
    Assertions.AssertEqual(result, expected);
});

TestRunner.RunTest("Sequential Search: Element not present", () =>
{
    int[] arr = { 10, 50, 30, 70, 80, 20 };
    int target = 99;
    int expected = -1;
    int result = SearchAlgo<int>.SequentialSearch(arr, target);
    
    Assertions.AssertEqual(result, expected);
});

// Binary Search Recursive Tests
TestRunner.RunTest("Binary Search (Recursive): Element present (Middle)", () =>
{
    int[] sortedArr = { 10, 20, 30, 50, 70, 80 };
    int target = 50; // Index 3
    int expected = 3;
    
    int result = SearchAlgo<int>.BinarySearchRecursive(sortedArr, target, 0, sortedArr.Length - 1);
    
    Assertions.AssertEqual(result, expected);
});

TestRunner.RunTest("Binary Search (Recursive): Element present (Low end)", () =>
{
    int[] sortedArr = { 10, 20, 30, 50, 70, 80 };
    int target = 10; // Index 0
    int expected = 0;
    
    int result = SearchAlgo<int>.BinarySearchRecursive(sortedArr, target, 0, sortedArr.Length - 1);
    
    Assertions.AssertEqual(result, expected);
});

TestRunner.RunTest("Binary Search (Recursive): Element present (High end)", () =>
{
    int[] sortedArr = { 10, 20, 30, 50, 70, 80 };
    int target = 80; // Index 5
    int expected = 5;
    
    int result = SearchAlgo<int>.BinarySearchRecursive(sortedArr, target, 0, sortedArr.Length - 1);
    
    Assertions.AssertEqual(result, expected);
});

TestRunner.RunTest("Binary Search (Recursive): Element not present", () =>
{
    int[] sortedArr = { 10, 20, 30, 50, 70, 80 };
    int target = 25;
    int expected = -1;
    
    int result = SearchAlgo<int>.BinarySearchRecursive(sortedArr, target, 0, sortedArr.Length - 1);
    
    Assertions.AssertEqual(result, expected);
});

TestRunner.RunTest("Binary Search (Recursive): Works with Strings", () =>
{
    string[] sortedArr = { "apple", "banana", "cherry", "date", "elderberry" };
    string target = "cherry";
    int expected = 2;
    
    int result = SearchAlgo<string>.BinarySearchRecursive(sortedArr, target, 0, sortedArr.Length - 1);
    
    Assertions.AssertEqual(result, expected);
});

Console.WriteLine();
Console.WriteLine("Done.");

