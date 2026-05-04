using System;

public static class SumNExercise
{
    public static void Run()
    {
        #region Input And Validation
        Console.Write("Please enter a number (n): ");
        string userInput = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(userInput) || !int.TryParse(userInput, out int n))
        {
            Console.WriteLine("Invalid input. Please enter a valid whole number.");
            return;
        }

        if (n < 1)
        {
            Console.WriteLine("Please enter a number greater than or equal to 1.");
            return;
        }

        if (n > 65535)
        {
            Console.WriteLine("Please enter a number less than or equal to 65,535.");
            return;
        }
        #endregion Input And Validation

        #region Calculation And Output
        long finalSum = CalculateSumToN(n);
        Console.WriteLine($"The sum of numbers from 1 to {n} is: {finalSum}");
        #endregion Calculation And Output
    }

    /// <summary>
    /// Calculates the sum of integers from 1 to n using the Gauss formula.
    /// </summary>
    /// <param name="userNumber">The upper bound of the range.</param>
    /// <returns>The sum of integers from 1 to n.</returns>
    static long CalculateSumToN(int userNumber)
    {
        // Cast to long before multiplication to prevent integer overflow
        long n = userNumber;
        return n * (n + 1) / 2;
    }
}