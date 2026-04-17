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

        TestRunner.RunTest("Contains Method (Search)", TestContainsMethod,
            "Contains should return true for existing values and false for non-existing values.");

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

        TestRunner.RunTest("Remove Root with One Child - Parent Invariant", TestRemoveRootOneChildParentInvariant,
            "When removing root with one child, the new root's Parent must be null (invariant check).");

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

        // Verify structure directly via node navigation (no dependency on Contains or traversals)
        Assertions.AssertEqual(bst.Root.Value, 10, "Root should be 10.");
        Assertions.AssertEqual(bst.Root.Left.Value, 5, "Root.Left should be 5.");
        Assertions.AssertEqual(bst.Root.Right.Value, 15, "Root.Right should be 15.");
    }

    private static void TestInsertDuplicates()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(10); // Duplicate
        bst.Insert(5);  // Duplicate

        // Verify duplicates weren't added by checking tree structure
        // Should still be: 10 root, 5 left, and no extra nodes
        Assertions.AssertEqual(bst.Root.Value, 10, "Root should be 10.");
        Assertions.AssertEqual(bst.Root.Left.Value, 5, "Left should be 5.");
        Assertions.AssertEqual(bst.Root.Left.Left, null, "Left.Left should be null (no duplicate 5).");
        Assertions.AssertEqual(bst.Root.Left.Right, null, "Left.Right should be null (no duplicate 5).");
    }

    private static void TestInsertIterative()
    {
        var bst = new Bst<int>();
        bst.InsertIterative(10);
        bst.InsertIterative(5);
        bst.InsertIterative(20);
        bst.InsertIterative(15);
        bst.InsertIterative(7);

        // Verify structure directly via node navigation (no dependency on traversals)
        // Expected: 10 root, 5 left, 20 right, 7 is right of 5, 15 is left of 20
        Assertions.AssertEqual(bst.Root.Value, 10, "Root should be 10.");
        Assertions.AssertEqual(bst.Root.Left.Value, 5, "Left should be 5.");
        Assertions.AssertEqual(bst.Root.Right.Value, 20, "Right should be 20.");
        Assertions.AssertEqual(bst.Root.Left.Right.Value, 7, "Left.Right should be 7.");
        Assertions.AssertEqual(bst.Root.Right.Left.Value, 15, "Right.Left should be 15.");
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

        // In-Order Should be: 5, 7, 10, 15, 20 (left, root, right)
        string actual = bst.InOrderTraversal().Trim();
        string expected = "5 7 10 15 20";

        Assertions.AssertEqual(actual, expected, "InOrder traversal should return sorted values.");
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
        string expected = "10 5 20";
        string actual = bst.PreOrderTraversal().Trim();
        
        Assertions.AssertEqual(actual, expected, "PreOrder traversal mismatch.");
    }

    private static void TestPostOrderTraversal()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);
        
        // Post-Order: Left(5), Right(20), Root(10) -> "5 20 10"
        string expected = "5 20 10";
        string actual = bst.PostOrderTraversal().Trim();

        Assertions.AssertEqual(actual, expected, "PostOrder traversal mismatch.");
    }

    private static void TestRemoveLeaf()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5); // Leaf

        bool removed = bst.Remove(5);
        Assertions.AssertEqual(true, removed, "Remove should return true.");
        
        // Verify structure: 5 should be gone from root.left
        Assertions.AssertEqual(bst.Root.Left, null, "Left child should be null after removing leaf 5.");
        Assertions.AssertEqual(bst.Root.Value, 10, "Root should still be 10.");
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
        
        // After removing 5, its child 2 should move up
        Assertions.AssertEqual(bst.Root.Left.Value, 2, "After removing 5, its child 2 should replace it.");
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
        
        // Verify structure still valid: root should still have right child
        Assertions.AssertEqual(bst.Root.Value, 10, "Root should still be 10.");
        Assertions.AssertEqual(bst.Root.Right != null, true, "Right child should exist after removing 15.");
    }

    private static void TestRemoveRoot()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);

        bool removed = bst.Remove(10);
        Assertions.AssertEqual(true, removed, "Remove root should return true.");
        
        // After removing root, tree should still have structure
        Assertions.AssertEqual(bst.Root != null, true, "Root should exist after removal.");
        Assertions.AssertEqual(bst.Root.Value != 10, true, "Root value should have changed.");
    }

    private static void TestRemoveRootSingleNode()
    {
        var bst = new Bst<int>();
        bst.Insert(42);

        bool removed = bst.Remove(42);
        Assertions.AssertEqual(true, removed, "Removing only node should return true.");
        Assertions.AssertEqual(bst.Root, null, "Tree should be completely empty.");
    }

    private static void TestRemoveRootOneChildParentInvariant()
    {
        // This test catches the bug if "replacement?.Parent = null;" is removed
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);  // Root has only left child

        bool removed = bst.Remove(10);
        Assertions.AssertEqual(true, removed, "Removing root should return true.");
        
        // Verify the new root is correct
        Assertions.AssertEqual(bst.Root.Value, 5, "New root should be 5.");
        
        // CRITICAL: Verify the Parent pointer invariant
        // The root must always have Parent == null
        Assertions.AssertEqual(bst.Root.Parent, null, 
            "Root's Parent must be null (if this fails, 'replacement?.Parent = null;' was removed).");
    }

    private static void TestRemoveNonExistent()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);

        bool removed = bst.Remove(999);
        Assertions.AssertEqual(false, removed, "Removing non-existent value should return false.");
        
        // Verify structure unchanged
        Assertions.AssertEqual(bst.Root.Value, 10, "Root should still be 10.");
        Assertions.AssertEqual(bst.Root.Left.Value, 5, "Left should still be 5.");
        Assertions.AssertEqual(bst.Root.Right.Value, 15, "Right should still be 15.");
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
        string expected = "5 7 10 12 15 20 25";
        string actual = bst.InOrderTraversal().Trim();

        Assertions.AssertEqual(actual, expected, "In-Order should be sorted.");
    }

    private static void TestTraversalParsingPreOrder()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);

        // Pre-Order: Root(10), Left(5), Right(20)
        string expected = "10 5 20";
        string actual = bst.PreOrderTraversal().Trim();

        Assertions.AssertEqual(actual, expected, "Pre-Order should be root-left-right.");
    }

    private static void TestTraversalParsingPostOrder()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);

        // Post-Order: Left(5), Right(20), Root(10)
        string expected = "5 20 10";
        string actual = bst.PostOrderTraversal().Trim();

        Assertions.AssertEqual(actual, expected, "Post-Order should be left-right-root.");
    }

    private static void TestBstWithStrings()
    {
        var bst = new Bst<string>();
        bst.Insert("dog");
        bst.Insert("cat");
        bst.Insert("elephant");
        bst.Insert("ant");

        // Verify structure directly (no Contains dependency)
        Assertions.AssertEqual(bst.Root.Value, "dog", "Root should be 'dog'.");
        Assertions.AssertEqual(bst.Root.Left.Value, "cat", "Left should be 'cat'.");
        Assertions.AssertEqual(bst.Root.Left.Left.Value, "ant", "Left.Left should be 'ant'.");
    }

    private static void TestBstWithDoubles()
    {
        var bst = new Bst<double>();
        bst.Insert(10.5);
        bst.Insert(5.2);
        bst.Insert(20.8);
        bst.Insert(15.3);
        bst.Insert(7.9);

        // Verify structure directly (no Contains dependency)
        Assertions.AssertEqual(bst.Root.Value, 10.5, "Root should be 10.5.");
        Assertions.AssertEqual(bst.Root.Left.Value, 5.2, "Left should be 5.2.");
        Assertions.AssertEqual(bst.Root.Right.Value, 20.8, "Right should be 20.8.");
        Assertions.AssertEqual(bst.Root.Left.Right.Value, 7.9, "Left.Right should be 7.9.");
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

    private static void TestContainsMethod()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);
        bst.Insert(15);
        bst.Insert(7);
        bst.Insert(25);

        // Test Contains for existing values
        Assertions.AssertEqual(true, bst.Contains(10), "Should contain root value 10.");
        Assertions.AssertEqual(true, bst.Contains(5), "Should contain left value 5.");
        Assertions.AssertEqual(true, bst.Contains(20), "Should contain right value 20.");
        Assertions.AssertEqual(true, bst.Contains(15), "Should contain nested value 15.");
        Assertions.AssertEqual(true, bst.Contains(7), "Should contain nested value 7.");
        Assertions.AssertEqual(true, bst.Contains(25), "Should contain nested value 25.");

        // Test Contains for non-existing values
        Assertions.AssertEqual(false, bst.Contains(1), "Should not contain 1.");
        Assertions.AssertEqual(false, bst.Contains(6), "Should not contain 6.");
        Assertions.AssertEqual(false, bst.Contains(12), "Should not contain 12.");
        Assertions.AssertEqual(false, bst.Contains(50), "Should not contain 50.");
        Assertions.AssertEqual(false, bst.Contains(999), "Should not contain 999.");

        // Test Contains on empty tree
        var emptyBst = new Bst<int>();
        Assertions.AssertEqual(false, emptyBst.Contains(10), "Empty tree should not contain any value.");
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

        // Verify structure directly via node navigation
        Assertions.AssertEqual(bstProduct.Root.Value, products[0], "Root should be Golf (35).");
        Assertions.AssertEqual(bstProduct.Root.Left.Value, products[3], "Root.Left should be CinqueCento (30).");
        Assertions.AssertEqual(bstProduct.Root.Right.Value, products[1], "Root.Right should be TestaRossa (45).");
        Assertions.AssertEqual(bstProduct.Root.Left.Right.Value, products[4], "Root.Left.Right should be ID.2 (32).");
        Assertions.AssertEqual(bstProduct.Root.Right.Left.Value, products[2], "Root.Right.Left should be ID.3 (40).");
    }

    private static void TestRemoveAndVerifyState()
    {
        // Test that after removal, structure is updated correctly
        var bst = new Bst<int>();
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(70);

        int valueToRemove = 30;
        Assertions.AssertEqual(bst.Root.Left.Value, valueToRemove, $"Should initially have {valueToRemove} as left child.");

        bool removeResult = bst.Remove(valueToRemove);
        Assertions.AssertEqual(true, removeResult, $"Remove({valueToRemove}) should return true.");

        // Verify 30 is no longer in the left position
        Assertions.AssertEqual(bst.Root.Left == null || bst.Root.Left.Value != valueToRemove, true, 
            $"After removal, {valueToRemove} should not be at root.left.");
    }
}
