namespace SortingAlgorithms;

public class SortAlgo<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        // Also known as swapsort!
        // As long as we swapped the last while, we iterate the array and swap values next to each other when they're in the wrong order.
        
        throw new NotImplementedException();
    }

    public static void InsertionSort(T[] data)
    {
        // iterate
        // Grab your temporary value
        // while previousIndex value is higher, move back 1 each iteration, moving those values up one index
        // that last previousindex + 1 (because you found a lower value at previousIndex) is your location for the temp val 
        
        throw new NotImplementedException();
    }

    public static void MergeSort(T[] array, int low, int high)
    {
        // Als low < high
        // bereken mid
        // MergeSort links
        // MergeSort rechts
        // Merge alles
        throw new NotImplementedException();
    }

    public static void Merge(T[] array, int low, int mid, int high)
    {
        // maak een result array van de correcte lengte voor deze selectie
        // zet een index voor de resultArray
        // bereken de 0-indexes van beide sub-arrays
        
        // while <= mid && rechts <= high
            // voeg de kleinste van links/rechts aan resultArray
            
        // Hebben we nog items over links?
        
        // Hebben nog items over rechts?
        
        // Overschrijf de waardes van de result aan `array` op de juiste plek (er is een offset)
        throw new NotImplementedException();
    }
}
