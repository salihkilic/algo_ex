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
        
        var item = _data[0];
        for (int i = 1; i < _data.Length; i++)
        {
            item = fx(item, _data[i]);
        }

        return item;
    }

    // TODO: Find the maximum value in the array.
    // Iterate through the array and keep track of the largest element found so far.
    public T? Max()
    {
        if (_data.Length == 0) return default;
        
        var currentMax = _data[0];
        foreach (var item in _data)
        {
            if (item > currentMax)
                currentMax = item;
        }

        return currentMax;
    }

    // TODO: Find the minimum value in the array.
    // Iterate through the array and keep track of the smallest element found so far.
    public T? Min()
    {
        if (_data.Length == 0) return default;
        
        var currentMin = _data[0];
        foreach (var item in _data)
        {
            if (item < currentMin)
                currentMin = item;
        }

        return currentMin;
    }

    // TODO: Calculate the product of all elements in the array.
    // The 'IgnoreZeros' parameter determines how to handle zero values.
    // If IgnoreZeros is false, a single zero makes the entire product zero.
    // If IgnoreZeros is true, skip zero values (treat them as 1).
    public T? Product(bool IgnoreZeros = true)
    {
        if (_data.Length == 0) return default;

        var value = T.One;
        
        foreach (var t in _data)
        {
            if (t.CompareTo(T.Zero) == 0  && IgnoreZeros)
                continue;
            value *= t;
        }

        return value;
    }

    // TODO: Calculate the sum of all elements in the array.
    // Iterate through the array and add each element to a running total.
    public T? Sum()
    {
        var currentSum = T.Zero;

        foreach (var item in _data)
        {
            currentSum += item;
        }

        return currentSum;
    }
}