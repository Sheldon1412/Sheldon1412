using System;
using System.Linq;

public static class MeanExercise
{
    /// <summary>
    /// Entry point for the Mean Calculation exercise.
    /// Handles data setup, validation, and output display.
    /// </summary>
    public static void Run()
    {
        #region Input Data
        // Initialize a sample integer array to calculate the average from
        int[] numberArray = { 10, 20, 30, 40, 50 };
        #endregion

        #region Validation & Calculation
        // Defensive check: Ensure the array exists and has elements to avoid division by zero
        if (numberArray == null || numberArray.Length == 0)
        {
            Console.WriteLine("The list of numbers cannot be empty. Please provide valid data.");
            return; // Terminate execution if data is invalid
        }

        // Call the logic method to compute the average
        double averageResult = CalculateMean(numberArray);
        #endregion

        #region Output
        // Display the result using string interpolation for clean formatting
        Console.WriteLine($"The average value of the entered numbers is: {averageResult}");
        #endregion
    }

    /// <summary>
    /// Calculates the arithmetic mean (average) of an integer array.
    /// </summary>
    /// <param name="numbersToProcess">The array of integers to be averaged.</param>
    /// <returns>The average as a double to preserve decimal precision.</returns>
    static double CalculateMean(int[] numbersToProcess)
    {
        // Use double for totalSum to prevent integer truncation during the division step
        double totalSum = 0;

        // Iterate through each element to accumulate the total sum
        foreach (int individualNumber in numbersToProcess)
        {
            totalSum += individualNumber;
        }

        // Divide the sum by the count of elements
        // Returning as double ensures that values like 2.5 aren't rounded down to 2
        return totalSum / numbersToProcess.Length;
    }
}