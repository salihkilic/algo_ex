using AlgorithmTestFramework;

namespace _10_Graph;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Graph Algorithms Exercise Runner --- \n");
        RunTests();
    }

    private static void RunTests()
    {
        Console.WriteLine("Testing Traversals...");
        TestRunner.RunTest("Breadth First Traversal (BFT)", TestBft, 
            "BFT should visit nodes level by level (Queue-based).");

        TestRunner.RunTest("Depth First Traversal (DFT)", TestDft, 
            "DFT should visit nodes branch by branch (Stack-based).");

        Console.WriteLine("\nTesting Shortest Path...");
        TestRunner.RunTest("Dijkstra (Simple)", TestDijkstraSimple, 
            "Dijkstra should find shortest paths from source to all other nodes.");
        
        TestRunner.RunTest("Dijkstra (Complex)", TestDijkstraComplex, 
            "Dijkstra should handle loops and multiple paths correctly.");
    }

    /// <summary>
    /// Tests Breadth First Traversal.
    /// Graph Structure:
    /// 0 -> 1, 2
    /// 1 -> 3
    /// 2 -> 0
    /// 3 -> 2
    /// Expected BFT from 0: 0, 1, 2, 3
    /// </summary>
    private static void TestBft()
    {
        var inf = double.PositiveInfinity;
        var matrix = new double[,]
        {
            { inf,  3 ,  3 , inf },
            { inf, inf, inf,  2  },
            {  4 , inf, inf, inf },
            { inf, inf,   5, inf },
        };
        var g = new Graph(matrix);

        string result = g.Bft(0).Trim();
        string expected = "0 1 2 3";

        Assertions.AssertEqual(result, expected, "BFT Order Mismatch.");
    }

    /// <summary>
    /// Tests Depth First Traversal.
    /// Graph Structure same as above.
    /// Neighbors of 0 are 1, 2. Pushed in reverse (2, then 1) so 1 is popped first.
    /// 0 -> 1 -> 3 -> 2
    /// Expected DFT from 0: 0, 1, 3, 2
    /// </summary>
    private static void TestDft()
    {
        var inf = double.PositiveInfinity;
        var matrix = new double[,]
        {
            { inf,  3 ,  3 , inf },
            { inf, inf, inf,  2  },
            {  4 , inf, inf, inf },
            { inf, inf,   5, inf },
        };
        var g = new Graph(matrix);

        string result = g.DFT(0).Trim();
        string expected = "0 1 3 2";
        
        // Note: The exact order depends on neighbor order pushing. 
        // Based on implementation: Neighbors are found 0..N. 
        // Then Reversed. Then Pushed. 
        // 0's neighbors: 1, 2. Reversed: 2, 1. Stack: [2, 1]. Pop 1.
        // 1's neighbors: 3. Reversed: 3. Stack [2, 3]. Pop 3.
        // 3's neighbors: 2. Reversed: 2. Stack [2, 2]. Pop 2.
        // 2's neighbors: 0. Ignored.
        // Pop 2 (already visited).
        
        Assertions.AssertEqual(result, expected, "DFT Order Mismatch.");
    }

    /// <summary>
    /// Tests Dijkstra on a simple graph.
    /// 0 -> 1 (2), 2 (5)
    /// 1 -> 2 (1), 3 (3)
    /// 2 -> 0 (4), 3 (1)
    /// 3 -> 2 (5)
    /// Shortest Paths from 0:
    /// To 0: 0
    /// To 1: 0->1 (2)
    /// To 2: 0->1->2 (2+1 = 3) [Direct is 5, via 1 is 3]
    /// To 3: 0->1->2->3 (3+1 = 4) OR 0->1->3 (2+3 = 5). Correct is 4 via node 2.
    /// Distances: [0, 2, 3, 4]
    /// Predecessors: [-1, 0, 1, 2]
    /// </summary>
    private static void TestDijkstraSimple()
    {
        var inf = double.PositiveInfinity;
        var matrix = new double[,]
        {
            { inf ,  2  ,  5  ,  inf },
            { inf , inf ,  1  ,   3  },
            {  4  , inf , inf ,   1  },
            { inf , inf ,  5  ,  inf },
        };
        
        var g = new Graph(matrix);
        var result = g.SingleSourceShortestPath(0);
        double[] dist = result.Item1;
        int[] prev = result.Item2;

        double[] expectedDist = { 0, 2, 3, 4 };
        int[] expectedPrev = { -1, 0, 1, 2 };

        Assertions.AssertEqual(dist.Length, expectedDist.Length, "Distance array length mismatch.");
        for(int i=0; i<dist.Length; i++)
        {
            Assertions.AssertEqual(dist[i], expectedDist[i], $"Distance source->{i} mismatch.");
        }
        
        for(int i=0; i<prev.Length; i++)
        {
             Assertions.AssertEqual(prev[i], expectedPrev[i], $"Predecessor for {i} mismatch.");
        }
    }

    private static void TestDijkstraComplex()
    {
         // Create a slightly larger graph
         // 0 --(1)-> 1 --(1)-> 2
         // |         |
         // (4)       (2) 
         // |         |
         // v         v
         // 3 --(1)-> 4
         
         // 0->1 (1)
         // 0->3 (4)
         // 1->2 (1)
         // 1->4 (2)
         // 3->4 (1)
         
         // Path to 4: 
         // 0->1->4 (dist 3)
         // 0->3->4 (dist 5)
         // Shortest is 3. Prev of 4 is 1.

         var inf = double.PositiveInfinity;
         var matrix = new double[,] {
             // 0    1    2    3    4
             { inf,  1 , inf,  4 , inf }, // 0
             { inf, inf,  1 , inf,  2  }, // 1
             { inf, inf, inf, inf, inf }, // 2
             { inf, inf, inf, inf,  1  }, // 3
             { inf, inf, inf, inf, inf }, // 4
         };

         var g = new Graph(matrix);
         var result = g.SingleSourceShortestPath(0);
         double[] dist = result.Item1;
         
         // Target 4
         Assertions.AssertEqual(dist[4], 3, "Shortest path to 4 should be 3.");
    }
}
