using AlgorithmTestFramework;

namespace _09_BST;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Binary Search Tree (BST) Algorithms Exercise Runner --- \n");
        RunTests();
    }

    private static void RunTests()
    {
        Console.WriteLine("Testing Basic Operations...");
        TestRunner.RunTest("Insert and Contains", TestInsertAndContains,
            "Insert should place items correctly. Contains should find them.");

        TestRunner.RunTest("Insert - Duplicate Handling", TestInsertDuplicates,
            "Inserting duplicate values should not add them again (BST property).");

        TestRunner.RunTest("Insert Iterative", TestInsertIterative,
            "InsertIterative should work the same as recursive Insert.");

        TestRunner.RunTest("Tree Structure After Insertions", TestTreeStructure,
            "Verify the exact tree structure via Root.Left, Root.Right navigation.");

        TestRunner.RunTest("In-Order Traversal (Sorting)", TestInOrderTraversal,
            "In-Order traversal of a BST should yield values in sorted ascending order.");

        TestRunner.RunTest("Pre-Order Traversal", TestPreOrderTraversal,
            "Pre-Order should be Root, Left, Right.");

        TestRunner.RunTest("Post-Order Traversal", TestPostOrderTraversal,
            "Post-Order should be Left, Right, Root.");

        TestRunner.RunTest("Traversal - Empty Tree", TestTraversalEmptyTree,
            "Traversals on an empty tree should return empty string.");

        TestRunner.RunTest("Traversal - Single Node", TestTraversalSingleNode,
            "Traversals on a single-node tree should return that node's value.");

        Console.WriteLine("\nTesting Removal...");
        TestRunner.RunTest("Remove Leaf Node", TestRemoveLeaf,
            "Removing a leaf (no children) should just unlink it from the parent.");

        TestRunner.RunTest("Remove Node with One Child", TestRemoveOneChild,
            "Removing a node with one child should link the parent directly to that child.");

        TestRunner.RunTest("Remove Node with Two Children", TestRemoveTwoChildren,
            "Removing a node with two children requires finding a successor (or predecessor) and swapping/replacing.");

        TestRunner.RunTest("Remove Root", TestRemoveRoot,
            "Removing the root is a special case. The new root should be correctly assigned.");

        TestRunner.RunTest("Remove Root - Single Node", TestRemoveRootSingleNode,
            "Removing the only node in the tree should result in an empty tree.");

        TestRunner.RunTest("Remove Non-Existent Value", TestRemoveNonExistent,
            "Attempting to remove a non-existent value should return false.");

        Console.WriteLine("\nTesting Traversal String Parsing...");
        TestRunner.RunTest("Traversal Parsing - In-Order", TestTraversalParsingInOrder,
            "Parse and verify individual values from traversal strings using array comparison.");

        TestRunner.RunTest("Traversal Parsing - Pre-Order", TestTraversalParsingPreOrder,
            "Parse and verify individual values from pre-order traversal.");

        TestRunner.RunTest("Traversal Parsing - Post-Order", TestTraversalParsingPostOrder,
            "Parse and verify individual values from post-order traversal.");

        Console.WriteLine("\nTesting with Different Data Types...");
        TestRunner.RunTest("BST with Strings", TestBstWithStrings,
            "BST should work with any comparable type, like strings.");

        TestRunner.RunTest("BST with Doubles", TestBstWithDoubles,
            "BST should work with decimal numbers.");

        Console.WriteLine("\nTesting Tree Structure with Custom Objects...");
        TestRunner.RunTest("BST with Custom Product Objects", TestBstWithProducts,
            "BST should work with custom comparable objects like Product.");

        TestRunner.RunTest("Remove and Verify State", TestRemoveAndVerifyState,
            "After removal, verify that Remove returns true and Contains returns false.");
    }

    private static void TestInsertAndContains()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);

        Assertions.AssertEqual(true, bst.Contains(10), "Should contain 10.");
        Assertions.AssertEqual(true, bst.Contains(5), "Should contain 5.");
        Assertions.AssertEqual(true, bst.Contains(15), "Should contain 15.");
        
        Assertions.AssertEqual(false, bst.Contains(99), "Should not contain 99.");
    }

    private static void TestInsertDuplicates()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(10); // Duplicate
        bst.Insert(5);  // Duplicate

        // In-order should still be: 5 10
        string actual = bst.InOrderTraversal().Trim();
        string expected = "5 10";
        Assertions.AssertEqual(actual, expected, "Duplicates should not be added.");
    }

    private static void TestInsertIterative()
    {
        var bst = new Bst<int>();
        bst.InsertIterative(10);
        bst.InsertIterative(5);
        bst.InsertIterative(20);
        bst.InsertIterative(15);
        bst.InsertIterative(7);

        // Should have same result as recursive insert
        string actual = bst.InOrderTraversal().Trim();
        string expected = "5 7 10 15 20";
        Assertions.AssertEqual(actual, expected, "InsertIterative should produce correct BST structure.");
    }

    private static void TestTraversalEmptyTree()
    {
        var bst = new Bst<int>();
        
        string inOrder = bst.InOrderTraversal().Trim();
        string preOrder = bst.PreOrderTraversal().Trim();
        string postOrder = bst.PostOrderTraversal().Trim();

        Assertions.AssertEqual(inOrder, "", "Empty tree in-order should be empty.");
        Assertions.AssertEqual(preOrder, "", "Empty tree pre-order should be empty.");
        Assertions.AssertEqual(postOrder, "", "Empty tree post-order should be empty.");
    }

    private static void TestTraversalSingleNode()
    {
        var bst = new Bst<int>();
        bst.Insert(42);

        string inOrder = bst.InOrderTraversal().Trim();
        string preOrder = bst.PreOrderTraversal().Trim();
        string postOrder = bst.PostOrderTraversal().Trim();

        Assertions.AssertEqual(inOrder, "42", "Single node in-order.");
        Assertions.AssertEqual(preOrder, "42", "Single node pre-order.");
        Assertions.AssertEqual(postOrder, "42", "Single node post-order.");
    }

    private static void TestInOrderTraversal()
    {
        var bst = new Bst<int>();
        // Insert in scrambled order
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);
        bst.Insert(15);
        bst.Insert(7);
        // Tree:
        //      10
        //     /  \
        //    5    20
        //     \   /
        //      7 15

        // In-Order Should be: 5, 7, 10, 15, 20
        int[] expected = { 5, 7, 10, 15, 20 };
        int[] actual = ParseTraversalOutput(bst.InOrderTraversal());

        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "InOrder traversal should return sorted values.");
    }

    private static void TestPreOrderTraversal()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);
        // Tree:
        //    10
        //   /  \
        //  5    20
        
        // Pre-Order: Root(10), Left(5), Right(20) -> "10 5 20"
        int[] expected = { 10, 5, 20 };
        int[] actual = ParseTraversalOutput(bst.PreOrderTraversal());
        
        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "PreOrder traversal mismatch.");
    }

    private static void TestPostOrderTraversal()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);
        
        // Post-Order: Left(5), Right(20), Root(10) -> "5 20 10"
        int[] expected = { 5, 20, 10 };
        int[] actual = ParseTraversalOutput(bst.PostOrderTraversal());

        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "PostOrder traversal mismatch.");
    }

    private static void TestRemoveLeaf()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5); // Leaf

        bool removed = bst.Remove(5);
        Assertions.AssertEqual(true, removed, "Remove should return true.");
        Assertions.AssertEqual(false, bst.Contains(5), "Value should be gone.");
        Assertions.AssertEqual(true, bst.Contains(10), "Root should remain.");
    }

    private static void TestRemoveOneChild()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(2); // 5 has left child 2
        
        // Tree:
        //    10
        //   /
        //  5
        // /
        // 2

        bool removed = bst.Remove(5);
        Assertions.AssertEqual(true, removed, "Remove should return true.");
        Assertions.AssertEqual(false, bst.Contains(5), "5 Should be gone.");
        Assertions.AssertEqual(true, bst.Contains(2), "Child 2 should remain.");
        
        // Verify structure indirectly via Parent check would be ideal, but Contains is OK.
        // If 2 was lost, Contains(2) would fail.
    }

    private static void TestRemoveTwoChildren()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(12);
        bst.Insert(18);
        
        // Remove 15 (has 12 and 18)
        bool removed = bst.Remove(15);
        Assertions.AssertEqual(true, removed, "Remove should return true.");
        Assertions.AssertEqual(false, bst.Contains(15), "15 Should be gone.");
        
        // Children should still exist
        Assertions.AssertEqual(true, bst.Contains(12), "12 should still exist.");
        Assertions.AssertEqual(true, bst.Contains(18), "18 should still exist.");
        
        // Check integrity with in-order traversal (still sorted?)
        int[] expected = { 5, 10, 12, 18 };
        int[] actual = ParseTraversalOutput(bst.InOrderTraversal());
        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "Order should be preserved after deletion.");
    }

    private static void TestRemoveRoot()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);

        bool removed = bst.Remove(10);
        Assertions.AssertEqual(true, removed, "Remove root should return true.");
        Assertions.AssertEqual(false, bst.Contains(10), "Old root should be gone.");
        
        Assertions.AssertEqual(true, bst.Contains(5), "Left child should remain.");
        Assertions.AssertEqual(true, bst.Contains(15), "Right child should remain.");
        
        int[] expected = { 5, 15 };
        int[] actual = ParseTraversalOutput(bst.InOrderTraversal());
        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "Structure should stay valid.");
    }

    private static void TestRemoveRootSingleNode()
    {
        var bst = new Bst<int>();
        bst.Insert(42);

        bool removed = bst.Remove(42);
        Assertions.AssertEqual(true, removed, "Removing only node should return true.");
        Assertions.AssertEqual(false, bst.Contains(42), "Node should be gone.");
        
        // Verify tree is truly empty
        string traversal = bst.InOrderTraversal().Trim();
        Assertions.AssertEqual(traversal, "", "Tree should be completely empty.");
    }

    private static void TestRemoveNonExistent()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);

        bool removed = bst.Remove(999);
        Assertions.AssertEqual(false, removed, "Removing non-existent value should return false.");
        
        // Verify all original nodes still exist
        Assertions.AssertEqual(true, bst.Contains(10), "10 should still be there.");
        Assertions.AssertEqual(true, bst.Contains(5), "5 should still be there.");
        Assertions.AssertEqual(true, bst.Contains(15), "15 should still be there.");
    }

    // ===== HELPER METHODS =====

    /// <summary>
    /// Parses a space-separated traversal output string into an array of integers.
    /// </summary>
    private static int[] ParseTraversalOutput(string traversalOutput)
    {
        string trimmed = traversalOutput.Trim();
        if (string.IsNullOrEmpty(trimmed))
            return Array.Empty<int>();

        return trimmed.Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => int.Parse(s))
            .ToArray();
    }

    /// <summary>
    /// Compares two arrays for equality.
    /// </summary>
    private static bool ArraysEqual<T>(T[] arr1, T[] arr2) where T : IComparable<T>
    {
        if (arr1.Length != arr2.Length)
            return false;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i].CompareTo(arr2[i]) != 0)
                return false;
        }

        return true;
    }

    private static void TestTraversalParsingInOrder()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);
        bst.Insert(15);
        bst.Insert(7);
        bst.Insert(12);
        bst.Insert(25);

        // Expected sorted order: 5, 7, 10, 12, 15, 20, 25
        int[] expected = { 5, 7, 10, 12, 15, 20, 25 };
        int[] actual = ParseTraversalOutput(bst.InOrderTraversal());

        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "In-Order parsing should correctly extract all values in sorted order.");
    }

    private static void TestTraversalParsingPreOrder()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);

        // Pre-Order: Root(10), Left(5), Right(20)
        int[] expected = { 10, 5, 20 };
        int[] actual = ParseTraversalOutput(bst.PreOrderTraversal());

        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "Pre-Order parsing should correctly extract values in root-left-right order.");
    }

    private static void TestTraversalParsingPostOrder()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);

        // Post-Order: Left(5), Right(20), Root(10)
        int[] expected = { 5, 20, 10 };
        int[] actual = ParseTraversalOutput(bst.PostOrderTraversal());

        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "Post-Order parsing should correctly extract values in left-right-root order.");
    }

    private static void TestBstWithStrings()
    {
        var bst = new Bst<string>();
        bst.Insert("dog");
        bst.Insert("cat");
        bst.Insert("elephant");
        bst.Insert("ant");

        Assertions.AssertEqual(true, bst.Contains("dog"), "Should contain 'dog'.");
        Assertions.AssertEqual(true, bst.Contains("cat"), "Should contain 'cat'.");
        Assertions.AssertEqual(true, bst.Contains("elephant"), "Should contain 'elephant'.");
        Assertions.AssertEqual(false, bst.Contains("zebra"), "Should not contain 'zebra'.");

        // In-order should be alphabetically sorted: ant, cat, dog, elephant
        string actual = bst.InOrderTraversal().Trim();
        string[] parsed = actual.Split(' ');
        string[] expected = { "ant", "cat", "dog", "elephant" };

        Assertions.AssertEqual(ArraysEqual(parsed, expected), true, "String BST should maintain alphabetical order.");
    }

    private static void TestBstWithDoubles()
    {
        var bst = new Bst<double>();
        bst.Insert(10.5);
        bst.Insert(5.2);
        bst.Insert(20.8);
        bst.Insert(15.3);
        bst.Insert(7.9);

        Assertions.AssertEqual(true, bst.Contains(10.5), "Should contain 10.5.");
        Assertions.AssertEqual(true, bst.Contains(5.2), "Should contain 5.2.");
        Assertions.AssertEqual(false, bst.Contains(99.9), "Should not contain 99.9.");

        // In-order should be sorted: 5.2, 7.9, 10.5, 15.3, 20.8
        string actual = bst.InOrderTraversal().Trim();
        string[] parsed = actual.Split(' ');
        
        // Parse back to doubles for comparison
        double[] expected = { 5.2, 7.9, 10.5, 15.3, 20.8 };
        double[] actualDoubles = parsed.Select(s => double.Parse(s)).ToArray();

        Assertions.AssertEqual(ArraysEqual(actualDoubles, expected), true, "Double BST should maintain numeric order.");
    }

    private static void TestTreeStructure()
    {
        // Based on the original assignment:
        // Insert: 10, 20, 15, 5, 7
        // Expected tree structure:
        //        10
        //       /  \
        //      5    20
        //       \   /
        //        7 15
        
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(20);
        bst.Insert(15);
        bst.Insert(5);
        bst.Insert(7);

        // Test Root
        Assertions.AssertEqual(bst.Root.Value, 10, "Root should be 10.");

        // Test Root's direct children
        Assertions.AssertEqual(bst.Root.Left.Value, 5, "Root.Left should be 5.");
        Assertions.AssertEqual(bst.Root.Right.Value, 20, "Root.Right should be 20.");

        // Test deeper structure
        Assertions.AssertEqual(bst.Root.Left.Right.Value, 7, "Root.Left.Right should be 7.");
        Assertions.AssertEqual(bst.Root.Right.Left.Value, 15, "Root.Right.Left should be 15.");

        // Build expected array like the original assignment
        int[] actual = new int[] { bst.Root.Value, bst.Root.Left.Value, bst.Root.Right.Value,
                                    bst.Root.Left.Right.Value, bst.Root.Right.Left.Value };
        int[] expected = new int[] { 10, 5, 20, 7, 15 };

        Assertions.AssertEqual(ArraysEqual(actual, expected), true, "Tree structure should match expected layout.");
    }

    private static void TestBstWithProducts()
    {
        var bstProduct = new Bst<Product>();

        var products = new Product[] {
            new Product(35, "Golf", "VW"),              // products[0]
            new Product(45, "TestaRossa", "Ferrari"),   // products[1]
            new Product(40, "ID.3", "VW"),              // products[2]
            new Product(30, "CinqueCento", "Fiat"),     // products[3]
            new Product(32, "ID.2", "VW"),              // products[4]
        };

        // Insert first 5 products
        for (int i = 0; i < 5; ++i)
            bstProduct.Insert(products[i]);

        // Test structure with Product objects (compared by Price)
        // Insert order: 35, 45, 40, 30, 32
        // Tree:
        //        35(Golf)
        //       /        \
        //   30(Fiat)    45(TestaRossa)
        //       \       /
        //    32(ID.2) 40(ID.3)

        Assertions.AssertEqual(bstProduct.Root.Value, products[0], "Root should be Golf (35).");
        Assertions.AssertEqual(bstProduct.Root.Left.Value, products[3], "Root.Left should be CinqueCento (30).");
        Assertions.AssertEqual(bstProduct.Root.Right.Value, products[1], "Root.Right should be TestaRossa (45).");
        Assertions.AssertEqual(bstProduct.Root.Left.Right.Value, products[4], "Root.Left.Right should be ID.2 (32).");
        Assertions.AssertEqual(bstProduct.Root.Right.Left.Value, products[2], "Root.Right.Left should be ID.3 (40).");

        // Build expected array like the original assignment
        var actualProductList = new Product[] { bstProduct.Root.Value, bstProduct.Root.Left.Value, bstProduct.Root.Right.Value,
                                bstProduct.Root.Left.Right.Value, bstProduct.Root.Right.Left.Value };
        var expectedProductList = new Product[] { products[0], products[3], products[1], products[4], products[2] };

        Assertions.AssertEqual(ArraysEqual(actualProductList, expectedProductList), true, "Product BST structure should match expected layout.");
    }

    private static void TestRemoveAndVerifyState()
    {
        // Test that after removal, both Remove() returns true and Contains() returns false
        var bst = new Bst<int>();
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(70);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(60);
        bst.Insert(80);

        // Remove a node with two children
        int valueToRemove = 30;
        Assertions.AssertEqual(true, bst.Contains(valueToRemove), $"Should initially contain {valueToRemove}.");

        bool removeResult = bst.Remove(valueToRemove);
        Assertions.AssertEqual(true, removeResult, $"Remove({valueToRemove}) should return true.");

        bool containsAfterRemove = bst.Contains(valueToRemove);
        Assertions.AssertEqual(false, containsAfterRemove, $"After removal, Contains({valueToRemove}) should return false.");

        // Verify other values still exist
        Assertions.AssertEqual(true, bst.Contains(50), "Root should still be there.");
        Assertions.AssertEqual(true, bst.Contains(20), "Left child should still be there.");
        Assertions.AssertEqual(true, bst.Contains(40), "Right child should still be there.");
    }
}
