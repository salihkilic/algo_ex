namespace _07_Queue;

public class Queue<T> : IQueue<T>
{
    private int _front;
    private int _back;
    private T?[] _data;
    private int _count = 0;
    private int _capacity = 0;

    public bool Empty => _count == 0;
    public bool Full => _count == _data.Length;  
    public int Count => _count;
    public int Size => _capacity;

    public Queue(int capacity = 5)
    {
        _data = new T[capacity];
        _capacity = capacity;
        _front = 0;
        _back = 0;
    }

    public void Enqueue(T element)
    {
        if (!Full)
        {
            _data[_back] = element;
            _back = (_back + 1) % _data.Length;  
            _count++;
        }
    }

    public T? Dequeue()
    {
        if (Empty)
        {
            return default;
        }

        var element = _data[_front];
        _data[_front] = default;  
        _front = (_front + 1) % _data.Length;  
        _count--;
        return element;
    }
}