using System;

public static class SecondLargestExercise
{
    public static void Run()
    {
        #region Configuration And Validation
        // Declare and initialize an integer array with sample data
        // Using camelCase for the variable name as per naming standards
        int[] numberSet = { 12, 35, 1, 10, 34, 1 };

        // Validate that the array is not null and contains at least 2 elements
        // We need at least 2 elements to have a second largest number
        if (numberSet == null || numberSet.Length < 2)
        {
            // Display a user-friendly error message if validation fails
            Console.WriteLine("Invalid input. Please provide an array with at least two numbers.");
            return; // Exit early since we cannot find second largest with fewer than 2 elements
        }
        #endregion Configuration And Validation

        #region Process And Display
        // Call the method that finds and displays the second largest number
        // Pass the validated array as an argument
        FindAndDisplaySecondLargest(numberSet);
        #endregion Process And Display
    }

    /// <summary>
    /// Finds and displays the second largest integer in the provided array.
    /// </summary>
    /// <param name="inputArray">Array of integers to search through.</param>
    static void FindAndDisplaySecondLargest(int[] inputArray)
    {
        // Initialize largest to the smallest possible integer value
        // This ensures any number in the array will be larger than the initial value
        int largest = int.MinValue;

        // Initialize secondLargest to the smallest possible integer value
        // This will be updated as we find numbers smaller than largest but larger than current secondLargest
        int secondLargest = int.MinValue;

        // Loop through each number in the array one by one
        foreach (int currentNumber in inputArray)
        {
            // Check if the current number is greater than our current largest
            if (currentNumber > largest)
            {
                // If we found a new largest, the old largest becomes the second largest
                secondLargest = largest;
                // Update largest to the new maximum value found
                largest = currentNumber;
            }
            // If current number is not larger than largest, check if it's a candidate for second largest
            // We also check that it's not equal to largest (to handle duplicate maximum values)
            else if (currentNumber > secondLargest && currentNumber != largest)
            {
                // Update secondLargest to this new value
                secondLargest = currentNumber;
            }
            // If neither condition is met, the number is smaller than secondLargest, so we ignore it
        }

        // After checking all numbers, verify we actually found a valid second largest
        // If secondLargest is still int.MinValue, no second largest was found
        // This happens when all numbers are the same (e.g., {5, 5, 5})
        if (secondLargest == int.MinValue)
        {
            // Inform the user that no second largest element exists
            Console.WriteLine("No second largest element found (all numbers might be the same or array had fewer than 2 unique values).");
        }
        else
        {
            // Display the successfully found second largest number
            Console.WriteLine($"The second largest element is: {secondLargest}");
        }
    }
}