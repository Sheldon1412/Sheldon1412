using System;

public static class SumDigitsExercise
{
    public static void Run()
    {
        #region Configuration
        // Initialize the input number whose digits we want to sum
        // This is a positive integer; negative numbers will be handled by taking absolute value
        int inputNumber = 457;
        #endregion Configuration

        #region Processing And Display
        // Take the absolute value to ensure we work with a non-negative number
        // The sum of digits is conventionally calculated on the absolute value
        int numberToProcess = Math.Abs(inputNumber);

        // Call the method that calculates the digit sum and store the result
        int totalSum = CalculateDigitSum(numberToProcess);

        // Display the original input number and the calculated sum of its digits
        Console.WriteLine($"The sum of the digits for {inputNumber} is: {totalSum}");
        #endregion Processing And Display
    }

    /// <summary>
    /// Calculates the sum of each individual digit in a non-negative integer.
    /// </summary>
    /// <param name="targetValue">The integer whose digits will be summed. Must be non-negative.</param>
    /// <returns>The sum of all digits in the number. Returns 0 if targetValue is 0.</returns>
    static int CalculateDigitSum(int targetValue)
    {
        // Initialize a variable to accumulate the sum of digits
        int runningSum = 0;

        // Create a working copy of the input so we don't modify the original parameter
        // This preserves the original value if needed by the caller
        int workingNumber = targetValue;

        // Loop until all digits have been processed (workingNumber becomes 0)
        while (workingNumber > 0)
        {
            // Use modulo 10 to extract the last digit of the number
            // Example: 457 % 10 = 7, so we add 7 to the sum
            runningSum += workingNumber % 10;

            // Use integer division by 10 to remove the last digit
            // Example: 457 / 10 = 45 (integer division discards the remainder)
            // The next iteration will process 45, then 4, then 0 (loop ends)
            workingNumber /= 10;
        }

        // Return the accumulated sum of all digits
        // If targetValue was 0, the loop never executes and we return 0, which is correct
        return runningSum;
    }
}