namespace SearchAlgorithms;

public class SearchAlgo<T> where T : IComparable<T>
{
    /// <summary>
    /// Returns the index of the item, or -1 if not found
    /// </summary>
    public static int SequentialSearch(int[] a, int v)
    {
        for(int i=0; i<a.Length;i++)
        {
            if (a[i].CompareTo(v) == 0) return i;
        }

        return -1;
    }

    /// <summary>
    /// Returns the index of the item, or -1 if not found
    /// </summary>
    public static int BinarySearch(T[] data, T Item)
    {
        int low = 0;
        int high = data.Length - 1;
        
        while (low <= high)
        {
            var mid = (low + high) / 2;
            
            switch (Item.CompareTo(data[mid]))
            {
                case 0:
                    return mid;
                
                // Item is lower than data[mid]
                case -1:
                    high = mid - 1;
                    break;
                
                // Item is higher than data[mid]
                case 1:
                    low = mid + 1;
                    break;
            }
            
        }
        return -1;
    }
    
    /// <summary>
    /// Returns the index of the item, or -1 if not found
    /// </summary>
    public static int BinarySearchRecursive(T[] a, T v, int low, int high)
    {
        if (low > high) return -1;

        var mid = (low + high) / 2;

        switch (v.CompareTo(a[mid]))
        {
            // Left
            case -1:
                return BinarySearchRecursive(a,v,low,mid-1);
            // Found
            case 0:
                return mid;
            // Right
            case 1:
                return BinarySearchRecursive(a,v,mid+1, high);
        }

        // Something went wrong
        return -2;
    }
}
