using System.Collections;

namespace DoublyLinkedList;

public class DoublyLinkedList<T> : IDoublyLinkedList<T> where T : IComparable<T>
{
    public DoubleNode<T>? First, Last;
    private int _count = 0;
    
    public int Count => _count;

    public DoublyLinkedList() => First = Last = null;
    
    public void Clear() 
    {
        First = Last = null;
        _count = 0;
    }
    
    // TODO: Check if the list contains a specific value.
    // Return true if found, false otherwise.
    public bool Contains(T value)
    {
        return Search(value) is not null;
    }

    // TODO: Search for a node containing the specified value.
    // Traverse the list from Head to Tail.
    // Return the DoubleNode<T> if found, or null if not found.
    public DoubleNode<T>? Search(T value)
    {
        if (First is null) return null;

        var current = First;

        while (current is not null)
        {
            if (current.Value.CompareTo(value) == 0)
                return current;

            current = current.Next;
        }

        return null;
    }

    #region "addNode=> first, last, sorted" 
    
    // TODO: Add a new element to the beginning (Head) of the list.
    // 1. Create a new node.
    // 2. If the list is empty, set First and Last to the new node.
    // 3. Otherwise, link the new node to the old First, update First.Previous, and set First to the new node.
    // 4. Increment Count.
    public void AddFirst(T value)
    {
        if (First is null)
        {
            First = new DoubleNode<T>(value);
            Last = First;
            _count++;
            return;
        }

        var node = new DoubleNode<T>(value, First);
        First.Previous = node;
        First = node;
        _count++;
    }

    // TODO: Add a new element to the end (Tail) of the list.
    // 1. Create a new node.
    // 2. If the list is empty, set First and Last to the new node.
    // 3. Otherwise, link the old Last to the new node, update new node's Previous, and set Last to the new node.
    // 4. Increment Count.
    public void AddLast(T value)
    {
        if (Last is null)
        {
            AddFirst(value);
            return;
        }

        var node = new DoubleNode<T>(value, null, Last);
        Last.Next = node;
        Last = node;
        _count++;
    }

    // TODO: Add a new element in sorted order (ascending).
    // 1. Handle empty list case.
    // 2. Handle insertion before Head (if value < First.Value).
    // 3. Traverse to find the insertion point (current.Next.Value > value).
    // 4. Insert the node between 'current' and 'current.Next', updating all four links (Next/Previous).
    // 5. Handle insertion at Tail.
    // 6. Increment Count.
    public void AddSorted(T value)
    {
        var current = First;
        
        // Head is null or already higher than T value
        if (current is null || current.Value.CompareTo(value) == 1)
        {
            AddFirst(value);
            return;
        }
        
        while (current is not null)
        {
            // Current is less and next is null or greater. Add.
            if (current.Value.CompareTo(value) == -1
                && (current.Next is null || current.Next.Value.CompareTo(value) == 1))
            {
                var node = new DoubleNode<T>(value, current.Next, current);
                current.Next?.Previous = node; // Only if next exists
                current.Next = node;
                _count++;
                return;
            }

            current = current.Next;
        }
    }

    #endregion

    // TODO: Remove the first occurrence of the specified value.
    // 1. Search for the node.
    // 2. If found, unlink it (connect Previous to Next).
    // 3. Update First or Last if the node was the Head or Tail.
    // 4. Decrement Count and return true.
    // 5. Return false if not found.
    public bool Remove(T value)
    {
        var toRemove = Search(value);
        if (toRemove is null) return false;
        
        Delete(toRemove);
        return true;
    }

    // TODO: Delete a specific node from the list.
    // 1. Determine if the node is Head, Tail, or Middle.
    // 2. Update pointers of adjacent nodes (Previous.Next and Next.Previous).
    // 3. Decrement Count.
    public void Delete(DoubleNode<T> node)
    {
        // toRemove is head
        if (node.Previous is null)
            First = node.Next;
        
        // toRemove is tail
        if (node.Next is null)
            Last = node.Previous;
        
        node.Previous?.Next = node.Next;
        node.Next?.Previous = node.Previous;
        _count--;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        DoubleNode<T>? current = First;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
