namespace _09_BST;

public class Bst<T> : IBst<T> where T : IComparable<T>
{
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);
    
    public void InsertIterative(T value)
    {
        if (Root is null)
            Root = new TreeNode<T>(value);

        var current = Root;
        while (current is not null)
        {
            switch (value.CompareTo(current.Value))
            {
                case -1:
                    if (current.Left is null)
                    {
                        current.Left = new TreeNode<T>(value, current);
                        return;
                    }
                    current = current.Left;
                        continue;
                    
                case 0:
                    return;
                
                case 1:
                    if (current.Right is null)
                    {
                        current.Right = new TreeNode<T>(value, current);
                        return;
                    }
                    current = current.Right;
                    continue;
            }
        }
    }

    private void Insert(T value, TreeNode<T>? node)
    {
        if (node is null)
        {
            Root = new TreeNode<T>(value);
            return;
        }
        
        switch (value.CompareTo(node.Value))
        {
            case -1:
                if (node.Left is null)
                {
                    node.Left = new TreeNode<T>(value, node);
                    return;
                }
                Insert(value, node.Left);
                return;
                    
            case 0:
                return;
                
            case 1:
                if (node.Right is null)
                {
                    node.Right = new TreeNode<T>(value, node);
                    return;
                }
                Insert(value, node.Right);
                return;
        }
    }

    #region Traversal

    // TIP:
    // - Zit alles voor, na of om root heen?
    // - We slaan de string op als we op root zitten, de rest traversen we
    
    public string PreOrderTraversal() => PreOrderTraversal(Root);
    
    private string PreOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode is null)
            return string.Empty;
        
        var result = string.Empty;
        result += $"{currNode.Value} ";
        result += PreOrderTraversal(currNode.Left);
        result += PreOrderTraversal(currNode.Right);
        return result;
    }

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode is null)
            return string.Empty;
        
        var result = string.Empty;
        
        result += InOrderTraversal(currNode.Left);
        result += $"{currNode.Value} ";
        result += InOrderTraversal(currNode.Right);
        return result;
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode is null)
            return string.Empty;
        
        var result = string.Empty;
        result += PostOrderTraversal(currNode.Left);
        result += PostOrderTraversal(currNode.Right);
        result += $"{currNode.Value} ";
        return result;
    }
    #endregion

    public bool Contains(T value) => Search(Root, value) is not null; 

    private TreeNode<T>? Search(TreeNode<T>? node, T value)
    {
        if (node is null)
            return null;
        
        switch (value.CompareTo(node.Value))
        {
            case -1:
                if (node.Left is null)
                    return null;
                return Search(node.Left, value);
            
            case 0:
                return node;
                
            case 1:
                if (node.Right is null)
                    return null;
                return Search(node.Right, value);
        }

        return null;
    }

    #region  Remove Delete

    public bool Remove(T value) => DeleteValue(this, value);

    private bool DeleteValue(Bst<T>? tree, T value)
    {
        if (tree is null) return false;
        var node = Search(tree?.Root, value);
        if (node is not null)
            return Delete(node);
        return false;
    }

    private bool Delete(TreeNode<T> nodeToDelete)
    {
        // One or no child
        if (nodeToDelete.Left is null || nodeToDelete.Right is null)
        {
            var replacement = nodeToDelete.Left ?? nodeToDelete.Right;

            if (nodeToDelete.Parent is null) // is root
            {
                Root = replacement;
                replacement?.Parent = null;
                return true;
            }

            if (nodeToDelete.Parent.Left == nodeToDelete)
                nodeToDelete.Parent.Left = replacement;
            else
                nodeToDelete.Parent.Right = replacement;

            replacement?.Parent = nodeToDelete.Parent;
            return true;
        }
        
        // Two children
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