namespace _07_Queue;

public class Queue<T> : IQueue<T>
{
    private int _front;
    private int _back;
    private T?[] _data;
    private int _count;
    private int _capacity;

    public bool Empty => _count == 0;
    public bool Full => _count == _capacity;
    public int Count => _count;
    public int Size => _data.Length;

    public Queue(int capacity = 5)
    {
        _capacity = capacity;
        _data = new T[capacity];
        _front = 0;
        _back = 0;
    }

    public void Enqueue(T element)
    {
        if (Full) return;

        _data[_back] = element;
        _back = (_back + 1) % _capacity;
        _count++;
    }

    public T? Dequeue()
    {
        if (Empty) return default;

        var element = _data[_front];
        _front = (_front + 1) % _capacity;
        _count--;
        return element;
    }
}