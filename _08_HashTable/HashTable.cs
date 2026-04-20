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

        for (int i = 0; i < Buckets.Length; i++)
        {
            var probingIndex = (GetIndex(key) + i) % Buckets.Length;
            
            // Found a bucket
            if (Buckets[probingIndex] is null)
            {
                Buckets[probingIndex] = new Entry<K, V>(key, value);
                return true;
            }
            
            // Key already exists
            if (Buckets[probingIndex]?.Key?.Equals(key) is true)
                return false;
        }

        return false;
    }

    public V? Find(K key)
    {
        if (Buckets is null) return default;

        for (int i = 0; i < Buckets.Length; i++)
        {
            var probingIndex = (GetIndex(key) + i) % Buckets.Length; 
            
            if (Buckets[probingIndex] is null) continue;
            
            // Key already exists
            if (Buckets[probingIndex]!.Key!.Equals(key))
                return Buckets[probingIndex]!.Value;
        }
        return default;
    }

    public bool Delete(K key)
    {
        if (Buckets is null) return default;

        for (int i = 0; i < Buckets.Length; i++)
        {
            var probingIndex = (GetIndex(key) + i) % Buckets.Length; 
            
            if (Buckets[probingIndex] is null) continue;
            
            // Key already exists
            if (Buckets[probingIndex]!.Key!.Equals(key))
            {
                Buckets[probingIndex] = null;
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
