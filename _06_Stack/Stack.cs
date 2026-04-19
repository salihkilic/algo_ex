namespace _06_Stack;


public class Stack<T> : IStack<T>
{
    // TODO: Return true if the stack is empty (no elements), otherwise false.
    public bool Empty => throw new NotImplementedException();

    // TODO: Return true if the internal array is full (reached capacity), otherwise false.
    public bool Full => throw new NotImplementedException();

    // TODO: Return the number of elements currently in the stack.
    public int Count => throw new NotImplementedException();

    // TODO: Return the current capacity (total size) of the internal array.
    public int Size => throw new NotImplementedException();
    
    // TIP:
    // - Hou een index bij van de bovenste item en werk die bij met elke mutatie
    // - Deze is -1 bij een lege stack

    // TODO: Initialize the stack with a specified initial size.
    public Stack(int size = 4)
    {
        throw new NotImplementedException();
    }

    // TODO: Return the item at the top of the stack without removing it.
    // If the stack is empty, return the default value for type T.
    public T? Peek()
    {
        throw new NotImplementedException();
    }

    // TODO: Remove and return the item at the top of the stack.
    // If the stack is empty, return the default value for type T.
    // Ensure the top index is updated.
    public T? Pop()
    {
        throw new NotImplementedException();
    }

    // TODO: Push an item onto the top of the stack.
    // 1. If the stack is not full, add the item and increment the top index.
    // 2. If the stack IS full, create a larger array (e.g., +1 size or double), copy existing items, and then add the new item.
    public void Push(T item)
    {
        throw new NotImplementedException();
    }
}
