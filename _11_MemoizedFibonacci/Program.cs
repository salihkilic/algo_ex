using AlgorithmTestFramework;

namespace _11_MemoizedFibonacci;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Memoized Fibonacci Exercise Runner --- \n");
        RunTests();
    }

    private static void RunTests()
    {
        TestRunner.RunTest("Base Cases (0 and 1)", TestBaseCases, 
            "Fib(0) should be 0, Fib(1) should be 1.");

        TestRunner.RunTest("Small Values Correctness", TestSmallValues, 
            "Fib(5) -> 5, Fib(10) -> 55. Standard sequence checks.");

        TestRunner.RunTest("Memoization Efficiency", TestEfficiency, 
            "Calculating Fib(40) should not take millions of recursive calls if memoization is working.");
        
        TestRunner.RunTest("Intermediate Results Storage", TestStorageUsage, 
            "The storedResults array should be populated with intermediate values.");
    }

    private static void TestBaseCases()
    {
        Utils.SetToZero();
        long[] memo = new long[10]; 
        // Note: Code typically expects memo[0]=0, memo[1]=1 if pre-filled, 
        // but robust code handles empty array too (or we pre-fill).
        // The original Program.cs pre-filled 0 and 1. We should probably respect that if the logic requires it.
        // Looking at DynamicProgramming.cs: "if (n <= 1) return 1;" (Wait, Fib(0) is 0 usually. Let's check impl).
        // Impl: if (n == 0) return 0; if (n <= 1) return 1;
        
        memo[0] = 0; memo[1] = 1;

        long f0 = DynamicProgramming.FibonacciDynamic(0, memo);
        Assertions.AssertEqual(f0, 0, "Fib(0) should be 0");
        
        long f1 = DynamicProgramming.FibonacciDynamic(1, memo);
        Assertions.AssertEqual(f1, 1, "Fib(1) should be 1");
    }

    private static void TestSmallValues()
    {
        Utils.SetToZero();
        int n = 10;
        long[] memo = new long[n + 1];
        memo[0] = 0; memo[1] = 1;

        long res = DynamicProgramming.FibonacciDynamic(n, memo);
        Assertions.AssertEqual(res, 55, "Fib(10) should be 55");
        
        // Fib(5)
        Utils.SetToZero();
        long[] memo5 = new long[6];
        memo5[0] = 0; memo5[1] = 1;
        long f5 = DynamicProgramming.FibonacciDynamic(5, memo5);
        Assertions.AssertEqual(f5, 5, "Fib(5) should be 5");
    }

    private static void TestEfficiency()
    {
        Utils.SetToZero();
        int n = 40;
        // Fib(40) is 102,334,155. A naive int might overflow, but we use long.
        
        long[] memo = new long[n + 1];
        memo[0] = 0; memo[1] = 1;

        long result = DynamicProgramming.FibonacciDynamic(n, memo);
        
        int calls = Utils.counter;
        Console.WriteLine($"      Fib(40) = {result}");
        Console.WriteLine($"      Recursive Calls: {calls}");

        long expected = 102334155;
        Assertions.AssertEqual(result, expected, "Fib(40) calculation is incorrect.");

        // Naive Fib(40) is > 100,000,000 calls.
        // Memoized should be linear, roughly 2*N or 3*N. 2*40 = 80.
        // Let's allow a generous padding for implementation details, say 200.
        if (calls > 1000) 
        {
            throw new Exception($"Too many recursive calls ({calls}). Memoization likely not working.");
        }
    }

    private static void TestStorageUsage()
    {
        int n = 6;
        long[] memo = new long[n + 1];
        memo[0] = 0; memo[1] = 1;
        
        DynamicProgramming.FibonacciDynamic(n, memo);
        
        // Array should be filled
        // Fib: 0, 1, 1, 2, 3, 5, 8
        Assertions.AssertEqual(memo[2], 1, "memo[2] should be stored");
        Assertions.AssertEqual(memo[3], 2, "memo[3] should be stored");
        Assertions.AssertEqual(memo[4], 3, "memo[4] should be stored");
        Assertions.AssertEqual(memo[5], 5, "memo[5] should be stored");
        Assertions.AssertEqual(memo[6], 8, "memo[6] should be stored");
    }
}
