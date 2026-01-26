using SortingAlgorithms;
using AlgorithmTestFramework;

Console.WriteLine("--- Sorting Algorithms Exercise Runner --- \n");

// --- Bubble Sort Tests ---
Console.WriteLine("Testing Bubble Sort...");
TestRunner.RunTest("Bubble Sort: Random Integers", () =>
{
    int[] arr = [64, 34, 25, 12, 22, 11, 90];
    int[] expected = [11, 12, 22, 25, 34, 64, 90];
    SortAlgo<int>.BubbleSort(arr);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Check your inner and outer loop bounds. Inner loop should stop at length - 1 - i (optimized) or length - 1.");

TestRunner.RunTest("Bubble Sort: Already Sorted", () =>
{
    int[] arr = [1, 2, 3, 4, 5];
    int[] expected = [1, 2, 3, 4, 5];
    SortAlgo<int>.BubbleSort(arr);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Ensure your algorithm doesn't corrupt already sorted arrays.");

TestRunner.RunTest("Bubble Sort: Reverse Sorted", () =>
{
    int[] arr = [5, 4, 3, 2, 1];
    int[] expected = [1, 2, 3, 4, 5];
    SortAlgo<int>.BubbleSort(arr);
    Assertions.AssertSorted(arr, expected);
}, "Hint: This is the worst-case scenario. Make sure every element bubbles to its correct position.");

TestRunner.RunTest("Bubble Sort: Strings", () =>
{
    string[] arr = ["banana", "apple", "cherry"];
    string[] expected = ["apple", "banana", "cherry"];
    SortAlgo<string>.BubbleSort(arr);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Use compareTo() correctly for generic types.");


// --- Insertion Sort Tests ---
Console.WriteLine("\nTesting Insertion Sort...");
TestRunner.RunTest("Insertion Sort: Random Integers", () =>
{
    int[] arr = [12, 11, 13, 5, 6];
    int[] expected = [5, 6, 11, 12, 13];
    SortAlgo<int>.InsertionSort(arr);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Check initialized key and the while loop condition (previousIndex >= 0).");

TestRunner.RunTest("Insertion Sort: Single Element", () =>
{
    int[] arr = [1];
    int[] expected = [1];
    SortAlgo<int>.InsertionSort(arr);
    Assertions.AssertSorted(arr, expected);
}, "Hint: The loop should start at index 1. Array with 1 element requires no sorting.");

TestRunner.RunTest("Insertion Sort: Duplicates", () =>
{
    int[] arr = [4, 2, 4, 1];
    int[] expected = [1, 2, 4, 4];
    SortAlgo<int>.InsertionSort(arr);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Ensure your comparison logic handles equality (>= vs >) to maintain stability (optional but good).");


// --- Merge Sort Tests ---
Console.WriteLine("\nTesting Merge Sort...");
TestRunner.RunTest("Merge Sort: Random Integers", () =>
{
    int[] arr = [38, 27, 43, 3, 9, 82, 10];
    int[] expected = [3, 9, 10, 27, 38, 43, 82];
    SortAlgo<int>.MergeSort(arr, 0, arr.Length - 1);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Check your recursion base case (low < high) and your Merge logic for combining subarrays.");

TestRunner.RunTest("Merge Sort: Odd Number of Elements", () =>
{
    int[] arr = [5, 1, 3];
    int[] expected = [1, 3, 5];
    SortAlgo<int>.MergeSort(arr, 0, arr.Length - 1);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Midpoint calculation and handling of split (mid vs mid+1) is crucial here.");

TestRunner.RunTest("Merge Sort: Large Range", () =>
{
    int[] arr = [100, -10, 0, 50, 2];
    int[] expected = [-10, 0, 2, 50, 100];
    SortAlgo<int>.MergeSort(arr, 0, arr.Length - 1);
    Assertions.AssertSorted(arr, expected);
}, "Hint: Just checking if it handles negatives and zeros correctly.");


Console.WriteLine();
Console.WriteLine("Done.");

