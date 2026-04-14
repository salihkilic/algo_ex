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
        throw new NotImplementedException();
    }

    public void AddLast(T value)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public SingleNode<T>? Search(T value)
    {
        throw new NotImplementedException();
    }

    public bool Contains(T value) => throw new NotImplementedException();

    public void AddSorted(T value)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
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