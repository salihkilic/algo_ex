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
        if (arrJagged.Length == 0) return null;

        var maxIndex = 0;
        var maxValue = T.Zero;
        
        // Calculate first row to avoid dealing with negative values
        foreach (var number in arrJagged[0])
        {
            maxValue += number;
        }

        for (var i = 1; i < arrJagged.Length; i++)
        {
            var total = T.Zero;
            foreach (var number in arrJagged[i])
            {
                total += number;
            }

            if (total > maxValue)
            {
                maxIndex = i;
                maxValue = total;
            }
        }

        return new Tuple<int, T>(maxIndex, maxValue);
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
        // Find longest col
        var longestRow = 0;
        foreach (var row in arrJagged)
        {
            if (row.Length > longestRow) 
                longestRow = row.Length;
        }
        
        // Calculate all sums
        var sums = new T[longestRow];
        for (int i = 0; i < arrJagged.Length; i++)
        {
            for (int j = 0; j < arrJagged[i].Length; j++)
            {
                sums[j] += arrJagged[i][j];
            }
        }

        // Find highest value in sums
        var maxIndex = 0;
        var maxValue = T.Zero;
        for (int i=0; i < sums.Length; i++)
        {
            if (sums[i] > maxValue)
            {
                maxValue = sums[i];
                maxIndex = i;
            }
        }

        // Find the values of that col and return
        var results = new T?[arrJagged.Length];

        for (int i = 0; i < arrJagged.Length; i++)
        {
            if (arrJagged[i].Length < maxIndex + 1)
                results[i] = T.Zero;
            else
                results[i] = arrJagged[i][maxIndex];
        }

        return results;
    }

    // TODO: Split an array of Tuples into separate rows.
    // Accept an array of Tuple<T, T, T>.
    // Return a jagged array with exactly 3 rows:
    // - Row 0: All Item1 values.
    // - Row 1: All Item2 values.
    // - Row 2: All Item3 values.
    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {
        var row1 = new T[input.Length];
        var row2 = new T[input.Length];
        var row3 = new T[input.Length];

        var index = 0;
        foreach (var tuple in input)
        {
            row1[index] = tuple.Item1;
            row2[index] = tuple.Item2;
            row3[index] = tuple.Item3;
            index++;
        }

        return [row1, row2, row3];
    }

    // TODO: Zip two arrays into a single 2D array.
    // Return a 2D array [N, 2] where N is the length of the longer input array.
    // - Column 0 should contain elements from array 'a'.
    // - Column 1 should contain elements from array 'b'.
    // If one array is shorter than the other, fill the missing spots with default(T) (e.g. 0).
    public static T?[,]? Zip<T>(T[] a, T[] b)
    {        
        // Get longest
        var longest = a.Length > b.Length 
            ? a.Length 
            : b.Length;

        var results = new T?[longest, 2];
        
        for (int i = 0; i < longest; i++)
        {
            results[i, 0] = a.Length > i
                ? a[i]
                : default;
            
            results[i, 1] = b.Length > i
                ? b[i]
                : default;
        }

        return results;

    }
}