namespace _06_Stack;

public interface IStack<T>{
    void Push(T item);
    T? Pop();
    T? Peek();

    bool Empty { get; }
    bool Full { get; }
    int Count { get; }  
    int Size { get; }  
}