using AlgorithmTestFramework;

namespace _08_HashTable;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Hash Table Algorithms Exercise Runner --- \n");
        RunTests();
    }

    private static void RunTests()
    {
        Console.WriteLine("Testing Basic Operations...");
        TestRunner.RunTest("Add and Find", TestAddAndFind, 
            "Ensure items can be added and subsequently found using their keys.");

        TestRunner.RunTest("Duplicate Key Protection", TestDuplicateKey, 
            "Add should return false if the key already exists in the table.");

        TestRunner.RunTest("Full Table Handling", TestFullTable, 
            "Add should return false if the table has no more available spots (capacity reached).");

        Console.WriteLine("\nTesting Deletion...");
        TestRunner.RunTest("Delete Existing", TestDeleteExisting, 
            "Delete should remove the item and return true. Subsequent Find should return default.");

        TestRunner.RunTest("Delete Non-Existing", TestDeleteNonExisting, 
            "Delete should return false if the key is not in the table.");

        Console.WriteLine("\nTesting Collisions (Linear Probing)...");
        TestRunner.RunTest("Collision Handling", TestCollisionHandling, 
            "Items with keys mapping to the same index should be stored via probing (e.g., in the next available slot).");

        // Note: The provided implementation might fail this if it doesn't handle deletion gaps (tombstones) correctly.
        TestRunner.RunTest("Delete Breaking Search Chain", TestDeleteBreaksChain, 
            "Removing an item that caused a collision probe should not prevent finding other collided items (Search chain integrity).");
    }

    /// <summary>
    /// Tests simple Add and Find functionality.
    /// </summary>
    private static void TestAddAndFind()
    {
        var hashTable = new HashTable<string, int>(10);
        
        // Add item
        bool added = hashTable.Add("One", 1);
        Assertions.AssertEqual(added, true, "Should successfully add 'One'.");
        
        // Find item
        int val = hashTable.Find("One");
        Assertions.AssertEqual(val, 1, "Should retrieve value 1 for key 'One'.");

        // Add another
        hashTable.Add("Two", 2);
        Assertions.AssertEqual(hashTable.Find("Two"), 2, "Should retrieve value 2 for key 'Two'.");

        // Find non-existing
        Assertions.AssertEqual(hashTable.Find("Three"), 0, "Searching for missing key should return default (0).");
    }

    /// <summary>
    /// Tests that adding a duplicate key returns false and doesn't overwrite.
    /// </summary>
    private static void TestDuplicateKey()
    {
        var hashTable = new HashTable<string, int>(10);
        hashTable.Add("A", 100);

        bool addedAgain = hashTable.Add("A", 200);
        Assertions.AssertEqual(addedAgain, false, "Add should return false for duplicate key.");
        
        int val = hashTable.Find("A");
        Assertions.AssertEqual(val, 100, "Value should remain 100 (original).");
    }

    /// <summary>
    /// Tests behavior when the table is full.
    /// </summary>
    private static void TestFullTable()
    {
        int capacity = 2;
        var hashTable = new HashTable<int, string>(capacity);
        
        hashTable.Add(1, "First");
        hashTable.Add(2, "Second");
        
        // Table is now full
        bool added = hashTable.Add(3, "Third");
        Assertions.AssertEqual(added, false, "Should return false when table is full.");
        
        string? val = hashTable.Find(3);
        Assertions.AssertEqual(val, null, "Should not find item that wasn't added.");
    }

    /// <summary>
    /// Tests basic deletion.
    /// </summary>
    private static void TestDeleteExisting()
    {
        var hashTable = new HashTable<string, int>(5);
        hashTable.Add("Key1", 10);
        
        bool deleted = hashTable.Delete("Key1");
        Assertions.AssertEqual(deleted, true, "Delete should return true for found key.");
        
        int val = hashTable.Find("Key1");
        Assertions.AssertEqual(val, 0, "Key1 should not be found after deletion.");
    }

    private static void TestDeleteNonExisting()
    {
        var hashTable = new HashTable<string, int>(5);
        hashTable.Add("Key1", 10);

        bool deleted = hashTable.Delete("Key99");
        Assertions.AssertEqual(deleted, false, "Delete should return false for missing key.");
        
        Assertions.AssertEqual(hashTable.Find("Key1"), 10, "Existing keys should remain touched.");
    }

    /// <summary>
    /// Tests that collisions are resolved (likely via linear probing).
    /// </summary>
    private static void TestCollisionHandling()
    {
        // Use a small capacity to force collision logic if possible, 
        // or rely on the fact that we can check if multiple items exist.
        // It's hard to force HashCode collision generally without specific knowledge of K type or mocking.
        // However, with small capacity, indices (HashCode % Length) will collide.
        
        var hashTable = new HashTable<int, string>(3);
        
        // Assume simple mod hash. 
        // 0 % 3 = 0
        // 3 % 3 = 0 -> Collision
        
        hashTable.Add(0, "Zero");
        hashTable.Add(3, "Three"); // Should map to same bucket initially
        
        Assertions.AssertEqual(hashTable.Find(0), "Zero", "Should find first item.");
        Assertions.AssertEqual(hashTable.Find(3), "Three", "Should find second item despite collision.");
    }

    /// <summary>
    /// Tests the 'Delete breaks chain' problem in Open Addressing.
    /// If we have [A, B] where B collided and probed, and we delete A, 
    /// a naive delete leaves a hole. Searching for B stops at the hole and fails.
    /// </summary>
    private static void TestDeleteBreaksChain()
    {
        // 5 buckets. 
        // Key 0 -> Index 0
        // Key 5 -> Index 0 (Collision) -> Probe to 1
        // Key 10 -> Index 0 (Collision) -> Probe to 2
        var hashTable = new HashTable<int, string>(5);
        
        hashTable.Add(0, "Base");
        hashTable.Add(5, "Collided1");
        hashTable.Add(10, "Collided2");
        
        // Verify all present
        Assertions.AssertEqual(hashTable.Find(0), "Base");
        Assertions.AssertEqual(hashTable.Find(5), "Collided1");
        Assertions.AssertEqual(hashTable.Find(10), "Collided2");
        
        // Delete the base. In naive linear probing, this sets buckets[0] = null.
        hashTable.Delete(0);
        Assertions.AssertEqual(hashTable.Find(0), null, "Base should be gone.");
        
        // Now find Collided1. 
        // If implementation is naive: Hash(5) -> 0. buckets[0] is null. Stop. Not found.
        // If implementation handles it (tombstones/rehash): skip 0, check 1. Found.
        string? val = hashTable.Find(5);
        Assertions.AssertEqual(val, "Collided1", 
            "Should still find collided item after removing the item that caused the collision.");
    }
}

