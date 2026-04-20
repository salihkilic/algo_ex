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
        // Step 1: Initialize
        var distances = new double[Count];
        var previousNodes = new int[Count];
        var visitedNodes = new bool[Count];
        
        // Set all distances to infinity, predecessors to -1
        for (int i = 0; i < Count; i++)
        {
            distances[i] = double.PositiveInfinity;
            previousNodes[i] = -1;
        }
        
        // Source starts at distance 0
        distances[source] = 0;
        
        // Step 2: Process all unvisited nodes
        while (true)
        {
            // Find the unvisited node closest to source
            int closestNode = -1;
            double closestDistance = double.PositiveInfinity;
            
            for (int i = 0; i < Count; i++)
            {
                if (!visitedNodes[i] && distances[i] < closestDistance)
                {
                    closestDistance = distances[i];
                    closestNode = i;
                }
            }
            
            // If no reachable (unvisited) nodes can be found, stop
            if (closestNode == -1)
                break;
            
            // Step 3: Update distances to all neighbors of closest
            visitedNodes[closestNode] = true;
            var neighbors = Neighbors(closestNode);
            
            foreach (int neighbor in neighbors)
            {
                if (!visitedNodes[neighbor])
                {
                    // Distance through closest node
                    double newDistance = distances[closestNode] + AdjacencyMatrix[closestNode, neighbor];
                    
                    // If shorter path found, update distance and predecessor
                    if (newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                        previousNodes[neighbor] = closestNode;
                    }
                }
            }
        }
        
        return new Tuple<double[], int[]>(distances, previousNodes);
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
