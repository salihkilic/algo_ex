using System.Numerics;

namespace _01_Arrays;

public class NumArray1D<T> where T : IComparable<T>, INumber<T>
{
    private T[] _data;

    public NumArray1D(int size = 10) 
    {
        _data = new T[size];
    }
    
    public NumArray1D(T[] data) 
    { 
        _data = data;
    }
  
    // TODO: Implement a generic aggregation method.
    // This method takes a function 'fx' that defines how to combine two elements of type T.
    // It should traverse the array and apply this function to accumulate a result.
    // Example: Aggregate((a, b) => a + b) should result in the Sum of the array.
    public T? Aggregate(Func<T, T, T> fx)
    {
        if (_data.Length == 0) return default;
        
        var acc = _data[0];

        for (int x = 1; x < _data.Length; x++)
        {
            acc = fx(acc, _data[x]);
        }
        return acc;
    }

    // TODO: Find the maximum value in the array.
    // Iterate through the array and keep track of the largest element found so far.
    public T? Max()
    {
        if (_data.Length == 0) return default;
        
        var result = _data[0];

        for (int x = 1; x < _data.Length; x++)
        {
            if (_data[x] > result)
                result = _data[x];
        }
        return result;
    }

    // TODO: Find the minimum value in the array.
    // Iterate through the array and keep track of the smallest element found so far.
    public T? Min()
    {
        if (_data.Length == 0) return default;
        
        var result = _data[0];

        for (int x = 1; x < _data.Length; x++)
        {
            if (_data[x] < result)
                result = _data[x];
        }
        return result;
    }

    // TODO: Calculate the product of all elements in the array.
    // The 'IgnoreZeros' parameter determines how to handle zero values.
    // If IgnoreZeros is false, a single zero makes the entire product zero.
    // If IgnoreZeros is true, skip zero values (treat them as 1).
    public T? Product(bool IgnoreZeros = true)
    {
        if (_data.Length == 0) return T.One; // Empty product is 1

        var result = T.One;
        bool hasNonZero = false;

        for (int x = 0; x < _data.Length; x++)
        {
            if (T.IsZero(_data[x]))
            {
                if (!IgnoreZeros) return T.Zero;
            }
            else
            {
                result *= _data[x];
                hasNonZero = true;
            }
        }
        
        // Edge case: If array was all zeros and IgnoreZeros=true, returning 1 is technically correct for "product of elements excluding zeros".
        return result;
    }

    // TODO: Calculate the sum of all elements in the array.
    // Iterate through the array and add each element to a running total.
    public T? Sum()
    {
        var result = T.Zero;

        for (int x = 0; x < _data.Length; x++)
        {
            result += _data[x];
        }
        return result;
    }
}