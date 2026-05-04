using System;

public static class ReverseArrayExercise
{
    public static void Run()
    {
        #region Configuration And Validation
        // Declare and initialize an integer array with sample data
        // Using camelCase for the variable name as per naming standards
        int[] inputNumbers = { 1, 5, 3, 8, 4 };

        // Validate that the array is not null and contains at least one element
        // This prevents errors when attempting to reverse an empty array
        if (inputNumbers == null || inputNumbers.Length == 0)
        {
            // Display a user-friendly error message if validation fails
            Console.WriteLine("The array is empty. Please provide valid numbers to reverse.");
            return; // Exit the method early since we cannot process an empty array
        }
        #endregion Configuration And Validation

        #region Process And Display
        // Call the method that handles reversing and displaying the array
        // Pass the validated array as an argument
        ReverseAndDisplayArray(inputNumbers);
        #endregion Process And Display
    }

    /// <summary>
    /// Reverses the elements of an array in-place and displays both original and reversed arrays.
    /// </summary>
    /// <param name="numbersToReverse">Array of integers to reverse. Passed by reference so modifications affect the original.</param>
    static void ReverseAndDisplayArray(int[] numbersToReverse)
    {
        // Display the original array contents before any modifications
        // string.Join combines all array elements into a single string separated by commas
        Console.WriteLine("Original Array: " + string.Join(", ", numbersToReverse));

        // Use the built-in Array.Reverse method to reverse the array in-place
        // "In-place" means the reversal happens within the same memory location without creating a copy
        // This is more efficient than manually swapping elements in a loop
        Array.Reverse(numbersToReverse);

        // Display the array after it has been reversed
        // The original array variable now contains the reversed elements
        Console.WriteLine("Reversed Array: " + string.Join(", ", numbersToReverse));
    }
}