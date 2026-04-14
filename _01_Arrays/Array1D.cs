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
        throw new NotImplementedException();
    }

    // TODO: Find the maximum value in the array.
    // Iterate through the array and keep track of the largest element found so far.
    public T? Max()
    {
        throw new NotImplementedException();
    }

    // TODO: Find the minimum value in the array.
    // Iterate through the array and keep track of the smallest element found so far.
    public T? Min()
    {
        throw new NotImplementedException();
    }

    // TODO: Calculate the product of all elements in the array.
    // The 'IgnoreZeros' parameter determines how to handle zero values.
    // If IgnoreZeros is false, a single zero makes the entire product zero.
    // If IgnoreZeros is true, skip zero values (treat them as 1).
    public T? Product(bool IgnoreZeros = true)
    {
        throw new NotImplementedException();
    }

    // TODO: Calculate the sum of all elements in the array.
    // Iterate through the array and add each element to a running total.
    public T? Sum()
    {
        throw new NotImplementedException();
    }
}