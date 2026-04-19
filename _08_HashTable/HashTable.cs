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

    // TIPS:
    // - We hoeven alleen maar de kans te vergroten dat we iets vinden / een lege plek hebben voor data
    // - De hash geeft dus een *startpunt* om te zoeken, in het ergste geval checken we alsnog alle indexes
    // - Als een value (dus key) al bestaat, hoeven we die niet toe te voegen
    
    protected int GetIndex(K key)
    {
        int hashCode = Math.Abs(key.GetHashCode());
        
        // TIP Hoe krijg je een index die geclamped is op de array lengte?
        
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
