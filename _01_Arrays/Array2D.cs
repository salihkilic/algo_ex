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
        T[]? result = new T[arr2D.GetLength(0)];
        for(int i = 0; i < arr2D.GetLength(0); i++)
        {
            T tmp = arr2D[i, 0];
            for (int j = 1; j < arr2D.GetLength(1); j++)
            {
                tmp += arr2D[i, j];
            }
            result[i] = tmp;
        }
        return result;
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
        T[]? result = new T[arr2D.GetLength(1)];
        for (int i = 0; i < arr2D.GetLength(1); i++)
        {
            T tmp = arr2D[0, i];
            for (int j = 1; j < arr2D.GetLength(0); j++)
            {
                tmp += arr2D[j, i];
            }
            result[i] = tmp;
        }
        return result;
    }
}