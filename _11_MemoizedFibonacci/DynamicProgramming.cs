﻿namespace _11_MemoizedFibonacci;

public static class DynamicProgramming {

    /// <summary>
    /// Calculates the nth Fibonacci number using Top-Down Dynamic Programming (Memoization).
    /// </summary>
    /// <param name="n">The index of the Fibonacci number to calculate (0-based).</param>
    /// <param name="storedResults">
    /// An array acting as a cache (memo table) to store previously calculated Fibonacci numbers.
    /// storedResults[i] should store Fib(i).
    /// Assume the array is initialized with 0s (except potentially storedResults[1]=1 if pre-filled, though implementation logic handles base cases).
    /// </param>
    /// <returns>The nth Fibonacci number.</returns>
    public static long FibonacciDynamic(long n, long[] storedResults)
    {    
        Utils.ShowCallStack(false); //DO NOT comment this line of code
    
        //ToDo: remove the above exception and provide recursive implementation of fibonacciDynamic 
        if (n == 0) return 0; 
        if (n <= 1 ) return 1;
        if (storedResults[n] == 0)
        {
            storedResults[n] = FibonacciDynamic(n - 1, storedResults) + FibonacciDynamic(n - 2, storedResults);
        }
        return storedResults[n];
    }
}
