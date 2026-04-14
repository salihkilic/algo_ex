namespace SortingAlgorithms;

public class SortAlgo<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        bool swapped = true;

        while (swapped)
        {
            swapped = false;

            for (int i = 0; i < data.Length - 1; i++)
            {
                // Current is larger than next
                if (data[i].CompareTo(data[i+1]) == 1)
                {
                    var temp = data[i];
                    data[i] = data[i + 1];
                    data[i + 1] = temp;
                    
                    // Nicer way:
                    // (data[i], data[i + 1]) = (data[i + 1], data[i]);
                    
                    swapped = true;
                }
                
            }
        }
    }

    public static void InsertionSort(T[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            var temp = data[i];
            var prevIndex = i - 1;

            while (prevIndex >= 0 && data[prevIndex].CompareTo(temp) == 1)
            {
                data[prevIndex + 1] = data[prevIndex];
                prevIndex--;
            }

            data[prevIndex + 1] = temp;
        }
    }

    public static void MergeSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            int mid = (low + high) / 2;
            MergeSort(array, low, mid);
            MergeSort(array, mid + 1, high);
            Merge(array, low, mid, high);
        }
    }

    public static void Merge(T[] array, int low, int mid, int high)
    {
        var result = new T[high - low + 1];
        var leftIndex = low;
        var rightIndex = mid + 1;
        var resultindex = 0;

        while (leftIndex <= mid && rightIndex <= high)
        {
            if (array[leftIndex].CompareTo(array[rightIndex]) <= 0)
                result[resultindex++] = array[leftIndex++];
            else
                result[resultindex++] = array[rightIndex++];
        }
        
        // While items in left
        while (leftIndex <= mid)
            result[resultindex++] = array[leftIndex++];

        // While items in right
        while (rightIndex <= high)
            result[resultindex++] = array[rightIndex++];

        // Assign result into original array
        for (int i = 0; i < result.Length; i++)
            array[low + i] = result[i];
    }
}