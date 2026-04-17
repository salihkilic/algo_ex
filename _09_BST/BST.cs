namespace _09_BST;

public class Bst<T> : IBst<T> where T : IComparable<T>
{
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);
    public void InsertIterative(T value)
    {
        if (Root is null)
        {
            Root = new TreeNode<T>(value);
            return;
        }

        var current = Root;
        TreeNode<T>? parent = null;

        while (current is not null)
        {
            parent = current;
            
            switch (value.CompareTo(current.Value))
            {
                case -1:
                    current = current.Left;
                    break;
                case 0:
                    // Don't add, already contains value
                    return;
                case 1:
                    current = current.Right;
                    break;
            }
        }

        if (parent is null) return;

        switch (value.CompareTo(parent.Value))
        {
            case -1:
                parent.Left = new TreeNode<T>(value, parent);
                break;
            case 1:
                parent.Right = new TreeNode<T>(value, parent);
                break;
        }

    }

    private void Insert(T value, TreeNode<T>? node)
    {
        if (Root is null)
        {
            Root = new TreeNode<T>(value);
            return;
        }

        // If root is not null, but node is, user error.
        if (node is null) return;

        switch (value.CompareTo(node.Value))
        {
            case -1:
                if (node.Left is null)
                {
                    node.Left = new TreeNode<T>(value, node);
                    return;
                }

                Insert(value, node.Left);
                break;
            case 0:
                // Value already exists, return
                return;
            case 1:
                if (node.Right is null)
                {
                    node.Right = new TreeNode<T>(value, node);
                    return;
                }

                Insert(value, node.Right);
                break;
        }
    }

    #region Traversal

    public string PreOrderTraversal() => PreOrderTraversal(Root);
    
    private string PreOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode is null)
            return "";
        
        // root
        string result = currNode.Value + " ";
        // left 
        result += PreOrderTraversal(currNode.Left);
        // right
        result += PreOrderTraversal(currNode.Right);

        return result;
    }

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
    {
        // left
        // root
        // right

        string result = string.Empty;
        
        if (currNode is null)
            return result;

        result += InOrderTraversal(currNode.Left);
        result += currNode.Value + " ";
        result += InOrderTraversal(currNode.Right);

        return result;
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
    {
        // left
        // right
        // root
        string result = string.Empty;
        
        if (currNode is null)
            return result;

        result += PostOrderTraversal(currNode.Left);
        result += PostOrderTraversal(currNode.Right);
        result += currNode.Value + " ";
        
        return result;
    }
    #endregion

    public bool Contains(T value) => Search(Root, value) is not null; 

    private TreeNode<T>? Search(TreeNode<T>? node, T value)
    {
        if (node is null) return null;

        switch (value.CompareTo(node.Value))
        {
            case -1:
                return Search(node.Left, value);
            case 0:
                // Value already exists, return
                return node;
            case 1:
                return Search(node.Right, value);
        }

        return null;
    }

    #region  Remove Delete

    public bool Remove(T value) => DeleteValue(this, value);

    private bool DeleteValue(Bst<T>? tree, T value)
    {
        var toDelete = Search(tree?.Root, value);

        if (toDelete is null) return false;

        return Delete(toDelete);
    }

    private bool Delete(TreeNode<T> nodeToDelete)
    {
        // Case leaf and one child
        // Just remove it
        if (nodeToDelete.Left is null || nodeToDelete.Right is null)
        {
            var replacement = nodeToDelete.Left ?? nodeToDelete.Right;

            // nodeToDelete is root
            if (nodeToDelete.Parent is null)
            {
                Root = replacement;
                replacement?.Parent = null;
                return true;
            }

            // Replace parent reference
            if (nodeToDelete.Parent.Left == nodeToDelete)
                nodeToDelete.Parent.Left = replacement;
            else if (nodeToDelete.Parent.Left == nodeToDelete)
                nodeToDelete.Parent.Right = replacement;

            replacement?.Parent = nodeToDelete.Parent;
            return true;
        }
        
        // Case multiple children:
        // Replace with successor value and delete successor node (recursively)

        var successor = nodeToDelete.Right;
        while (successor.Left is not null)
            successor = successor.Left;

        nodeToDelete.Value = successor.Value;

        return Delete(successor);
    }

    // This methods finds the in order successor of the node given as parameter
    private TreeNode<T>? FindInOrderSucc(TreeNode<T> node)
    {
        var currNode = node.Right;
        while (currNode != null && currNode.Left != null)
            currNode = currNode.Left;

        return currNode;
    }
 
    // This methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). 
    // The comparison is based on the values of the nodes.
    private bool IsLeft(TreeNode<T> node, TreeNode<T> parent)
    {
        return parent.Left != null && parent.Left.Value.CompareTo(node.Value) == 0;
    }

    public List<T> Traversal(TraversalOrder traversalOrder) //Optional
    {
        throw new NotImplementedException();
    }
    #endregion
}