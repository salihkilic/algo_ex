using System;

namespace AlgorithmTestFramework;

public static class Assertions
{
    public static void AssertEqual<T>(T actual, T expected)
    {
        if (!object.Equals(actual, expected))
            throw new TestFailedException($"Expected {expected} but got {actual}");
    }

    public static void AssertSorted<T>(T[]? actual, T[] expected) where T : IComparable<T>
    {
        if (actual == null) throw new TestFailedException("Actual array is null.");

        if (actual.Length != expected.Length)
            throw new TestFailedException($"Array length mismatch. Expected {expected.Length}, got {actual.Length}.");

        for (int i = 0; i < actual.Length; i++)
        {
            if (actual[i].CompareTo(expected[i]) != 0)
            {
                throw new TestFailedException($"Mismatch at index {i}. Expected {expected[i]}, got {actual[i]}.");
            }
        }
    }

    public static void AssertJaggedEqual<T>(T[][]? actual, T[][] expected) where T : IComparable<T>
    {
        if (actual == null) throw new TestFailedException("Actual jagged array is null.");

        if (actual.Length != expected.Length)
            throw new TestFailedException($"Jagged Array Row count mismatch. Expected {expected.Length}, got {actual.Length}.");

        for (int i = 0; i < actual.Length; i++)
        {
            try
            {
                AssertSorted(actual[i], expected[i]);
            }
            catch (TestFailedException ex)
            {
                 throw new TestFailedException($"Mismatch in row {i}: {ex.Message}");
            }
        }
    }

    public static void Assert2DEqual<T>(T[,]? actual, T[,] expected) where T : IComparable<T>
    {
        if (actual == null) throw new TestFailedException("Actual 2D array is null.");

        if (actual.GetLength(0) != expected.GetLength(0) || actual.GetLength(1) != expected.GetLength(1))
            throw new TestFailedException($"2D Array Dimensions mismatch. Expected [{expected.GetLength(0)},{expected.GetLength(1)}] but got [{actual.GetLength(0)},{actual.GetLength(1)}]");

        for (int x = 0; x < actual.GetLength(0); x++)
        {
            for (int y = 0; y < actual.GetLength(1); y++)
            {
                if (actual[x, y].CompareTo(expected[x, y]) != 0)
                    throw new TestFailedException($"Mismatch at [{x},{y}]. Expected {expected[x, y]}, got {actual[x, y]}.");
            }
        }
    }
}
