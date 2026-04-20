namespace _07_Queue;

public class Queue<T> : IQueue<T>
{
    private int _front;
    private int _back;
    private T?[] _data;
    private int _count;

    public bool Empty => Count == 0;
    public bool Full => Count == _data.Length;
    public int Count => _count;
    public int Size => _data.Length;
    
    
    public Queue(int capacity = 5)
    {
        _data = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (Full) return;
        _data[_back++] = element;
        _back %= Size;
        _count++;
    }

    public T? Dequeue()
    {
        if (Empty) return default;

        var result = _data[_front++];
        _front %= Size;
        _count--;
        return result;
    }
}