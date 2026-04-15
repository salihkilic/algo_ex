namespace _06_Stack;


public class Stack<T> : IStack<T>
{
    private T[] _items;
    private int _capacity;
    private int _topIndex = -1;
    
    // TODO: Return true if the stack is empty (no elements), otherwise false.
    public bool Empty => _topIndex == -1;

    // TODO: Return true if the internal array is full (reached capacity), otherwise false.
    public bool Full => Count == _capacity;

    // TODO: Return the number of elements currently in the stack.
    public int Count => _topIndex + 1;

    // TODO: Return the current capacity (total size) of the internal array.
    public int Size => _capacity;
    

    // TODO: Initialize the stack with a specified initial size.
    public Stack(int size = 4)
    {
        _capacity = size;
        _items = new T[_capacity];
    }

    // TODO: Return the item at the top of the stack without removing it.
    // If the stack is empty, return the default value for type T.
    public T? Peek()
    {
        return _topIndex != -1 ? _items[_topIndex] : default;
    }

    // TODO: Remove and return the item at the top of the stack.
    // If the stack is empty, return the default value for type T.
    // Ensure the top index is updated.
    public T? Pop()
    {
        return _topIndex != -1 ? _items[_topIndex--] : default;
    }

    // TODO: Push an item onto the top of the stack.
    // 1. If the stack is not full, add the item and increment the top index.
    // 2. If the stack IS full, create a larger array (e.g., +1 size or double), copy existing items, and then add the new item.
    public void Push(T item)
    {
        // Array is not full
        if (!Full)
        {
            _items[++_topIndex] = item;
            return;
        }
        
        // Array is full
        var newArray = new T[++_capacity];
        for (int i = 0; i < _capacity - 1; i++)
        {
            newArray[i] = _items[i];
        }

        _items = newArray;
        _items[++_topIndex] = item;
    }
}
