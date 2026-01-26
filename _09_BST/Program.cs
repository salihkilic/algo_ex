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

        TestRunner.RunTest("In-Order Traversal (Sorting)", TestInOrderTraversal,
            "In-Order traversal of a BST should yield values in sorted ascending order.");

        TestRunner.RunTest("Pre-Order Traversal", TestPreOrderTraversal,
            "Pre-Order should be Root, Left, Right.");

        TestRunner.RunTest("Post-Order Traversal", TestPostOrderTraversal,
            "Post-Order should be Left, Right, Root.");

        Console.WriteLine("\nTesting Removal...");
        TestRunner.RunTest("Remove Leaf Node", TestRemoveLeaf,
            "Removing a leaf (no children) should just unlink it from the parent.");

        TestRunner.RunTest("Remove Node with One Child", TestRemoveOneChild,
            "Removing a node with one child should link the parent directly to that child.");

        TestRunner.RunTest("Remove Node with Two Children", TestRemoveTwoChildren,
            "Removing a node with two children requires finding a successor (or predecessor) and swapping/replacing.");

        TestRunner.RunTest("Remove Root", TestRemoveRoot,
            "Removing the root is a special case. The new root should be correctly assigned.");
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
        string expected = "5 7 10 15 20 ";
        string actual = bst.InOrderTraversal();

        // Note: The provided implementation adds a space after every item.
        Assertions.AssertEqual(actual.Trim(), expected.Trim(), "InOrder traversal should return sorted values.");
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
        string actual = bst.PreOrderTraversal();
        
        Assertions.AssertEqual(actual.Trim(), expected, "PreOrder traversal mismatch.");
    }

    private static void TestPostOrderTraversal()
    {
        var bst = new Bst<int>();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(20);
        
        // Post-Order: Left(5), Right(20), Root(10) -> "5 20 10"
        string expected = "5 20 10";
        string actual = bst.PostOrderTraversal();

        Assertions.AssertEqual(actual.Trim(), expected, "PostOrder traversal mismatch.");
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
        string actual = bst.InOrderTraversal();
        string expected = "5 10 12 18";
        Assertions.AssertEqual(actual.Trim(), expected, "Order should be preserved after deletion.");
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
        
        string actual = bst.InOrderTraversal();
        string expected = "5 15";
        Assertions.AssertEqual(actual.Trim(), expected, "Structure should stay valid.");
    }
}
