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
        var q = new Queue<int>();
        q.Enqueue(root);

        var visited = new bool[Count];
        visited[root] = true;

        var result = string.Empty;

        while (q.Count > 0)
        {
            var node = q.Dequeue();
            visited[node] = true;

            result += $"{node} ";

            var nbs = Neighbors(node);

            foreach (var nb in nbs)
            {
                if (!visited[nb])
                {
                    q.Enqueue(nb);
                    visited[nb] = true;
                }
            }
        }

        return result;
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
        var s = new Stack<int>();
        s.Push(root);

        var visited = new bool[Count];
        visited[root] = true;

        var result = string.Empty;

        while (s.Count > 0)
        {
            var node = s.Pop();
            result += $"{node} ";

            var nbs = NeighborsReversed(node);

            foreach (var nb in nbs)
            {
                if (!visited[nb])
                {
                    s.Push(nb);
                    visited[nb] = true;
                }
            }
        }

        return result;
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
        var distances = new double[Count];
        var previous = new int[Count];
        var visited = new bool[Count];

        for (int i = 0; i < Count; i++)
        {
            distances[i] = double.PositiveInfinity;
            previous[i] = -1;
        }

        distances[source] = 0;

        while (true)
        {
            var closestNode = -1;
            var closestDistance = double.PositiveInfinity;

            for (int i = 0; i < Count; i++)
            {
                if (!visited[i] && distances[i] < closestDistance)
                {
                    closestDistance = distances[i];
                    closestNode = i;
                }
            }

            if (closestNode == -1)
                break;

            visited[closestNode] = true;
            var nbs = Neighbors(closestNode);

            foreach (var nb in nbs)
            {
                if (!visited[nb])
                {
                    var newDistance = distances[closestNode] + AdjacencyMatrix[closestNode, nb];
                    if (newDistance < distances[nb])
                    {
                        distances[nb] = newDistance;
                        previous[nb] = closestNode;
                    }
                }
            }
        }

        return new Tuple<double[], int[]>(distances, previous);
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
