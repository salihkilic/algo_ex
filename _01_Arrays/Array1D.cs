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
        T? result = _data[0];
        for (int i = 1; i < _data.Count(); i++)
        {
            result = fx(result, _data[i]);
        }
        return result;
    }

    // TODO: Find the maximum value in the array.
    // Iterate through the array and keep track of the largest element found so far.
    public T? Max()
    {
        var result = _data[0];
        for (int i = 1; i < _data.Count(); i++)
        {
            if (_data[i] > result)
                result = _data[i];
        }
        return result;
    }

    // TODO: Find the minimum value in the array.
    // Iterate through the array and keep track of the smallest element found so far.
    public T? Min()
    {
        var result = _data[0];
        for (int i = 1; i < _data.Count(); i++)
        {
            if (_data[i] < result)
                result = _data[i];
        }
        return result;
    }

    // TODO: Calculate the product of all elements in the array.
    // The 'IgnoreZeros' parameter determines how to handle zero values.
    // If IgnoreZeros is false, a single zero makes the entire product zero.
    // If IgnoreZeros is true, skip zero values (treat them as 1).
    public T? Product(bool IgnoreZeros = true)
    {
        var result = _data[0];
        for (int i = 1; i < _data.Count(); i++)
        {
            if (IgnoreZeros && _data[i] == default(T))
                continue;
           result *= _data[i];
        }
        return result;
    }

    // TODO: Calculate the sum of all elements in the array.
    // Iterate through the array and add each element to a running total.
    public T? Sum()
    {
        var result = _data[0];
        for (int i = 1; i < _data.Count(); i++)
        {
            result += _data[i];
        }
        return result;
    }
}