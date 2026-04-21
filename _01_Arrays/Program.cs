using _01_Arrays;
using AlgorithmTestFramework;

Console.WriteLine("--- Array Algorithms Exercise Runner --- \n");

// --- Sum Tests ---
Console.WriteLine("Testing Sum...");

// Test 1: Standard Sum
// Purpose: Checks if the algorithm correctly iterates and accumulates values.
TestRunner.RunTest("Sum: Positive Integers", () =>
{
    int[] data = [1, 2, 3, 4, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 15;
    Assertions.AssertEqual(arr.Sum(), expected);
}, "Hint: Ensure you are initializing the sum (usually to 0) and adding every element.");

// Test 2: Sum with Negatives
// Purpose: Ensures the algorithm handles negative numbers correctly (not just absolute values).
TestRunner.RunTest("Sum: With Negatives", () =>
{
    int[] data = [-10, 5, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 0;
    Assertions.AssertEqual(arr.Sum(), expected);
});

// --- Product Tests ---
Console.WriteLine("\nTesting Product...");

// Test 3: Standard Product
// Purpose: Checks basic multiplication accumulation.
TestRunner.RunTest("Product: Small Integers", () =>
{
    int[] data = [2, 3, 4];
    var arr = new NumArray1D<int>(data);
    long expected = 24;
    // We can use long for NumArray1D? No, T is int.
    // If we use NumArray1D<int>, result is int.
    Assertions.AssertEqual(arr.Product(), (int)expected);
}, "Hint: Initialize product to 1 (identity).");

// Test 4: Product Ignore Zeros
// Purpose: Verifies the logic to skip zeros when the flag is true.
TestRunner.RunTest("Product: Ignore Zeros (Default)", () =>
{
    int[] data = [2, 0, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 10;
    Assertions.AssertEqual(arr.Product(IgnoreZeros: true), expected);
}, "Hint: When IgnoreZeros is true, skip '0' values.");

// Test 5: Product Include Zeros
// Purpose: Verifies that a zero wipes out the product when the flag is false.
TestRunner.RunTest("Product: Include Zeros", () =>
{
    int[] data = [2, 0, 5];
    var arr = new NumArray1D<int>(data);
    int expected = 0;
    Assertions.AssertEqual(arr.Product(IgnoreZeros: false), expected);
}, "Hint: When IgnoreZeros is false, a single '0' should make the result 0.");

// --- Max/Min Tests ---
Console.WriteLine("\nTesting Min/Max...");

// Test 6: Standard Max
// Purpose: Checks finding the largest element.
TestRunner.RunTest("Max: Standard", () =>
{
    int[] data = [10, 50, 30];
    var arr = new NumArray1D<int>(data);
    int expected = 50;
    Assertions.AssertEqual(arr.Max(), expected);
}, "Hint: Initialize max with the first element, then compare with others.");

// Test 6b: Max with All Negative
// Purpose: Ensures Max() works correctly when all values are negative.
// If initialized to 0, it would return 0 instead of the actual maximum.
TestRunner.RunTest("Max: All Negative", () =>
{
    int[] data = [-10, -50, -30];
    var arr = new NumArray1D<int>(data);
    int expected = -10;
    Assertions.AssertEqual(arr.Max(), expected);
}, "Hint: Initialize max with the first element, not with a default value like 0.");

// Test 7: Min with Negatives
// Purpose: Edge case. If initialized to 0, it might return 0 instead of a negative min.
TestRunner.RunTest("Min: Negatives", () =>
{
    double[] data = [-1.5, -5.5, -0.5];
    var arr = new NumArray1D<double>(data);
    double expected = -5.5;
    Assertions.AssertEqual(arr.Min(), expected);
}, "Hint: Initialize min with the first element. Be careful with 0 or high default values.");

// Test 8: Min with All Positive
// Purpose: Ensures Min() works correctly when all values are positive.
// If initialized to 0, it would return 0 instead of the actual minimum.
TestRunner.RunTest("Min: All Positive", () =>
{
    int[] data = [10, 50, 30];
    var arr = new NumArray1D<int>(data);
    int expected = 10;
    Assertions.AssertEqual(arr.Min(), expected);
}, "Hint: Initialize min with the first element, not with a default value like 0.");

// --- Aggregate Tests ---
Console.WriteLine("\nTesting Aggregate...");

// Test 9: Aggregate Sum
// Purpose: Verify the generic accumulation logic works with a custom addition lambda.
TestRunner.RunTest("Aggregate: Sum Lambda", () =>
{
    int[] data = [1, 2, 3];
    var arr = new NumArray1D<int>(data);
    int expected = 6;
    int result = arr.Aggregate((a, b) => a + b);
    Assertions.AssertEqual(result, expected);
}, "Hint: The 'fx' function takes accumulated value and current value.");

// Test 10: Aggregate Max
// Purpose: Verify the comparison logic works within the generic aggregate function.
TestRunner.RunTest("Aggregate: Max Lambda", () =>
{
    int[] data = [1, 5, 2];
    var arr = new NumArray1D<int>(data);
    int expected = 5;
    int result = arr.Aggregate((a, b) => a > b ? a : b);
    Assertions.AssertEqual(result, expected);
});

// --- 2D Array Tests ---
Console.WriteLine("\nTesting Array2D...");

// Test 1: Standard Non-Square Matrix (2x3)
// Purpose: Ensures loops handle row vs column counts correctly.
// If your inner/outer loops use the wrong length (e.g. using rows count for columns), this will fail or crash.
TestRunner.RunTest("RowSum: 2x3 Matrix", () =>
{
    // 1 2 3
    // 4 5 6
    int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 } };
    int[] expected = [6, 15];
    var result = Array2D.RowSum(matrix);
    Assertions.AssertSorted(result, expected);
}, "Hint: Iterate through each row and sum its columns.");

// Test 2: Standard Non-Square Matrix (2x3) for Columns
// Purpose: Verifies column-major traversal.
TestRunner.RunTest("ColSum: 2x3 Matrix", () =>
{
    // 1 2 3
    // 4 5 6
    int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 } };
    int[] expected = [5, 7, 9];
    var result = Array2D.ColSum(matrix);
    Assertions.AssertSorted(result, expected);
}, "Hint: Iterate through each column and sum its rows. Watch your indices [row, col] vs loops.");

// Test 3: Single Row Matrix
// Purpose: Edge Case. Ensures the logic works when there is no "next" row.
TestRunner.RunTest("RowSum: Single Row", () =>
{
    int[,] matrix = { { 10, 20, 30 } };
    int[] expected = [60];
    var result = Array2D.RowSum(matrix);
    Assertions.AssertSorted(result, expected);
});

// Test 4: Single Column Matrix
// Purpose: Edge Case. Ensures the logic works when there is no "next" column.
TestRunner.RunTest("ColSum: Single Column", () =>
{
    int[,] matrix = { { 10 }, { 20 }, { 30 } };
    int[] expected = [60];
    var result = Array2D.ColSum(matrix);
    Assertions.AssertSorted(result, expected);
});

// Test 5: Square Matrix
// Purpose: Control test. If Rectangular tests fail but this passes, you likely swapped Row/Column counts.
TestRunner.RunTest("RowSum: Square Matrix (Identity)", () =>
{
    int[,] matrix = { { 1, 0 }, { 0, 1 } };
    int[] expected = [1, 1];
    var result = Array2D.RowSum(matrix);
    Assertions.AssertSorted(result, expected);
});

// --- Jagged Array Tests ---
Console.WriteLine("\nTesting ArrayJagged...");

// Test 1: MaxRowIndexSum - Basic
// Purpose: Checks if the logic correctly identifies the row with the largest sum.
TestRunner.RunTest("MaxRowIndexSum: Basic", () =>
{
    // Row 0: 2
    // Row 1: 10
    // Row 2: 4
    int[][] jagged = 
    [
        [1, 1],
        [5, 5], 
        [2, 2]
    ];
    var result = ArrayJagged.MaxRowIndexSum(jagged);
    if (result == null) throw new TestFailedException("Result was null");
    // Expect Row 1, Sum 10
    Assertions.AssertEqual(result.Item1, 1);
    Assertions.AssertEqual(result.Item2, 10);
}, "Hint: Sum each row individually and compare against the max found so far.");

// Test 2: MaxRowIndexSum - Variable Lengths
// Purpose: Ensures it handles rows of different lengths correctly.
TestRunner.RunTest("MaxRowIndexSum: Variable Lengths", () =>
{
    // Row 0: 10
    // Row 1: 15
    // Row 2: 20 -> Winner
    int[][] jagged = 
    [
        [10],
        [5, 5, 5], 
        [20]
    ];
    var result = ArrayJagged.MaxRowIndexSum(jagged);
    if (result == null) throw new TestFailedException("Result was null");
    Assertions.AssertEqual(result.Item1, 2);
    Assertions.AssertEqual(result.Item2, 20);
});

// Test 3: MaxCol - Basic
// Purpose: Checks column-wise summing and returning the winning column.
TestRunner.RunTest("MaxCol: Basic", () =>
{
    // Col 0: 2
    // Col 1: 30 -> Winner
    int[][] jagged = 
    [
        [1, 10], 
        [1, 20]
    ];
    // Expected values from Col 1: [10, 20]
    int[] expected = [10, 20];
    var result = ArrayJagged.MaxCol(jagged);
    
    // MaxCol returns int?[], but expected is int[]. We cast input expected or check result.
    // AssertSorted expects T[], MaxCol returns T?[].
    // Since T is struct (int), T? is Nullable<int>.
    // Result logic in ArrayJagged actually returns T[] (not nullable T) based on 'new T[longest]' but the signature is T?[].
    // Actually signature is T?[] MaxCol... but implementation uses T[] results = new T[...].
    // However, if T is 'int', T? is 'int?'. Implementation returns 0 for missing values.
    // Let's manually check or cast. The framework might struggle with T? vs T.
    
    // Hack: Manually check for this test since Generics variation is tricky here.
    if (result.Length != expected.Length) throw new TestFailedException("Length mismatch");
    for(int i=0; i<result.Length; i++)
        if (result[i] != expected[i]) throw new TestFailedException($"Mismatch at {i}");
    
}, "Hint: Sum columns vertically. If a row is too short for a column, treat missing value as 0.");

// Test 4: MaxCol - Sparse/Variable
// Purpose: Checks if it correctly handles "holes" (short rows) when summing columns.
TestRunner.RunTest("MaxCol: Sparse Matrix", () =>
{
    // [
    //   [1, 10, 5],
    //   [1, 20]
    // ]
    // Col 0: 2
    // Col 1: 30 -> Winner
    // Col 2: 5
    int[][] jagged = 
    [
        [1, 10, 5],
        [1, 20]
    ];
    int[] expected = [10, 20];
    var result = ArrayJagged.MaxCol(jagged);
    
    if (result.Length != expected.Length) throw new TestFailedException("Length mismatch");
    for(int i=0; i<result.Length; i++)
        if (result[i] != expected[i]) throw new TestFailedException($"Mismatch at {i}");
});

// Test 5: Split
// Purpose: Verifies splitting tuples into separate rows (Structure transformation).
TestRunner.RunTest("Split: Standard", () =>
{
    Tuple<int, int, int>[] input = 
    [
        Tuple.Create(1, 2, 3),
        Tuple.Create(4, 5, 6)
    ];
    
    int[][] expected = 
    [
        [1, 4], // ALL Item1s
        [2, 5], // ALL Item2s
        [3, 6]  // ALL Item3s
    ];
    
    var result = ArrayJagged.Split(input);
    Assertions.AssertJaggedEqual(result, expected);
}, "Hint: Create 3 rows. Row 0 gets all Item1s, Row 1 Item2s, etc.");

// Test 6: Zip - Equal Lengths
// Purpose: Verifies merging two arrays into 2D array.
TestRunner.RunTest("Zip: Equal Lengths", () =>
{
    int[] a = [1, 2];
    int[] b = [3, 4];
    
    int[,] expected = { {1, 3}, {2, 4} };
    
    var result = ArrayJagged.Zip(a, b);
    Assertions.Assert2DEqual(result, expected);
}, "Hint: Iterate up to length. Col 0 gets a[i], Col 1 gets b[i].");

// Test 7: Zip - Uneven Lengths
// Purpose: Verifies padding with default values when arrays differ in size.
TestRunner.RunTest("Zip: Uneven Lengths", () =>
{
    int[] a = [1];
    int[] b = [3, 4];
    
    // a is shorter, so padded with 0 at index 1.
    // Row 0: a[0], b[0] -> 1, 3
    // Row 1: a[1] (def), b[1] -> 0, 4
    int[,] expected = { {1, 3}, {0, 4} };
    
    var result = ArrayJagged.Zip(a, b);
    Assertions.Assert2DEqual(result, expected);
}, "Hint: Use the Loop over the LONGER array length. Check bounds before accessing a[i] or b[i].");

Console.WriteLine();
Console.WriteLine("Done.");
