namespace _07_Queue;

/// <summary>
/// Implement the interface methods using Array
/// </summary>
public interface IQueue<T>
{
    /// <summary>
    /// Adds an item to the back of the queue.
    /// If the queue is full, the item should not be added.
    /// </summary>
    /// <param name="item">The item to add to the queue.</param>
    void Enqueue(T item);

    /// <summary>
    /// Removes and returns the item from the front of the queue.
    /// If the queue is empty, it should return the default value for type T.
    /// </summary>
    /// <returns>The item at the front of the queue, or default(T) if empty.</returns>
    T? Dequeue();

    /// <summary>
    /// Returns true if the queue has no elements, false otherwise.
    /// </summary>
    bool Empty { get; }

    /// <summary>
    /// Returns true if the queue has reached its capacity, false otherwise.
    /// </summary>
    bool Full { get; }

    /// <summary>
    /// Gets the current number of elements in the queue.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Gets the maximum capacity of the queue.
    /// </summary>
    int Size { get; }
}