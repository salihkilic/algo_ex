using _01_Arrays;
using AlgorithmTestFramework;

Console.WriteLine("--- Array Algorithms Exercise Runner --- \n");

// --- Sum Tests ---
Console.WriteLine("Testing Sum...");
TestRunner.RunTest("Sum: Positive Integers", () =>
{
    int[] data = [1, 2, 3, 4, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 15;
    Assertions.AssertEqual(arr.Sum(), expected);
}, "Hint: Ensure you are initializing the sum (usually to 0) and adding every element.");

TestRunner.RunTest("Sum: With Negatives", () =>
{
    int[] data = [-10, 5, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 0;
    Assertions.AssertEqual(arr.Sum(), expected);
});

// --- Product Tests ---
Console.WriteLine("\nTesting Product...");
TestRunner.RunTest("Product: Small Integers", () =>
{
    int[] data = [2, 3, 4];
    var arr = new NumArray1D<int>(data);
    long expected = 24;
    // We can use long for NumArray1D? No, T is int.
    // If we use NumArray1D<int>, result is int.
    Assertions.AssertEqual(arr.Product(), (int)expected);
}, "Hint: Initialize product to 1 (identity).");

TestRunner.RunTest("Product: Ignore Zeros (Default)", () =>
{
    int[] data = [2, 0, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 10;
    Assertions.AssertEqual(arr.Product(IgnoreZeros: true), expected);
}, "Hint: When IgnoreZeros is true, skip '0' values.");

TestRunner.RunTest("Product: Include Zeros", () =>
{
    int[] data = [2, 0, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 0;
    Assertions.AssertEqual(arr.Product(IgnoreZeros: false), expected);
}, "Hint: When IgnoreZeros is false, a single '0' should make the result 0.");

// --- Max/Min Tests ---
Console.WriteLine("\nTesting Min/Max...");
TestRunner.RunTest("Max: Standard", () =>
{
    int[] data = [10, 50, 30];
    var arr = new NumArray1D<int>(data);
    int expected = 50;
    Assertions.AssertEqual(arr.Max(), expected);
}, "Hint: Initialize max with the first element, then compare with others.");

TestRunner.RunTest("Min: Negatives", () =>
{
    double[] data = [-1.5, -5.5, -0.5];
    var arr = new NumArray1D<double>(data);
    double expected = -5.5;
    Assertions.AssertEqual(arr.Min(), expected);
}, "Hint: Initialize min with the first element. Be careful with 0 or high default values.");

// --- Aggregate Tests ---
Console.WriteLine("\nTesting Aggregate...");
TestRunner.RunTest("Aggregate: Sum Lambda", () =>
{
    int[] data = [1, 2, 3];
    var arr = new NumArray1D<int>(data);
    int expected = 6;
    int result = arr.Aggregate((a, b) => a + b);
    Assertions.AssertEqual(result, expected);
}, "Hint: The 'fx' function takes accumulated value and current value.");

TestRunner.RunTest("Aggregate: Max Lambda", () =>
{
    int[] data = [1, 5, 2];
    var arr = new NumArray1D<int>(data);
    int expected = 5;
    int result = arr.Aggregate((a, b) => a > b ? a : b);
    Assertions.AssertEqual(result, expected);
});

Console.WriteLine();
Console.WriteLine("Done.");

