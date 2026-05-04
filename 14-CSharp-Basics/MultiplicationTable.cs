using System;

public static class MultiplicationTableExercise
{
    /// <summary>
    /// Entry point for the Multiplication Table exercise.
    /// Manages user input, validates it, and triggers the table generation.
    /// </summary>
    public static void Run()
    {
        #region Input And Validation
        // Prompt the user for the base number they wish to multiply
        Console.Write("Enter a number to see its multiplication table: ");

        // Read input; '!' tells the compiler we've handled potential null values
        string userInput = Console.ReadLine()!;

        // Validate: Check if the string is empty or if it's not a valid integer
        if (string.IsNullOrWhiteSpace(userInput) || !int.TryParse(userInput, out int baseNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return; // Early exit if input is non-numeric
        }
        #endregion Input And Validation

        #region Display
        // Execute the display logic with the validated integer
        DisplayMultiplicationTable(baseNumber);
        #endregion Display
    }

    /// <summary>
    /// Displays a formatted multiplication table from 1 to 12 for a given base number.
    /// </summary>
    /// <param name="baseNumber">The integer used as the base for multiplication.</param>
    static void DisplayMultiplicationTable(int baseNumber)
    {
        // Define constants for the table scale and UI styling for easier maintenance
        const int TableSize = 12;
        const string Separator = "------------------------------";

        Console.WriteLine($"\nMultiplication Table for {baseNumber}:");
        Console.WriteLine(Separator);

        // Standard for-loop to iterate through the multipliers
        for (int multiplier = 1; multiplier <= TableSize; multiplier++)
        {
            // Calculate the product of the base number and the current multiplier
            int product = baseNumber * multiplier;

            /*
               ADVANCED FORMATTING EXPLAINED:
               The numbers after the commas (e.g., {baseNumber,3}) represent padding/alignment.
               - ,3 means: Right-align in a space 3 characters wide.
               - ,2 means: Right-align in a space 2 characters wide.
               - ,5 means: Right-align in a space 5 characters wide.
               This ensures the '=' signs and numbers line up perfectly in columns.
            */
            Console.WriteLine($"{baseNumber,3} × {multiplier,2} = {product,5}");
        }

        Console.WriteLine(Separator);
    }
}