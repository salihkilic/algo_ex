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
        //ToDo 1.1 Initialize the distance and next matrix
        int edges = graph.GetLength(0);
        double[,] dist = new double[edges,edges];
        int[,] nextIndex = new int[edges,edges];

        for (int i = 0; i < edges; i++)
        {
            for (int j = 0; j < edges; j++)
            {
                dist[i,j] = graph[i,j];

                if (i == j)
                {
                    dist[i, j] = 0;
                    nextIndex[i,j] = -1;
                }
                else if (graph[i,j] == double.PositiveInfinity)
                {
                    nextIndex[i,j] = -1;
                }
                else
                {
                    nextIndex[i, j] = j;
                }

            }
        }
        return new Tuple<double[,], int[,]>(dist, nextIndex);

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
        //ToDo 1: Floyd-Warshall Algorithm, All Pairs Shortest Path
        //Includes 1.1
        var (dist, next) = Init(graph);
        int edges = graph.GetLength(0);

        for (int k = 0; k < edges; k++)
        {
            for (int i = 0; i < edges; i++)
            {
                for (int j = 0; j < edges; j++)
                {
                    if (dist[i,k] + dist[k,j] < dist[i,j])
                    {
                        dist[i, j] = dist[i, k] + dist[k,j];
                        next[i,j] = next[i,k];
                    }
                }
            }
        }
        return new Tuple<double[,], int[,]>(dist, next);
    }
}
