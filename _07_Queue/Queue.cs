namespace _07_Queue;

public class Queue<T> : IQueue<T>
{
    private int _front;
    private int _back;
    private T?[] _data;
    private int _count;

    public bool Empty => throw new NotImplementedException();
    public bool Full => throw new NotImplementedException();
    public int Count => throw new NotImplementedException();
    public int Size => throw new NotImplementedException();

    public Queue(int capacity = 5)
    {
        throw new NotImplementedException();
    }

    public void Enqueue(T element)
    {
        throw new NotImplementedException();
    }

    public T? Dequeue()
    {
        throw new NotImplementedException();
    }
}