namespace _08_HashTable;

using System.Collections.ObjectModel;

public class HashTable<K, V> : IHashTable<K, V>
{
    Entry<K, V>[]? Buckets { get; set;}

    public ReadOnlyCollection<Entry<K, V>>? Data => Buckets == null? null : Buckets.AsReadOnly();

    public HashTable() { Buckets = null; }

    public HashTable(Entry<K, V>[]? input) { ImportData(input);}

    public HashTable(int capacity)
    {
        Buckets = new Entry<K, V>[capacity];
    }

    protected int GetIndex(K key)
    {
        int hashCode = Math.Abs(key.GetHashCode());
        return hashCode % Buckets.Length;
    }

    private int GetNextIndex(int index) 
    {
        return (index + 1) % Buckets.Length;
    }

    private int FindNextAvailableSpot(int index)
    {
        var tempIndex = index;
        int iterationCount = 1; // Making sure we don't infi loop
        while (Buckets[tempIndex] != null && iterationCount % Buckets.Length != 0)
        {
            tempIndex = GetNextIndex(tempIndex);
            iterationCount++;
        }
        // Return the index or -1
        return - 1;
    }

    private int FindIndex(K key)
    {
        // Either it's at the index
        var assumedIndex = GetIndex(key);
        int iterationCount = 1; // Making sure we don't infi loop
        while (iterationCount % Buckets.Length != 0)
        {
            if (Buckets[assumedIndex] == null) return -1; // When we encounter null, we know we're too far already
            if (Buckets[assumedIndex].Key.Equals(key)) return assumedIndex; // return if found
            assumedIndex = GetNextIndex(assumedIndex);
            iterationCount++;
        }
        // Guess the whole thing is full here, but no match.
        return -1;
    }

    public bool Add(K key, V value)
    {
        // Check if key already exists
        if (FindIndex(key) != -1) return false;

        // Find a free spot
        var potentialIndex = FindNextAvailableSpot(GetIndex(key));
        if (potentialIndex != -1)
        {
            Buckets[potentialIndex] = new Entry<K,V>(key, value);
            return true;
        }
        return false;
    }

    public V? Find(K key)
    {
        int index = FindIndex(key);
        return index != -1 ? Buckets[index].Value : default(V);
    }

    public bool Delete(K key)
    {
        int index = FindIndex(key);
        if (index == -1) return false;
        
        // 1. Remove the item
        Buckets[index] = null;

        // 2. Re-hash the chain to fill the gap (Backward Shift / Re-insert)
        // We look at the next item. If it's not null, we must re-insert it
        // because it might have been probing and relied on the now-empty slot to be full.
        index = GetNextIndex(index);
        while (Buckets[index] != null)
        {
            // Pick up the "orphan" entry
            var orphan = Buckets[index];
            Buckets[index] = null; // Remove it temporarily
            
            // Re-insert it. It will find the best available spot (possibly the one we just cleared, or another).
            // We use the existing Add logic (or simplified, since we know it's unique).
            // Note: Add() checks for duplicates using FindIndex. Since we removed it from the array, FindIndex won't find it -> Add proceeds.
            Add(orphan.Key, orphan.Value);

            index = GetNextIndex(index);
        }

        return true;
    }

    //DO NOT REMOVE the following method:
    private void ImportData(Entry<K, V>[]? inputData){
        if(inputData != null) {
            Buckets = new Entry<K, V>[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i) 
                Buckets[i] = inputData[i];
        }
    }
}
