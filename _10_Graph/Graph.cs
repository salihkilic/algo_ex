namespace _10_Graph;

public class Graph
{
    public double[,] AdjacencyMatrix { get; set; }
    public int Count => AdjacencyMatrix.GetLength(0); //Number of nodes in the graph

    public Graph(double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new System.ArgumentException("The adjacency matrix must be a square matrix");
        AdjacencyMatrix = matrix;
    }

    /// <summary>
    /// Performs a Breadth-First Traversal (BFT) starting from the specified root node.
    /// BFT explores the neighbor nodes first, before moving to the next level neighbors.
    /// Use a Queue to manage the traversal order.
    /// </summary>
    /// <param name="root">The index of the starting node (0-based).</param>
    /// <returns>A string representation of the visited nodes in order (e.g. "0 1 2 ").</returns>
    //Breadth First Traversal
    public string Bft(int root)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Performs a Depth-First Traversal (DFT) starting from the specified root node.
    /// DFT explores as far as possible along each branch before backtracking.
    /// Use a Stack to manage the traversal order.
    /// </summary>
    /// <param name="root">The index of the starting node (0-based).</param>
    /// <returns>A string representation of the visited nodes in order.</returns>
    //Depth First Traveral
    public string DFT(int root)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Implements Dijkstra's Algorithm to find the shortest paths from a single source node to all other nodes.
    /// The graph is represented by the AdjacencyMatrix where positive infinity indicates no edge.
    /// </summary>
    /// <param name="source">The index of the source node.</param>
    /// <returns>
    /// A Tuple containing:
    /// Item1 (double[]): The shortest distances from the source to each node.
    /// Item2 (int[]): The predecessor array (previous node index) for reconstructing the path. 
    ///                Value -1 indicates no predecessor or start node.
    /// </returns>
    //Dijkstra's algorithm SingleSourceShortestPath 
    public Tuple<double[], int[]> SingleSourceShortestPath(int source)
    {
        throw new NotImplementedException();
    }
    
    // UTILITY METHODS
    
    //Nodes adjacent to a given node
    public List<int> Neighbors(int node)
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        return neighbors;
    }

    //Nodes (adjacent to a given node) to be visited in reversed order
    public List<int> NeighborsReversed(int node) 
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        neighbors.Reverse();
        return neighbors;
    }
}
