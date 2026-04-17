namespace _10_Graph;

public class Graph
{
    public double[,] AdjacencyMatrix { get; set; }
    public int Count { get { return AdjacencyMatrix.GetLength(0); } }  //Number of nodes in the graph

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
        string resultStr = "";
        // create empty queue and enqueue the root
        Queue<int> traverse = new Queue<int>();
        traverse.Enqueue(root);

        // create array of booleans to keep track of visited nodes and set the root flag to true
        bool[] closed = new bool[Count];
        closed[root] = true;

        // Loop until queue is empty
        while (traverse.Count > 0)
        {
            int current = traverse.Dequeue();
            resultStr += " " + current.ToString();


            foreach (var n in Neighbors(current))
            {
                if (!closed[n])
                {
                    traverse.Enqueue(n);
                    closed[n] = true;
                }
            }
        }
        return resultStr;
    }

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
        string resultStr = "";
        // create empty queue and enqueue the root
        Stack<int> traverse = new Stack<int>();
        traverse.Push(root);

        // create array of booleans to keep track of visited nodes and set the root flag to true
        bool[] closed = new bool[Count];
        closed[root] = true;

        // Loop until queue is empty
        while (traverse.Count > 0)
        {
            int current = traverse.Pop();
            resultStr += " " + current.ToString();


            foreach (var n in NeighborsReversed(current))
            {
                if (!closed[n])
                {
                    traverse.Push(n);
                    closed[n] = true;
                }
            }
        }
        return resultStr;
        // create empty stack and push the root into it

        // create array of booleans to keep track of visited nodes

        // Loop until stack is empty

        // pop a node from the stack 

        // check if current node is not visited yet
        // add current node to the string (followed by a space) and set it to visited

        // find neighbors (in reversed order) of current  

        // push all neighbors 
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



        double[] dist = new double[Count];
        int[] prev = new int[Count];
        bool[] visited = new bool[Count];

        for (int i = 0; i < Count; i++)
        {
            dist[i] = double.PositiveInfinity;
            prev[i] = -1;
        }
        // set distance of source
        dist[source] = 0;

        for (int step = 0; step < Count; step++)
        {
            int current = -1;
            double smallest = double.PositiveInfinity;

            for (int i = 0; i < Count; i++)
            {
                if (!visited[i] && dist[i] < smallest)
                {
                    smallest = dist[i];
                    current = i;
                }
            }

            if (current == -1)
                break;

            visited[current] = true;

            foreach(var n in Neighbors(current))
            {
                if (visited[n]) continue;

                var newDist = dist[current] + AdjacencyMatrix[current, n];

                if (newDist < dist[n])
                {
                    dist[n] = newDist;
                    prev[n] = current;
                }
            }
        }
        return Tuple.Create(dist, prev);
    }
}
