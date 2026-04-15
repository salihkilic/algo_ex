namespace _08_HashTable;

using System.Collections.ObjectModel;

public class HashTable<K, V> : IHashTable<K, V>
{
    Entry<K, V>?[]? Buckets { get; set;}

    public ReadOnlyCollection<Entry<K, V>?>? Data => Buckets?.AsReadOnly();

    public HashTable() { Buckets = null; }

    public HashTable(Entry<K, V>[]? input) { ImportData(input);}

    public HashTable(int capacity)
    {
        Buckets = new Entry<K, V>[capacity];
    }

    protected int GetIndex(K key)
    {
        if (Buckets is null || key is null) return -1;
        
        int hashCode = Math.Abs(key.GetHashCode());
        return hashCode % Buckets.Length;
    }

    public bool Add(K key, V value)
    {
        if (Buckets is null) return false;
        
        var assumedIndex = GetIndex(key);

        if (Buckets[assumedIndex] is null)
        {
            Buckets[assumedIndex] = new Entry<K, V>(key, value);
            return true;
        }
        
        // Already there, false
        if (Buckets[assumedIndex]?.Key?.Equals(key) is true)
            return false;
        
        // Loop over collection to find empty spot.
        for (int i = 1; i < Buckets.Length; i++)
        {
            if (Buckets[(assumedIndex + i) % Buckets.Length] is null)
            {
                Buckets[(assumedIndex + i) % Buckets.Length] = new Entry<K, V>(key, value);
                return true;
            }
        }

        // Couldn't find an empty spot
        return false;
    }

    public V? Find(K key)
    {
        if (Buckets is null) return default;
        
        var index = GetIndex(key);
        
        // Value at index
        if (Buckets[index]?.Key?.Equals(key) is true)
            return Buckets[index]!.Value;
        
        for (int i = 1; i < Buckets.Length; i++)
        {
            if (Buckets[(index + i) % Buckets.Length]?.Key?.Equals(key) is true)
            {
                return Buckets[(index + i) % Buckets.Length].Value ?? default;
            }
        }

        return default;
    }

    public bool Delete(K key)
    {
        if (Buckets is null) return false;
        
        var index = GetIndex(key);
        
        // Value at index
        if (Buckets[index]?.Key?.Equals(key) is true)
        {
            Buckets[index] = null;
            return true;
        }
        
        for (int i = 1; i < Buckets.Length; i++)
        {
            if (Buckets[(index + i) % Buckets.Length]?.Key?.Equals(key) is true)
            {
                Buckets[(index + i) % Buckets.Length] = null;
                return true;
            }
        }

        return false;
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
