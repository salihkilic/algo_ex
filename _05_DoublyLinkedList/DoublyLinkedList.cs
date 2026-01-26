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
        return Search(value) != null;
    }

    // TODO: Search for a node containing the specified value.
    // Traverse the list from Head to Tail.
    // Return the DoubleNode<T> if found, or null if not found.
    public DoubleNode<T>? Search(T value)
    {
        // No head
        if (First == null)
        {
            return null;
        }

        // Has head
        var current = First;
        if (current.Value.CompareTo(value) == 0)
        {
            return current;
        }

        // Travel the nodes
        while (current.Next != null)
        {
            current = current.Next;
            if (current.Value.CompareTo(value) == 0)
            {
                return current;
            }
        }

        // Sadly we couldn't find the value
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
        _count++;
        // No head
        if (First == null)
        {
            First = Last = new DoubleNode<T>(value);
            return;
        }

        // Has head
        var newNode = new DoubleNode<T>(value, First);
        First.Previous = newNode;
        First = newNode;
    }

    // TODO: Add a new element to the end (Tail) of the list.
    // 1. Create a new node.
    // 2. If the list is empty, set First and Last to the new node.
    // 3. Otherwise, link the old Last to the new node, update new node's Previous, and set Last to the new node.
    // 4. Increment Count.
    public void AddLast(T value)
    {
        _count++;
        // No head, or we lost reference to last
        if (Last == null)
        {
            First = Last = new DoubleNode<T>(value);
            return;
        }

        // Has head
        var newLast = new DoubleNode<T>(value, null, Last); // Create the new node
        Last.Next = newLast; // Add node to the current NODE in tail
        Last = newLast; // Assign new node reference as tail in LIST
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
        _count++;
        DoubleNode<T> newNode;

        // No head
        if (First == null)
        {
            First = Last = new DoubleNode<T>(value);
            return;
        }

        // Has head
        // First item is already larger
        if (First.Value.CompareTo(value) > 0) 
        {
            newNode = new DoubleNode<T>(value, First, null);
            First.Previous = newNode;
            First = newNode;
            return;
        }

        // Traverse list until a higher value is found
        var current = First;
        while (current.Next != null && current.Next.Value.CompareTo(value) <= 0)
        {
            current = current.Next;
        }

        // Insert the new node at the correct position
        if (current.Next == null)  
        {
            newNode = new DoubleNode<T>(value, null, current);
            current.Next = newNode;
            Last = newNode;  
        }
        else  // Insert in the middle
        {
            newNode = new DoubleNode<T>(value, current.Next, current);
            current.Next.Previous = newNode;
            current.Next = newNode;
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
        var foundNode = Search(value);
        if (foundNode != null)
        {
            _count--;
            // Check slides again on propper flow, this just sucks
            if (foundNode.Previous != null)
            {
                foundNode.Previous.Next = foundNode.Next;
            }
            else
            {
                First = foundNode.Next;
            }
            
            if (foundNode.Next != null)
            {
                foundNode.Next.Previous = foundNode.Previous;
            }
            else
            {
                Last = foundNode.Previous;
            }
            return true;
        }
        // Not found
        return false;
    }

    // TODO: Delete a specific node from the list.
    // 1. Determine if the node is Head, Tail, or Middle.
    // 2. Update pointers of adjacent nodes (Previous.Next and Next.Previous).
    // 3. Decrement Count.
    public void Delete(DoubleNode<T> node)
    {
        if (node == null) return;
        
        // Count handling is tricky if deleting solely by node reference without list context...
        // Assuming this node belongs to this list.
        _count--;

        // Node is Head
        if (node.Previous == null)
        {
            node.Next.Previous = null;
            First = node.Next;
            return;
        }

        // Node is Tail
        if (node.Next == null)
        {
            node.Previous.Next = null;
            Last = node.Previous;
            return;
        }

        // Somewhere in the middle
        node.Previous.Next = node.Next;
        node.Next.Previous = node.Previous;
    }

    // TODO: Implement the enumerator to allow iterating over the list.
    // Use 'yield return' to return values from First to Last.
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
