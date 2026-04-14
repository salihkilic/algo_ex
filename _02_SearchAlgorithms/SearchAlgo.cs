namespace SearchAlgorithms;

public class SearchAlgo<T> where T : IComparable<T>
{
    public static int SequentialSearch(int[] a, int v)
    {
        var index = 0;
        foreach (var i in a)
        {
            if (i.Equals(v))
                return index;
            index++;
        }

        return -1;
    }

    public static int BinarySearch(T[] data, T Item)
    {
        var low = 0;
        var high = data.Length - 1;

        while (low <= high)
        {
            var mid = (low + high) / 2;
            
            if (data[mid].CompareTo(Item) == 0)
                return mid;
            
            // Item is left
            if (Item.CompareTo(data[mid]) == -1)
            {
                high = mid - 1;
            }
            // Item is right
            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }
    
    public static int BinarySearchRecursive(T[] a, T v, int low, int high)
    {
        // Base case, did not find
        if (low > high)
            return -1;

        var mid = (low + high) / 2;
        var compare = v.CompareTo(a[mid]);
        
        // Found item
        if (compare == 0)
            return mid;
        
        // Item is left
        if (compare == -1)
            return BinarySearchRecursive(a, v, low, mid - 1);
        
        // Item is right
        return BinarySearchRecursive(a, v, mid + 1, high);
        
    }
}
