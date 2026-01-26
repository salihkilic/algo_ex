namespace SearchAlgorithms;

public class SearchAlgo<T> where T : IComparable<T>
{
    public static int SequentialSearch(int[] a, int v)
    {
        for (int x = 0; x < a.Length; x++)
        {
            if (a[x] == v)
            {
                return x;
            }
        }
        return -1;
    }
    
    public static int BinarySearchRecursive(T[] a, T v, int low, int high) 
    {
        // Base case
        if (low > high)
            return -1;

        // Calc midpoint
        var mid = (low + high) / 2;

        // Lower than mid
        if (v.CompareTo(a[mid]) == -1)
            return BinarySearchRecursive(a, v, low, mid - 1);

        // Higher than mid
        if (v.CompareTo(a[mid]) == 1)
            return BinarySearchRecursive(a, v, mid + 1, high);

        return mid;
    }
}