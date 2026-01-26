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
        var arrX = arr2D.GetLength(0);
        var arrY = arr2D.GetLength(1);
        T[] results = new T[arrX];
        
        for (int x = 0; x < arrX; x++)
        {
            for (int y = 0; y < arrY; y++)
            {
                results[x] += arr2D[x,y];
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
        var arrX = arr2D.GetLength(0);
        var arrY = arr2D.GetLength(1);
        T[] results = new T[arrY];
        
        for (int x = 0; x < arrY; x++)
        {
            for (int y = 0; y < arrX; y++)
            {
                results[x] += arr2D[y,x];
            }
        }
        return results;
    }
}