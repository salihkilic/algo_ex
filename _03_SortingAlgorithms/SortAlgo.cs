namespace SortingAlgorithms;

public class SortAlgo<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            for (int j = 0; j < data.Length -1; j++)
            {
                if (data[j].CompareTo( data[j +1]) > 0)
                {
                    var tmp = data[j];
                    data[j] = data[j + 1];
                    data[j+1] = tmp;
                }
            }
        }
    }

    public static void InsertionSort(T[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            var key = data[i];
            int j = i -1;

            while(j >= 0 && data[j].CompareTo(key) > 0)
            {
                data[j + 1] = data[j];
                j = j - 1;
            }
            data[j + 1] = key;
        }
    }

    public static void MergeSort(T[] array, int low, int high)
    {
        if (low >= high)
        {
            return;
        }
        int mid = (low + high) / 2;

        MergeSort(array, low, mid);
        MergeSort(array, mid +1, high);

        Merge(array, low, mid, high);
    }

    public static void Merge(T[] array, int low, int mid, int high)
    {
        T[] tmp = new T[high - low + 1];
        int i = low;
        int j = mid +1;
        int k = 0;

        while (i <= mid && j <= high)
        {
            if (array[i].CompareTo(array[j]) <= 0)
            {
                tmp[k] = array[i];
                i++;
            }
            else
            {
                tmp[k] = array[j];
                j++;
            }
            k++;
        }

        while (i <= mid)
        {
            tmp[k] = array[i];
            i++;
            k++;
        }
        while (j <= high)
        {
            tmp[k] = array[j];
            j++;
            k++;
        }
        for (int a = 0; a < tmp.Length; a++)
        {
            array[low +a] = tmp[a];
        }
    }
}