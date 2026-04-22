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
        var n = graph.GetLength(0);
        var distances = new double[n, n];
        var next = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                distances[i, j] = graph[i,j];
                var isInfinite = double.IsPositiveInfinity(graph[i, j]);
                next[i, j] = isInfinite ? -1 : j;
            }

            distances[i, i] = 0;
            next[i, i] = -1;
        }
        
        return new Tuple<double[,], int[,]>(distances, next);
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
        var n = graph.GetLength(0);
        var (dist, next) = Init(graph);

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var newDistance = dist[i, k] + dist[k, j];
                    var oldDistance = dist[i, j];
                    if (newDistance < oldDistance)
                    {
                        dist[i, j] = newDistance;
                        next[i, j] = next[i, k];
                    }
                }
            }
        }
        
        return new Tuple<double[,], int[,]>(dist, next);
    }
}




























