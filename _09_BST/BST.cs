namespace _09_BST;

public class Bst<T> : IBst<T> where T : IComparable<T>
{
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);
    public void InsertIterative(T value)
    {
        // case Root is null
        if (Root == null) Root = new TreeNode<T>(value);
   
        var currentNode = Root;
        while (true)
        {
            if (currentNode.Value.CompareTo(value) == 0) return;

            // Go left
            if (value.CompareTo(currentNode.Value) == -1)
            {
                // Left empty = insert
                if (currentNode.Left == null)
                {
                    currentNode.Left = new TreeNode<T>(value, currentNode);
                    break;
                }
                // We must go deeper - left
                currentNode = currentNode.Left;
            }

            // Go right
            if (value.CompareTo(currentNode.Value) == 1)
            {
                // Right empty = insert
                if (currentNode.Right == null)
                {
                    currentNode.Right = new TreeNode<T>(value, currentNode);
                    break;
                }
                // We must go deeper - right
                currentNode = currentNode.Right;
            }
        }
    }

    private void Insert(T value, TreeNode<T>? node)
    {
        // case Root is null
        if (node == null) 
        {
            Root = new TreeNode<T>(value);
            return;
        }
   
        // Value is higher - go right
        if (value.CompareTo(node.Value) == 1)
        {
            if (node.Right == null) 
            {
                node.Right = new TreeNode<T>(value, node);
                return;
            }
            Insert(value, node.Right);
        }

        // left child
        if (value.CompareTo(node.Value) == -1)
        {
            if (node.Left == null) 
            {
                node.Left = new TreeNode<T>(value, node);
                return;
            }
            Insert(value, node.Left);

        }
        if (value.CompareTo(node.Value) == 0)
        {
            // Nope, we already have that value!
            return;
        }        
    }

    #region Traversal

    public string PreOrderTraversal() => PreOrderTraversal(Root);
    private string PreOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode == null) return "";

        string result = currNode.Value.ToString()! + " ";
        result += PreOrderTraversal(currNode.Left);
        result += PreOrderTraversal(currNode.Right);
        return result;
    }

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode == null) return "";

        string result = InOrderTraversal(currNode.Left);
        result += currNode.Value.ToString()! + " ";
        result += InOrderTraversal(currNode.Right);   
        return result;
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode == null) return "";

        string result = PostOrderTraversal(currNode.Left);
        result += PostOrderTraversal(currNode.Right);   
        result += currNode.Value.ToString()! + " ";
        return result;
    }
    #endregion

    public bool Contains(T value) => Search(Root, value) != null; 

    private TreeNode<T>? Search(TreeNode<T>? node, T value)
    {
        // node does not exist
        if (node == null) return node;
        
        // value in the node is the same we are looking for
        if (node.Value.CompareTo(value) == 0) return node;

        // Value is smaller than NODE value
        if (value.CompareTo(node.Value) == -1) return Search(node.Left, value);

        // Value is larger than NODE value
        return Search(node.Right, value);

    }

    #region  Remove Delete

    public bool Remove(T value) => DeleteValue(this, value);

    private bool DeleteValue(Bst<T>? tree, T value)
    { 
        // Why are you even calling this method my man
        if (tree == null || tree.Root == null) return false;

        // special case if the value to delete is in the root (and the root has 0 children or 1 child)
        if (tree.Root.Value.CompareTo(value) == 0)
        {
            // there are no children:
            if (tree.Root.Left == null && tree.Root.Right == null)
            {
                tree.Root = null;
                return true;
            } 

            // there is only left child, the right does not exist
            if (tree.Root.Right == null)
            {
                tree.Root = tree.Root.Right;
                return true;
            }             
            // there is only right child, the left does not exist
            if (tree.Root.Left == null)
            {
                tree.Root = tree.Root.Left;
                return true;
            }

            // Root, but both children are there
            return delete(tree.Root);
        }
        
        // all other cases. Find first the node corresponding to the value we want to delete
        var nodeToDelete = Search(tree.Root, value);
        if (nodeToDelete == null) return false;

        // actually perform the deletion
        return delete(nodeToDelete);
    }

    private bool delete(TreeNode<T> nodeToDelete)
    {
    // If the node is a leaf
    if (nodeToDelete.Left == null && nodeToDelete.Right == null)
    {
        if (nodeToDelete.Parent != null)
        {
            if (isLeft(nodeToDelete, nodeToDelete.Parent))
                nodeToDelete.Parent.Left = null;
            else
                nodeToDelete.Parent.Right = null;
        }
        return true;
    }

    // If the node has one child
    if (nodeToDelete.Left == null || nodeToDelete.Right == null)
    {
        TreeNode<T> child = nodeToDelete.Left ?? nodeToDelete.Right;
        if (nodeToDelete.Parent != null)
        {
            if (isLeft(nodeToDelete, nodeToDelete.Parent))
                nodeToDelete.Parent.Left = child;
            else
                nodeToDelete.Parent.Right = child;
        }
        child.Parent = nodeToDelete.Parent;
        return true;
    }

    // If the node has two children, find the in-order successor
    var inOrderSuccessor = findInOrderSucc(nodeToDelete);
    // Replace value with successor
    nodeToDelete.Value = inOrderSuccessor.Value; 
    // Recursively delete the successor
    return delete(inOrderSuccessor); 
    }

    // This methods finds the in order successor of the node given as parameter
    private TreeNode<T>? findInOrderSucc(TreeNode<T> node)
    {
        var currNode = node.Right;
        while (currNode != null && currNode.Left != null)
            currNode = currNode.Left;

        return currNode;
    }
 
    // This methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). 
    // The comparison is based on the values of the nodes.
    private bool isLeft(TreeNode<T> node, TreeNode<T> parent)
    {
        return parent.Left != null && parent.Left.Value.CompareTo(node.Value) == 0;
    }

    public List<T> Traversal(TraversalOrder traversalOrder) //Optional
    {
        return new List<T>();
    }
    #endregion
}