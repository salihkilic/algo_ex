namespace _08_HashTable;

public interface IHashTable<K, V>
{
    /// <summary>
    /// Adds a key-value pair to the hash table.
    /// Returns true if the key did not exist and was added successfully.
    /// Returns false if the key already exists or the table is full.
    /// </summary>
    /// <param name="key">The unique key to add.</param>
    /// <param name="value">The value associated with the key.</param>
    /// <returns>True if added, false otherwise.</returns>
    bool Add(K key, V value);

    /// <summary>
    /// Searches for a value by its key.
    /// </summary>
    /// <param name="key">The key to search for.</param>
    /// <returns>The value associated with the key if found; otherwise, the default value of V.</returns>
    V? Find(K key);

    /// <summary>
    /// Removes a key-value pair from the hash table by its key.
    /// </summary>
    /// <param name="key">The key of the item to remove.</param>
    /// <returns>True if the item was found and removed; otherwise, false.</returns>
    bool Delete(K key);
}