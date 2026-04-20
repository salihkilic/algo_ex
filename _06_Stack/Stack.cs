namespace _06_Stack;


public class Stack<T> : IStack<T>
{
    private int _topIndex = -1;
    private T[] _data;
    
    // TODO: Return true if the stack is empty (no elements), otherwise false.
    public bool Empty => Count == 0;

    // TODO: Return true if the internal array is full (reached capacity), otherwise false.
    public bool Full => Count == Size; 

    // TODO: Return the number of elements currently in the stack.
    public int Count => _topIndex + 1; 

    // TODO: Return the current capacity (total size) of the internal array.
    public int Size => _data.Length;

    // TODO: Initialize the stack with a specified initial size.
    public Stack(int size = 4)
    {
        _data = new T[size];
    }

    // TODO: Return the item at the top of the stack without removing it.
    // If the stack is empty, return the default value for type T.
    public T? Peek()
    {
        if (Empty) return default;

        return _data[_topIndex];
    }

    // TODO: Remove and return the item at the top of the stack.
    // If the stack is empty, return the default value for type T.
    // Ensure the top index is updated.
    public T? Pop()
    {
        return Empty ? default : _data[_topIndex--];
    }

    // TODO: Push an item onto the top of the stack.
    // 1. If the stack is not full, add the item and increment the top index.
    // 2. If the stack IS full, create a larger array (e.g., +1 size or double), copy existing items, and then add the new item.
    public void Push(T item)
    {
        if (Full)
        {
            var newData = new T[Size * 2];
            for (int i = 0; i < _data.Length; i++)
                newData[i] = _data[i];
            _data = newData;
        }

        _data[++_topIndex] = item;
    }
}
