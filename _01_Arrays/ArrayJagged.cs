using System.Numerics;

namespace _01_Arrays;

public class ArrayJagged
{
    // TODO: Find the index of the row with the maximum sum.
    // The method accepts a jagged array 'arrJagged' (array of arrays).
    // You need to calculate the sum of elements for each row.
    // Return a Tuple<int, T> where:
    // - Item1 is the index of the row with the highest sum.
    // - Item2 is the sum itself.
    // Example:
    // Input: [[1, 1], [5, 5], [2, 2]]
    // Output: Tuple(1, 10)
    public static Tuple<int, T>? MaxRowIndexSum<T>(T[][] arrJagged) where T : INumber<T>
    {
        throw new NotImplementedException();
    }

    // TODO: Find the column with the maximum sum and return its values.
    // A jagged array has rows of variable lengths. A "column" at index 'k' consists of
    // the 'k-th' element of every row that has at least 'k+1' elements.
    // 1. Calculate the sum of each column.
    // 2. Identify the column index with the highest sum.
    // 3. Return an array containing the values of that column.
    //    If a row is too short to have an element at that column index, use T.Zero.
    // Example:
    // Input: 
    // [
    //   [1, 10, 1],
    //   [2, 20]
    // ]
    // Column sums: Col 0 = 3, Col 1 = 30, Col 2 = 1.
    // Max Col Index: 1.
    // Output: [10, 20]
    public static T?[] MaxCol<T>(T[][] arrJagged) where T : INumber<T>
    {
        throw new NotImplementedException();
    }

    // TODO: Split an array of Tuples into separate rows.
    // Accept an array of Tuple<T, T, T>.
    // Return a jagged array with exactly 3 rows:
    // - Row 0: All Item1 values.
    // - Row 1: All Item2 values.
    // - Row 2: All Item3 values.
    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {
        throw new NotImplementedException();
    }

    // TODO: Zip two arrays into a single 2D array.
    // Return a 2D array [N, 2] where N is the length of the longer input array.
    // - Column 0 should contain elements from array 'a'.
    // - Column 1 should contain elements from array 'b'.
    // If one array is shorter than the other, fill the missing spots with default(T) (e.g. 0).
    public static T?[,]? Zip<T>(T[] a, T[] b)
    {        
        throw new NotImplementedException();
    }
}