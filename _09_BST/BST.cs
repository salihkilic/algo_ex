namespace _09_BST;

public class Bst<T> : IBst<T> where T : IComparable<T>
{
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);
    
    // TIPS: 
    // - 
    
    
    public void InsertIterative(T value)
    {
        throw new NotImplementedException();
    }

    private void Insert(T value, TreeNode<T>? node)
    {
        throw new NotImplementedException();
    }

    #region Traversal

    // TIP:
    // - Zit alles voor, na of om root heen?
    // - We slaan de string op als we op root zitten, de rest traversen we
    
    public string PreOrderTraversal() => PreOrderTraversal(Root);
    
    private string PreOrderTraversal(TreeNode<T>? currNode)
    {
        throw new NotImplementedException();
    }

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
    {
        throw new NotImplementedException();
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
    {
        throw new NotImplementedException();
    }
    #endregion

    public bool Contains(T value) => throw new NotImplementedException(); 

    private TreeNode<T>? Search(TreeNode<T>? node, T value)
    {
        throw new NotImplementedException();
    }

    #region  Remove Delete

    public bool Remove(T value) => throw new NotImplementedException();

    private bool DeleteValue(Bst<T>? tree, T value)
    {
        throw new NotImplementedException();
    }

    private bool Delete(TreeNode<T> nodeToDelete)
    {
        // Basically twee cases:
        //   - We hebben 0/1 children, makkelijk, gewoon verwijderen
        //   - We hebben 2 children, we vervangen de value van ToDelete met de InOrderSuccessor (1 keer rechts, rest links).
        //   - Daarna verwijder je de successor met een recursieve call
        
        throw new NotImplementedException();
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