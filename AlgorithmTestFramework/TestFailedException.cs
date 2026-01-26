namespace AlgorithmTestFramework;

public class TestFailedException : Exception
{
    public TestFailedException(string message) : base(message) { }
}
