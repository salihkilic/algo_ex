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
        // TIPS:
        // - BFT: Volgende node komt van queue, met buurmannen in normale volgorde
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
        // TIPS:
        // - BFT: Volgende node komt van stack, met buurmannen in omgekeerde volgorde
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
        // - distanceToSource: double[] met alle afstanden tot start voor elke index
        // - previousNodes: int[] met elk een voorgaande nodes met de kortste route tot dan, voor die index
        // - unvisitedNodes: HashSet<int> met alle onbezochte nodes (nodes waarvan we nog niet alle uitgaande paden berekend hebben)
        // Met een for loop zetten we alle distances op infinity, previousnodes op -1 en voegen we alle nodes aan unvisited toe.
        // Zet de distance to source voor de source node op 0.
        
        // Step 2: De while loop
        // - Zo lang we nog unvisited nodes hebben pakken we degene die het meest dichtbij source is (voor nu)
        // - Als we er geen vinden, zijn we klaar
        // - Markeer deze nieuwe node als "bezocht"
        
        // Stap 3: Bezoeken (binnen de while nog)
        // - Pak alle neighbours van de huidige node
        // - Loop over de neighbours en kijk of we al bezocht hebben (dan hoeven we er niks mee)
        // - Als de neighbour via jou sneller bereikbaar is dan de distance (en predecessor) die er al was (potentieel infinity), dan updaten we distance en predecessor met ONZE shit (de huidige node)
        //      - distanceArr[neighbour] = onze distance + distance tussen ons en neighbour
        //      - previousNode[neighbour] = onze index
        
        
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
