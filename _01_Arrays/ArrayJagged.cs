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
        Tuple<int,T> result = Tuple.Create(0, T.Zero);
        
        for (int x = 0; x < arrJagged.Length; x++)
        {
            // Get rowsum
            var rowSum = T.Zero;
            for (int y = 0; y < arrJagged[x].Length; y++)
            {
                rowSum += arrJagged[x][y];
            }

            // Check result for max
            if (rowSum > result.Item2)
            {
                result = Tuple.Create(x, rowSum);
            }
        }
        return result;
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
        // Find the longest row
        int longest = 0;
        for (int x = 0; x < arrJagged.Length; x++)
        {
            int currentRowLength = arrJagged[x].Length;
            if (currentRowLength > longest)
            {
                longest = currentRowLength;
            }
        }

        // Get the sums
        T[] highScores = new T[longest];
        for (int x = 0; x < arrJagged.Length; x++)
        {
            for (int y = 0; y < arrJagged[x].Length; y++)
            {
                highScores[y] += arrJagged[x][y];
            }
        }

        // Find highest sum
        int colIndex = 0;
        T highestScore = T.Zero;
        for (int x = 0; x < highScores.Length; x++)
        {
            if (highScores[x] > highestScore)
            {
                highestScore = highScores[x];
                colIndex = x;
            }
        }

        // Return the values of that col
        T[] results = new T[arrJagged.Length];

        for (int x = 0; x < results.Length; x++)
        {
            if (arrJagged[x].Length <= x)
            {
                results[x] = T.Zero;
                continue;
            }
            results[x] = arrJagged[x][colIndex] ;
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
        int length = input.Length;
        T[][] arr = new T[3][];

        for (int x = 0; x < arr.Length; x++)
        {
            arr[x] = new T[input.Length];
        }

        for (int x = 0; x < input.Length; x++)
        {
            arr[0][x] = input[x].Item1;
            arr[1][x] = input[x].Item2;
            arr[2][x] = input[x].Item3;
        }
        return arr;
    }

    // TODO: Zip two arrays into a single 2D array.
    // Return a 2D array [N, 2] where N is the length of the longer input array.
    // - Column 0 should contain elements from array 'a'.
    // - Column 1 should contain elements from array 'b'.
    // If one array is shorter than the other, fill the missing spots with default(T) (e.g. 0).
    public static T[,]? Zip<T>(T[] a, T[] b)
    {        
        int longest = a.Length > b.Length ? a.Length : b.Length;
        T[,] result = new T[longest,2];

        for (int x = 0; x < longest; x++)
        {
            var value1 = x < a.Length ? a[x] : default!;
            var value2 = x < b.Length ? b[x] : default!;

            result[x,0] = value1;
            result[x,1] = value2;
        }
        return result;
    }
}