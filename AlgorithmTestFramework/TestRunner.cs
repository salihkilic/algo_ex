using System;

namespace AlgorithmTestFramework;

public static class TestRunner
{
    public static void RunTest(string testName, Action testAction, string hint = "")
    {
        Console.Write($"[TEST] {testName}: ");
        try
        {
            testAction();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASSED");
        }
        catch (NotImplementedException)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("IGNORED (Not Implemented)");
        }
        catch (TestFailedException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"FAILED");
            Console.WriteLine($"  Error: {ex.Message}");
            if (!string.IsNullOrEmpty(hint))
            {
                Console.WriteLine($"  Hint:  {hint}");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR (Exception)");
            Console.WriteLine($"  {ex.GetType().Name}: {ex.Message}");
            if (!string.IsNullOrEmpty(hint))
            {
                Console.WriteLine($"  Hint:  {hint}");
            }
        }
        finally
        {
            Console.ResetColor();
        }
    }
}
