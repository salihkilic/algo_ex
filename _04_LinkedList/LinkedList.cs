using System.Collections;

namespace _04_LinkedList;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int _count;

    public int Count => _count;

    // TIPS:
    // - Check head
    // - Als we head verwijderen of toevoegen, property aanpassen.
    // - ALTIJD COUNT BIJWERKEN
    
    public void AddFirst(T value)
    {
        Head = Head is null 
            ? new SingleNode<T>(value) 
            : new SingleNode<T>(value, Head);
        _count++;
    }

    public void AddLast(T value)
    {
        if (Head is null)
        {
            Head = new SingleNode<T>(value);
            _count++;
            return;
        }
        
        var current = Head;
        while (current.Next is not null)
        {
            current = current.Next;
        }

        current.Next = new SingleNode<T>(value);
        _count++;
    }

    public bool Remove(T value)
    {
        if (Head?.Value.CompareTo(value) == 0)
        {
            Head = Head.Next;
            _count--;
            return true;
        }
        
        var current = Head;
        while (current is not null)
        {
            if (current.Next?.Value.CompareTo(value) == 0)
            {
                current.Next = current.Next.Next ?? null;
                _count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public SingleNode<T>? Search(T value)
    {
        var current = Head;

        while (current is not null)
        {
            if (current.Value.CompareTo(value) == 0)
                return current;

            current = current.Next;
        }

        return null;
    }

    public bool Contains(T value) => Search(value) is not null;

    public void AddSorted(T value)
    {
        if (Head is null)
        {
            Head = new SingleNode<T>(value);
            _count++;
            return;
        }

        if (Head?.Value.CompareTo(value) == 1)
        {
            Head = new SingleNode<T>(value, Head);
            _count++;
            return;
        }

        var current = Head;
        while (current is not null)
        {
            if ((current.Value.CompareTo(value) == -1 && current.Next?.Value.CompareTo(value) == 1) || current.Next is null)
            {
                current.Next = new SingleNode<T>(value, current.Next);
                _count++;
                return;
            }

            current = current.Next;
        }

    }

    public void Clear()
    {
        Head = null;
        _count = 0;
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
