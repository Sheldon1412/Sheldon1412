public static class CalculateExercise
{
    public static void Run()
    {
        #region Data Configuration
        // Sample input format: "Id, Name, Number1, Number2, Operator"
        // The first value (7508237867980) appears to be an ID number and is not used in the calculation
        string sampleInput = "7508237867980, Wasim, 2, 9, +";
        #endregion Data Configuration

        #region Validation And Processing
        // Validate that the input string is not null, empty, or only whitespace
        // This prevents errors when attempting to split and parse the string
        if (string.IsNullOrWhiteSpace(sampleInput))
        {
            // Display a user-friendly error message if the input is invalid
            Console.WriteLine("The input string is empty. Please provide valid data.");
            return; // Exit early since we have no data to process
        }

        // Call the method that parses the CSV string and performs the calculation
        // Pass the validated input string as an argument
        ProcessCalculation(sampleInput);
        #endregion Validation And Processing
    }

    /// <summary>
    /// Parses a CSV string and performs a mathematical calculation.
    /// </summary>
    /// <param name="singleLine">CSV formatted string: "Id, Name, Number1, Number2, Operator"</param>
    public static void ProcessCalculation(string singleLine)
    {
        // Split the input string by comma delimiter into an array of parts
        // This separates the ID, name, numbers, and operator into individual elements
        string[] dataParts = singleLine.Split(',');

        // Validate that we have exactly 5 parts before accessing array indices
        // Accessing an index that doesn't exist would cause an IndexOutOfRangeException
        if (dataParts.Length < 5)
        {
            Console.WriteLine("Invalid data format. Expected format: Id, Name, Number1, Number2, Operator");
            return; // Exit early since the data format is incorrect
        }

        // Extract the person's name from the second element (index 1)
        // Trim removes any leading or trailing whitespace from the name
        string personName = dataParts[1].Trim();

        // Safely parse the first number using int.TryParse
        // TryParse returns false if the string is not a valid integer, preventing exceptions
        // The out parameter assigns the parsed value to firstDigit if successful
        if (!int.TryParse(dataParts[2].Trim(), out int firstDigit))
        {
            // Display which specific part failed to parse for easier debugging
            Console.WriteLine($"Invalid number format: '{dataParts[2].Trim()}' is not a valid integer.");
            return; // Exit early since we cannot calculate with invalid numbers
        }

        // Safely parse the second number using the same TryParse approach
        if (!int.TryParse(dataParts[3].Trim(), out int secondDigit))
        {
            Console.WriteLine($"Invalid number format: '{dataParts[3].Trim()}' is not a valid integer.");
            return; // Exit early since we cannot calculate with invalid numbers
        }

        // Extract the mathematical operator from the fifth element (index 4)
        // Trim ensures no extra spaces interfere with the switch comparison
        string mathOperator = dataParts[4].Trim();

        // Call the pure calculation method that contains only business logic
        // It returns a nullable double (double?) so we can detect invalid operations
        double? calculationResult = PerformCalculation(firstDigit, secondDigit, mathOperator);

        // Only display results if the calculation was successful (not null)
        // This prevents displaying partial or incorrect information
        if (calculationResult.HasValue)
        {
            // Display the person's name extracted from the CSV
            Console.WriteLine($"Name: {personName}");

            // Display the full calculation with the result
            // HasValue and Value are properties of nullable types to safely access the underlying value
            Console.WriteLine($"Calculation: {firstDigit} {mathOperator} {secondDigit} = {calculationResult.Value}");
        }
        // If calculationResult is null, the error message was already displayed by PerformCalculation
    }

    /// <summary>
    /// Performs a mathematical operation on two integers based on the specified operator.
    /// This method contains only calculation logic with no console input/output, making it testable.
    /// </summary>
    /// <param name="firstDigit">First operand in the calculation.</param>
    /// <param name="secondDigit">Second operand in the calculation.</param>
    /// <param name="mathOperator">The operation to perform: +, -, *, or /</param>
    /// <returns>The calculation result as a double, or null if the operator is invalid or division by zero occurs.</returns>
    static double? PerformCalculation(int firstDigit, int secondDigit, string mathOperator)
    {
        // Use a switch statement to determine which mathematical operation to perform
        // The switch evaluates the mathOperator string against each case
        switch (mathOperator)
        {
            case "+":
                // Addition: return the sum of both numbers
                return firstDigit + secondDigit;

            case "-":
                // Subtraction: return the difference between the numbers
                return firstDigit - secondDigit;

            case "*":
                // Multiplication: return the product of both numbers
                return firstDigit * secondDigit;

            case "/":
                // Division requires special handling to prevent divide-by-zero errors
                // Check if the second number is zero before attempting division
                if (secondDigit == 0)
                {
                    // Display an error and return null to indicate the calculation failed
                    Console.WriteLine("Error: Cannot divide by zero.");
                    return null; // Null indicates the operation could not be completed
                }
                // Cast firstDigit to double to ensure floating-point division
                // Without the cast, integer division would truncate decimal places (e.g., 5/2 = 2 instead of 2.5)
                return (double)firstDigit / secondDigit;

            default:
                // If the operator doesn't match any case (+, -, *, /), it's invalid
                // Display the invalid operator and list valid options for the user
                Console.WriteLine($"Invalid operator detected: '{mathOperator}'. Valid operators are: +, -, *, /");
                return null; // Null indicates the operation could not be completed
        }
        // The switch statement handles all possible paths, so no break is needed after returns
    }
}