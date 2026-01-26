using System.Collections.Generic;

namespace _09_BST;


public interface IBst<T> where T : IComparable<T>
{
    /// <summary>
    /// Inserts a new value into the Binary Search Tree.
    /// The value should be placed according to BST rules:
    /// - Smaller values go to the left subtree.
    /// - Larger values go to the right subtree.
    /// - Duplicate values are typically ignored or handled specifically (here: ignored).
    /// </summary>
    /// <param name="value">The value to insert.</param>
    void Insert(T value);

    /// <summary>
    /// Removes a value from the BST.
    /// This is the most complex operation. It must handle three cases:
    /// 1. Node to delete is a leaf (no children).
    /// 2. Node to delete has one child.
    /// 3. Node to delete has two children (find in-order successor or predecessor).
    /// </summary>
    /// <param name="value">The value to remove.</param>
    /// <returns>True if the value was found and removed, false otherwise.</returns>
    bool Remove(T value);

    /// <summary>
    /// Checks if a value exists in the BST.
    /// Should efficiently search by exploiting the BST property (O(log n) on average).
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>True if found, false otherwise.</returns>
    bool Contains(T value);

    /// <summary>
    /// Performs a Pre-Order traversal (Root, Left, Right).
    /// Returns a string representation of the values.
    /// </summary>
    /// <returns>Space-separated string of values.</returns>
    string PreOrderTraversal();

    /// <summary>
    /// Performs an In-Order traversal (Left, Root, Right).
    /// This should result in widely sorted values.
    /// Returns a string representation of the values.
    /// </summary>
    /// <returns>Space-separated string of values.</returns>
    string InOrderTraversal();

    /// <summary>
    /// Performs a Post-Order traversal (Left, Right, Root).
    /// Returns a string representation of the values.
    /// </summary>
    /// <returns>Space-separated string of values.</returns>
    string PostOrderTraversal();

    /// <summary>
    /// Helper method to return a list of items in the specified traversal order.
    /// </summary>
    /// <param name="traversalOrder">The enum value specifying the order.</param>
    /// <returns>A list containing the values in order.</returns>
    List<T>? Traversal(TraversalOrder traversalOrder);

}
public enum TraversalOrder { PreOrder, InOrder, PostOrder };