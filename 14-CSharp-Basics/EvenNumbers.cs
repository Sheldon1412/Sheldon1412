using System;
using System.Collections.Generic;

public static class EvenNumbersExercise
{
    /// <summary>
    /// Entry point for the Even Numbers exercise.
    /// Defines a range, validates it, and coordinates the processing and display.
    /// </summary>
    public static void Run()
    {
        #region Configuration
        // Define the bounds for the number search
        int startRange = 1;
        int endRange = 45;
        #endregion Configuration

        #region Validation
        // Defensive check: Ensure the logical direction of the range is valid
        if (startRange > endRange)
        {
            Console.WriteLine("Error: The start of the range cannot be higher than the end.");
            return; // Early exit if the range is logically impossible
        }
        #endregion Validation

        #region Process And Display
        // Logic: Extract even numbers into a collection
        int[] evenNumbers = GetEvenNumbersInRange(startRange, endRange);

        // UI: Print the results to the user
        DisplayEvenNumbers(startRange, endRange, evenNumbers);
        #endregion Process And Display
    }

    /// <summary>
    /// Identifies all even integers within a given range.
    /// </summary>
    /// <param name="start">The starting value of the range.</param>
    /// <param name="end">The ending value of the range.</param>
    /// <returns>An array of even integers.</returns>
    static int[] GetEvenNumbersInRange(int start, int end)
    {
        // Ternary operator: If start is even (divisible by 2), use it. 
        // Otherwise, the first even number must be the next one (start + 1).
        int firstEven = start % 2 == 0 ? start : start + 1;

        // Use a List because we don't know exactly how many even numbers exist yet.
        // Lists are dynamic and can grow as we find more numbers.
        var result = new List<int>();

        // Optimized Loop: Start at the first even and increment by 2.
        // This is more efficient than checking every single number in the range.
        for (int number = firstEven; number <= end; number += 2)
        {
            result.Add(number);
        }

        // Convert the dynamic list back to a fixed-size array to match return type
        return result.ToArray();
    }

    /// <summary>
    /// Handles the visual output of the even numbers found.
    /// </summary>
    /// <param name="startRange">Original start of the query.</param>
    /// <param name="endRange">Original end of the query.</param>
    /// <param name="evenNumbers">The resulting collection of numbers.</param>
    static void DisplayEvenNumbers(int startRange, int endRange, int[] evenNumbers)
    {
        Console.WriteLine($"Displaying even numbers between {startRange} and {endRange}:");

        // Handle the case where the range was too small to contain an even number
        if (evenNumbers.Length == 0)
        {
            Console.WriteLine("No even numbers found in the specified range.");
        }
        else
        {
            // Iterate through the array and print each value on a new line
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}