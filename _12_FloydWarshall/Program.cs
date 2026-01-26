using AlgorithmTestFramework;

namespace _12_FloydWarshall;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Floyd-Warshall Algorithm Exercise Runner --- \n");
        RunTests();
    }

    private static void RunTests()
    {
        Console.WriteLine("Testing Initialization...");
        TestRunner.RunTest("Init Matrix Setup", TestInit, 
            "Init should create the initial Distance and Next matrices correctly based on the input graph.");

        Console.WriteLine("\nTesting All-Pairs Shortest Path...");
        TestRunner.RunTest("Floyd-Warshall Execution", TestAllPairShortestPath, 
            "The algorithm should correctly compute the shortest paths between all pairs of nodes.");
    }

    private static void TestInit()
    {
        double inf = double.PositiveInfinity;
        
        // Input graph
        double[,] graph = {
            {inf,   3, inf,   5},
            { 2 , inf, inf, inf},
            {inf,   7, inf,   1},
            {inf, inf,   6, inf}
        };

        // Expected Distance Matrix (Init state)
        // Should indicate direct edge weights
        double[,] expectedDistances = {
            {  0,   3, inf,   5},
            {  2,   0, inf, inf},
            {inf,   7,   0,   1},
            {inf, inf,   6,   0}
        };

        // Expected Next Matrix (Init state)
        // If edge exists i->j, next is j. Else -1 (or some indicator).
        int[,] expectedNextNodes = {
            {-1,  1, -1,  3},
            { 0, -1, -1, -1},
            {-1,  1, -1,  3},
            {-1, -1,  2, -1}
        };

        var result = FloydWarshall.Init(graph);
        
        // Check Distances
        Assertions.Assert2DEqual(result.Item1, expectedDistances);
        
        // Check Next Nodes
        Assertions.Assert2DEqual(result.Item2, expectedNextNodes);
    }

    private static void TestAllPairShortestPath()
    {
        double inf = double.PositiveInfinity;
        double[,] graph = {
            {inf,   3, inf,   5},
            { 2 , inf, inf, inf},
            {inf,   7, inf,   1},
            {inf, inf,   6, inf}
        };  

        // Final Optimized Distances
        double[,] expectedDistances = {
            { 0,  3, 11, 5},
            { 2,  0, 13, 7},
            { 9,  7,  0, 1},
            {15, 13,  6, 0}
        };

        // Final Next Nodes for path reconstruction
        int[,] expectedNextNodes = {
            {-1,  1,  3,  3},
            { 0, -1,  0,  0},
            { 1,  1, -1,  3},
            { 2,  2,  2, -1}
        };

        var result = FloydWarshall.AllPairShortestPath(graph);

        // Check Distances
        Assertions.Assert2DEqual(result.Item1, expectedDistances);

        // Check Next Nodes
        Assertions.Assert2DEqual(result.Item2, expectedNextNodes);
    }
}
