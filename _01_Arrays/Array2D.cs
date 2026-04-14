using System.Numerics;

namespace _01_Arrays;

public class Array2D
{
    // TODO: Calculate the sum of each row in the 2D array.
    // The input 'arr2D' is a two-dimensional array [Rows, Cols].
    // You need to return a 1D array where the element at index 'i' corresponds to the sum of the 'i-th' row.
    // Example:
    // Input: {{1, 2}, {3, 4}}
    // Output: {3, 7}
    public static T[]? RowSum<T>(T[,] arr2D) where T : INumber<T>
    {
        var rowCount = arr2D.GetLength(0);
        var colCount = arr2D.GetLength(1);

        var results = new T[rowCount];
        
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                results[i] += arr2D[i, j];
            }
        }

        return results;
    }
    
    // TODO: Calculate the sum of each column in the 2D array.
    // The input 'arr2D' is a two-dimensional array [Rows, Cols].
    // You need to return a 1D array where the element at index 'j' corresponds to the sum of the 'j-th' column.
    // Example:
    // Input: {{1, 2},
    //         {3, 4}}
    //
    // Output: {4, 6}
    public static T[]? ColSum<T>(T[,] arr2D) where T : INumber<T>
    {
        var rowCount = arr2D.GetLength(0);
        var colCount = arr2D.GetLength(1);

        var results = new T[colCount];
        
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                results[j] += arr2D[i, j];
            }
        }

        return results;
    }
}
