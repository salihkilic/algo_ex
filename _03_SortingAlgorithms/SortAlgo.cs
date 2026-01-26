namespace SortingAlgorithms;

public class SortAlgo<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i=0; i < data.Length - 1; i++)
            {
                if (data[i].CompareTo(data[i+1]) > 0)
                {
                    // Protip: Swap by destructuring
                    (data[i], data[i+1]) = (data[i+1], data[i]);
                    swapped = true;
                }
            }
        }
        while (swapped);
    }

    public static void InsertionSort(T[] data)
    {
        for (int index=1; index < data.Length; index++)
        {
            var key = data[index];
            var previousIndex = index - 1;

            // while (previousIndex >= 0 && data[previousIndex] > key)
            while (previousIndex >= 0 && data[previousIndex].CompareTo(key) > 0)
            {
                data[previousIndex + 1] = data[previousIndex];
                previousIndex--;
            }
            data[previousIndex + 1] = key;
        }
    }

    public static void MergeSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            var midpoint = (low + high) / 2;
            MergeSort(array, low, midpoint);
            MergeSort(array, midpoint + 1, high);
            Merge(array, low, midpoint, high);
        }
    }

    public static void Merge(T[] array, int low, int mid, int high)
    {
        int n1 = mid - low + 1;  // Size of left subarray
        int n2 = high - mid;     // Size of right subarray

        // Create temporary arrays
        T[] left = new T[n1];  // Left subarray
        T[] right = new T[n2]; // Right subarray

        // Copy data to left[] and right[]
        for (int i = 0; i < n1; i++)
            left[i] = array[low + i];
        for (int j = 0; j < n2; j++)
            right[j] = array[mid + 1 + j];

        int ii = 0; // Initial index of left subarray
        int jj = 0; // Initial index of right subarray
        int k = low; // Initial index of merged array

        // Merge the subarrays back into the original array
        while (ii < n1 && jj < n2)
        {
            if (Comparer<T>.Default.Compare(left[ii], right[jj]) <= 0)
            {
                array[k] = left[ii];
                ii++;
            }
            else
            {
                array[k] = right[jj];
                jj++;
            }
            k++;
        }

        // Copy the remaining elements of left[] if any
        while (ii < n1)
        {
            array[k] = left[ii];
            ii++;
            k++;
        }

        // Copy the remaining elements of right[] if any
        while (jj < n2)
        {
            array[k] = right[jj];
            jj++;
            k++;
        }
    }

}