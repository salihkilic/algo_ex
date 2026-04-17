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
        // create empty queue and enqueue the root

        // create array of booleans to keep track of visited nodes and set the root flag to true

        // Loop until queue is empty
        
        // dequeue a node
            

        // add the current node (followed by a space) to the string
            

        // find neighbors of current

        // enqueue all neighbors which are not visited yet and set them to visited
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
        // create empty stack and push the root into it

        // create array of booleans to keep track of visited nodes

        // Loop until stack is empty
        
        // pop a node from the stack 
      
        // check if current node is not visited yet
        // add current node to the string (followed by a space) and set it to visited

        // find neighbors (in reversed order) of current  
            
        // push all neighbors 

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
        // initialization of distance, prev and unvisitedNodes
        // default distance: double.PositiveInfinity
        // default previous node: -1

        // set distance of source
        
        // Loop until unvisitedNodes is empty
  
        // find closest node in unvisitedNodes
       
        // remove the closest node from unvisitedNodes

        //considering all neighbors of the closest node

        // calculate distance and update distance (and previous node) if smaller

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
