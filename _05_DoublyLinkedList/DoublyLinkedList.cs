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
    
    // TIPS:
    // - Check head
    // - Als we head verwijderen of toevoegen, property aanpassen.
    // - Zelfde geldt voor last hier!
    // - ALTIJD COUNT BIJWERKEN
    
    
    // TODO: Check if the list contains a specific value.
    // Return true if found, false otherwise.
    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    // TODO: Search for a node containing the specified value.
    // Traverse the list from Head to Tail.
    // Return the DoubleNode<T> if found, or null if not found.
    public DoubleNode<T>? Search(T value)
    {
        throw new NotImplementedException();
    }

    #region "addNode=> first, last, sorted" 
    
    // TODO: Add a new element to the beginning (Head) of the list.
    // 1. Create a new node.
    // 2. If the list is empty, set First and Last to the new node.
    // 3. Otherwise, link the new node to the old First, update First.Previous, and set First to the new node.
    // 4. Increment Count.
    public void AddFirst(T value)
    {
        throw new NotImplementedException();
    }

    // TODO: Add a new element to the end (Tail) of the list.
    // 1. Create a new node.
    // 2. If the list is empty, set First and Last to the new node.
    // 3. Otherwise, link the old Last to the new node, update new node's Previous, and set Last to the new node.
    // 4. Increment Count.
    public void AddLast(T value)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    // TODO: Delete a specific node from the list.
    // 1. Determine if the node is Head, Tail, or Middle.
    // 2. Update pointers of adjacent nodes (Previous.Next and Next.Previous).
    // 3. Decrement Count.
    public void Delete(DoubleNode<T> node)
    {
        throw new NotImplementedException();
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
