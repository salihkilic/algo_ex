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
        var oldHead = Head;
        Head = new SingleNode<T>(value, oldHead);
        count++;
    }

    public void AddLast(T value)
    {
        if (Head is null)
        { 
            Head = new SingleNode<T>(value);
            count++;
            return;
        }

        var current = Head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        current.Next = new SingleNode<T>(value);
        count++;
    }

    public bool Remove(T value)
    {
        if (Head is null)
        {
            return false;
        }
        if (Head.Value.Equals(value)) 
        {
            Head = Head.Next;
            count--;
            return true;
        }
        var current = Head;
        while (current.Next is not null)
        {
            if (current.Next.Value.Equals(value))
            {
                current.Next = current.Next.Next;
                count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public SingleNode<T>? Search(T value)
    {
        if (Head is null)
        {
            return null;
        }
        if (Head.Value.Equals(value))
        { 
            return Head;
        }
        var current = Head;
        while (current is not null)
        {
            if (current.Value.Equals(value))
            { 
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public bool Contains(T value) => Search(value) is null ? false : true;

    public void AddSorted(T value)
    {
        if (Head is null)
        {
            Head = new SingleNode<T>(value);
            count++;
            return;
        }
        if (value.CompareTo(Head.Value) <= 0)
        {
            Head = new SingleNode<T>(value, Head);
            count++;
            return;
        }

        var current = Head;
        while (current is not null)
        {
            if (current.Next is null)
            {
                current.Next = new SingleNode<T>(value);
                count++;
                return ;
            }
            if (value.CompareTo(current.Value) >= 0 && value.CompareTo(current.Next.Value) <= 0)
            {
                current.Next = new SingleNode<T>(value, current.Next);
                count++;
                return;
            }
            current = current.Next;
        }
        
    }

    public void Clear()
    {
        count = 0;
        Head = null;
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