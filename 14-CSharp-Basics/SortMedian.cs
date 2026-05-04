using System;
using System.Security.Cryptography;

public static class SortMedianExercise
{
    /// <summary>
    /// Entry point for the Sort and Median exercise.
    /// Defines the dataset and initiates the sorting and calculation process.
    /// </summary>
    public static void Run()
    {
        #region Input Data
        // A sample dataset of unsorted integers
        int[] numberArray = { 45, 12, 89, 3, 27, 56, 11, 74, 10, 33 };
        #endregion Input Data

        #region Validation And Processing
        // Defensive check: Ensure the array is not null and contains data to avoid runtime errors
        if (numberArray == null || numberArray.Length == 0)
        // this is used for a defensive check to ensure we have data to process. If the array is null or empty, we cannot sort or find a median.
        // I added this comment because I wasnt sure why ai needed a check when the numbers were hard coded, still a little confused on this one, but I understand the concept of defensive programming and validating inputs before processing.
        // I understand the concept of defensive programming and validating inputs before processing, but I dont understand why we need to check for null or empty when the data is hard coded, maybe some one can explain this to me in more detail.
        //from my understanding this is technically dead code, but I read that this is good practice.
        {
            Console.WriteLine("The number set is empty. Please provide valid integer data.");
            return; // Early exit if there is no data to process
        }

        // Delegate the sorting and calculation to the specialized method
        SortAndDisplayMedian(numberArray);
        #endregion Validation And Processing
    }

    /// <summary>
    /// Sorts the provided array and manages the display of the median result.
    /// </summary>
    /// <param name="numbersToProcess">Array of integers to sort and analyze.</param>
    static void SortAndDisplayMedian(int[] numbersToProcess)
    {
        // Arrays must be sorted before a median can be found.
        // Array.Sort() modifies the original array in-place.
        Array.Sort(numbersToProcess);

        // Display the sorted list to the user for visual verification
        Console.WriteLine("Sorted Array: " + string.Join(", ", numbersToProcess));

        // Calculate the median using the specialized logic method
        double median = CalculateMedian(numbersToProcess);
        Console.WriteLine($"The calculated median is: {median}");
    }

    /// <summary>
    /// Implements the mathematical logic to find the median of a sorted array.
    /// </summary>
    /// <param name="sortedArray">The array must already be sorted in ascending order.</param>
    /// <returns>The median value as a double.</returns>
    static double CalculateMedian(int[] sortedArray)
    {
        int length = sortedArray.Length;

        // Check if the array length is even
        if (length % 2 == 0)
        {
            /*
               If the count is even, the median is the average of the two middle numbers.
               Example for 10 items: elements at index 4 and index 5.
               We divide by 2.0 to ensure the result remains a double (includes decimals).
            */
            return (sortedArray[length / 2 - 1] + sortedArray[length / 2]) / 2.0;
        }
        else
        {
            /*
               If the count is odd, the median is simply the middle element.
               Example for 5 items: index 2.
               Integer division (5/2) automatically gives us 2.
            */
            return sortedArray[length / 2];
        }
    }
}