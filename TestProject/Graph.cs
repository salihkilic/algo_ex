namespace Solution;

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

    //Breadth First Traversal
    public string BFT(int root)
    {
        // create empty queue and enqueue the root
        var q = new Queue<int>();
        q.Enqueue(root);

        // create array of booleans to keep track of visited nodes and set the root flag to true
        var visited = new bool[Count];
        visited[root] = true;

        string result = "";

        // Loop until queue is empty
        while (q.Count > 0)
        {
            // dequeue a node
            var currentNode = q.Dequeue();

            // add the current node (followed by a space) to the string
            result += $"{currentNode} ";            

            // find neighbors of current
            var buurmannen = Neighbors(currentNode);
            
            // enqueue all neighbors which are not visited yet and set them to visited
            foreach (int buurman in buurmannen)
            {
                // Set visit
                if (!visited[buurman]) 
                {
                    q.Enqueue(buurman);
                    visited[buurman] = true;
                } 
            }
        }
        return result;
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
    
    //Depth First Traveral
    public string DFT(int root)
    {
        // Initialize an empty stack and push the root node onto it
        var stack = new Stack<int>();
        stack.Push(root);

        // Create an array to track visited nodes
        var visited = new bool[Count];
        visited[root] = true;

        // Initialize an empty string to store the traversal result
        string result = $"{root} ";

        // Loop until the stack is empty
        while (stack.Count > 0)
        {
            // Pop a node from the stack
            var currentNode = stack.Pop();

            // If the node is not visited, visit it
            if (!visited[currentNode])
            {
                // Add the current node to the result string
                result += $"{currentNode} ";

                // Mark the current node as visited
                visited[currentNode] = true;
            }
            // Get the neighbors of the current node (in reversed order)
            var neighbors = NeighborsReversed(currentNode);

            // Push all unvisited neighbors onto the stack
            foreach (var neighbor in neighbors)
            {
                if (!visited[neighbor])
                {
                    stack.Push(neighbor);
                }
            }
        }
        return result;
    }

    //Dijkstra's algorithm SingleSourceShortestPath 
    public Tuple<double[], int[]> SingleSourceShortestPath(int source)
    {
        // Init
        int nodeCount = Count;
        double[] dist = new double[nodeCount];
        int[] prev = new int[nodeCount]; 
        bool[] unvisitedNodes = new bool[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            dist[i] = double.PositiveInfinity;
            prev[i] = -1;
            unvisitedNodes[i] = true; 
        }

        dist[source] = 0; 

        while (true)
        {
            int pickedNode = -1;
            double minDist = double.PositiveInfinity;
            for (int i = 0; i < nodeCount; i++)
            {
                if (unvisitedNodes[i] && dist[i] < minDist)
                {
                    minDist = dist[i];
                    pickedNode = i;
                }
            }

            // Couldn't find node
            if (pickedNode == -1) break;

            // Mark as visited
            unvisitedNodes[pickedNode] = false;

            // Check all neighbors of the nearest node
            for (int v = 0; v < nodeCount; v++)
            {
                // Check if there's an edge between pickedNode and v and v is still unvisited
                if (AdjacencyMatrix[pickedNode, v] < double.PositiveInfinity && unvisitedNodes[v])
                {
                    double alt = dist[pickedNode] + AdjacencyMatrix[pickedNode, v];

                    // If a shorter path to v is found
                    if (alt < dist[v])
                    {
                        // Update the distance
                        dist[v] = alt; 
                        // Update the previous node
                        prev[v] = pickedNode;   
                    }
                }
            }
        }
        return new Tuple<double[], int[]>(dist, prev); // Return the distance and previous node arrays
    }


}


