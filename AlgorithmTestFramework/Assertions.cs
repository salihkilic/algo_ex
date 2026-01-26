using System;

namespace AlgorithmTestFramework;

public static class Assertions
{
    public static void AssertEqual<T>(T actual, T expected)
    {
        if (!object.Equals(actual, expected))
            throw new TestFailedException($"Expected {expected} but got {actual}");
    }

    public static void AssertSorted<T>(T[] actual, T[] expected) where T : IComparable<T>
    {
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
}
