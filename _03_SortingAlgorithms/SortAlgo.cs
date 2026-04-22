namespace SortingAlgorithms;

public class SortAlgo<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        var swapped = true;

        while (swapped)
        {
            swapped = false;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i].CompareTo(data[i - 1]) == -1)
                {
                    swapped = true;
                    (data[i], data[i - 1]) = (data[i - 1], data[i]);
                }
            }
        }
    }

    public static void InsertionSort(T[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            var temp = data[i];
            var previousIndex = i - 1;

            while (previousIndex >= 0 && data[previousIndex].CompareTo(temp) == 1)
            {
                data[previousIndex + 1] = data[previousIndex--];
            }

            data[previousIndex + 1] = temp;
        }
    }

    public static void MergeSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            var mid = (low + high) / 2;
            
            MergeSort(array, low, mid);
            MergeSort(array, mid + 1, high);
            Merge(array, low, mid, high);
        }
    }

    public static void Merge(T[] array, int low, int mid, int high)
    {
        var result = new T[high - low + 1];
        var resultIndex = 0;
        var leftIndex = low;
        var rightIndex = mid + 1;

        while (leftIndex <= mid && rightIndex <= high)
        {
            if (array[leftIndex].CompareTo(array[rightIndex]) == -1)
                result[resultIndex++] = array[leftIndex++];
            else
                result[resultIndex++] = array[rightIndex++];
        }
        
        while (leftIndex <= mid)
            result[resultIndex++] = array[leftIndex++];
        
        while (rightIndex <= high)
            result[resultIndex++] = array[rightIndex++];

        for (int i = 0; i < result.Length; i++)
        {
            array[low + i] = result[i];
        }
    }
}
