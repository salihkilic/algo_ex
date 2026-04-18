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
        int hashCode = Math.Abs(key.GetHashCode());
        
        throw new NotImplementedException();
    }

    public bool Add(K key, V value)
    {
        throw new NotImplementedException();
    }

    public V? Find(K key)
    {
        throw new NotImplementedException();
    }

    public bool Delete(K key)
    {
        throw new NotImplementedException();
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
