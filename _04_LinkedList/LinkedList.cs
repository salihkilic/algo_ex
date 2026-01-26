using System.Collections;

namespace _04_LinkedList;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int count;

    public SinglyLinkedList()
    {
    }

    public int Count => count;

    public void AddFirst(T value)
    {
        // If Head not null
        if (Head != null)
        {
            Head = new SingleNode<T>(value, Head);
            count++;
            return;
        }

        // If no Head
        Head = new SingleNode<T>(value);
        count++;
        
    }

    public void AddLast(T value)
    {
        // If Head not null
        if (Head != null)
        {
            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
        
            current.Next = new SingleNode<T>(value);
            count++;
            return;
        }

        // If no Head
        Head = new SingleNode<T>(value);
        count++;
    }

    public bool Remove(T value)
    {
        // Check for head
        if (Head == null)
        {
            return false;
        }

        // Check if head is value
        if (Head.Value.CompareTo(value) == 0)
        {
            Head = Head.Next;
            count--;
            return true;
        }

        // Loop for value
        var current = Head;
        while (current.Next != null)
        {
            // Found 
            if (current.Next.Value.CompareTo(value) == 0)
            {
                current.Next = current.Next.Next;
                count--;
                return true;
            }
            current = current.Next;
        }
        // Not found
        return false;
    }

    public SingleNode<T>? Search(T value)
    {
        // Check for head
        if (Head == null)
        {
            return null;
        }

        // Check if head is value
        if (Head.Value.CompareTo(value) == 0)
        {
            return Head;
        }

        // Loop for value
        var current = Head;
        while (current.Next != null)
        {
            // Found 
            if (current.Next.Value.CompareTo(value) == 0)
            {
                return current.Next;
            }
            current = current.Next;
        }
        // Not found
        return null;
    }

    public bool Contains(T value) => Search(value) != null ? true : false;

    public void AddSorted(T value)
    {
        // Check for head
        if (Head == null)
        {
            Head = new SingleNode<T>(value);
            count++;
            return;
        }

        // Check if head is higher
        if (Head.Value.CompareTo(value) == 1)
        {
            Head = new SingleNode<T>(value, Head);
            count++;
            return;
        }

        // Loop for value
        var current = Head;
        while (current.Next != null)
        {
            // Found higher val in next
            if (current.Next.Value.CompareTo(value) == 1)
            {
                current.Next = new SingleNode<T>(value, current.Next);
                count++;
                return;
            }
            current = current.Next;
        }
        // Node can be added to tail
        current.Next = new SingleNode<T>(value);
        count++;
    }

    public void Clear()
    {
        Head = null;
        count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SingleNode<T>? current = Head;
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