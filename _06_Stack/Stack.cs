namespace _06_Stack;


public class Stack<T> : IStack<T>
{
    // TODO: Return true if the stack is empty (no elements), otherwise false.
    public bool Empty => _top == -1;

    // TODO: Return true if the internal array is full (reached capacity), otherwise false.
    public bool Full => _top == _capacity -1;

    // TODO: Return the number of elements currently in the stack.
    public int Count => _top + 1;

    // TODO: Return the current capacity (total size) of the internal array.
    public int Size => _capacity;

    private T[] _stackArray;
    private int _capacity;
    private int _top = -1;

    // TODO: Initialize the stack with a specified initial size.
    public Stack(int size = 4)
    {
        _stackArray = new T[size];
        _capacity = size;
    }

    // TODO: Return the item at the top of the stack without removing it.
    // If the stack is empty, return the default value for type T.
    public T? Peek()
    {
        return !Empty ? _stackArray[_top] : default;
    }

    // TODO: Remove and return the item at the top of the stack.
    // If the stack is empty, return the default value for type T.
    // Ensure the top index is updated.
    public T? Pop()
    {
        return !Empty ? _stackArray[_top--] : default;       
    }

    // TODO: Push an item onto the top of the stack.
    // 1. If the stack is not full, add the item and increment the top index.
    // 2. If the stack IS full, create a larger array (e.g., +1 size or double), copy existing items, and then add the new item.
    public void Push(T item)
    {
        if (!Full)
        {
            _stackArray[++_top] = item;
            return;
        }

        // Resize array if full
        var newArray = new T[_stackArray.Length + 1];
        for (int i = 0; i < _stackArray.Length; i++)
        {
            newArray[i] = _stackArray[i];
        }

        // Update our stack array
        _stackArray = newArray;
        _capacity = newArray.Length;        
        _stackArray[++_top] = item;
    }
}
