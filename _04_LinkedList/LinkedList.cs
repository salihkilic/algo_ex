using System.Collections;

namespace _04_LinkedList;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int _count;

    public int Count => _count;

    public void AddFirst(T value)
    {
        Head = new SingleNode<T>(value, Head);
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
        
        var last = GetLast();
        last?.Next = new SingleNode<T>(value);
        _count++;
    }

    public bool Remove(T value)
    {
        if (Head is null)
            return false;

        if (Head.Value.CompareTo(value) == 0)
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
                var newNext = current.Next.Next;
                current.Next = newNext;
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
        var current = Head;

        // No head
        if (Head is null)
        {
            Head = new SingleNode<T>(value);
            _count++;
        }
        
        // Sorted = Head
        if (Head.Value.CompareTo(value) == 1)
            Head = new SingleNode<T>(value, Head);
        
        while (current is not null)
        {
            if (current.Value.CompareTo(value) == -1 && (current.Next is null || current.Next?.Value.CompareTo(value) == 1))
            {
                current.Next = new SingleNode<T>(value, current.Next);
                _count++;
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

    private SingleNode<T>? GetLast()
    {
        var current = Head;
        if (Head is null) return null;

        while (current?.Next is not null)
            current = current.Next;

        return current;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
