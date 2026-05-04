public static class FibonacciExercise
{
    public static void Run()
    {
        #region Configuration And Validation
        int sequenceLimit = 100;

        if (sequenceLimit <= 0)
        {
            Console.WriteLine("The sequence limit must be a positive integer.");
            return;
        }
        #endregion Configuration And Validation

        #region Generate And Display
        GenerateAndDisplayFibonacci(sequenceLimit);
        #endregion Generate And Display
    }

    /// <summary>
    /// Generates the Fibonacci sequence (starting 1, 1) for all values below the specified limit.
    /// </summary>
    /// <param name="maxLimit">Upper bound (exclusive) for sequence values.</param>
    static void GenerateAndDisplayFibonacci(int maxLimit)
    {
        if (maxLimit == 1)
        {
            Console.WriteLine($"Fibonacci sequence below {maxLimit}:");
            Console.WriteLine("No numbers in sequence are below 1");
            return;
        }

        var fibonacciNumbers = new List<int>();

        int first = 1;
        int second = 1;

        if (first < maxLimit) fibonacciNumbers.Add(first);
        if (second < maxLimit) fibonacciNumbers.Add(second);

        while (true)
        {
            int next = first + second;
            if (next >= maxLimit) break;

            fibonacciNumbers.Add(next);
            first = second;
            second = next;
        }

        Console.WriteLine($"Fibonacci sequence below {maxLimit}:");

        if (fibonacciNumbers.Count == 0)
        {
            Console.WriteLine("No Fibonacci numbers found below the limit.");
        }
        else
        {
            Console.WriteLine(string.Join(", ", fibonacciNumbers));
        }
    }
}