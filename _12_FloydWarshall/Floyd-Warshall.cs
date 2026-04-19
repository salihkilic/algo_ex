using System;

namespace _12_FloydWarshall;

public class FloydWarshall
{
    /// <summary>
    /// Initializes the distance and next node matrices for the Floyd-Warshall algorithm.
    /// </summary>
    /// <param name="graph">The input adjacency matrix where graph[i,j] represents the weight of the edge from i to j. 
    /// Infinity indicates no edge.</param>
    /// <returns>
    /// A Tuple containing:
    /// Item1 (double[,]): The initial distance matrix. Should be a copy of the graph, but with 0 on the diagonal.
    /// Item2 (int[,]): The initial 'next' node matrix for path reconstruction.
    ///                 If there is an edge from i to j, next[i,j] = j.
    ///                 If there is no edge (infinity), next[i,j] = -1.
    ///                 next[i,i] should probably be -1 or i depending on convention, usually -1 for path reconstruction stop.
    /// </returns>
    public static Tuple<double[,], int[,]> Init(double[,] graph)
    {
        // Step 1: Init
        // int n -> lengte van 1 zijde van graph
        // double[n,n] dist -> afstand matrix
        // int[n,n] next -> voor next[i,j] krijg je de volgende node die je moet bezoeken om van i naar j te gaan. 
        
        // Step 2: Vul de twee matrixes
        // - Dubbele for loop (i & j). 
        // - dist kopieert graph
        // - next zet -1 als graph op zelfde index infinity is, anders j (de vooralsnog next node omdat ze adjacent zijn, meer info hebben we nog niet berekend)
        // - *Na* de inner for loop zetten we de diagonalen van de matrix: dist[i,i] = 0, next[i,i] = -1
        
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Executes the Floyd-Warshall algorithm to find the All-Pairs Shortest Paths.
    /// </summary>
    /// <param name="graph">The adjacency matrix of the graph.</param>
    /// <returns>
    /// A Tuple containing:
    /// Item1 (double[,]): The matrix of shortest distances between every pair of nodes.
    /// Item2 (int[,]): The matrix of 'next' nodes to reconstruction the shortest paths.
    /// </returns>
    public static Tuple<double[,], int[,]> AllPairShortestPath(double[,] graph)
    {
        // Step 1: init
        // int n -> lengte van zijde van graph
        // dist -> distance matrix
        // next -> next matrix
        
        // Step 2: de conjo loop
        // for k, i, j
        // bereken de nieuwe afstand van i,k + k,j (i naar j, via k)
        // vergelijk met de bestaande afstand (i,j)
        // Als nieuwe afstand beter is, pas de beide matrixes aan.
        
        throw new NotImplementedException();
    }
}
