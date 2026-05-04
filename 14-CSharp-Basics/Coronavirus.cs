using System;

public static class CoronavirusExercise
{
    public static void Run()
    {
        #region Data Generation And Validation
        // Create a new instance of the Random class to generate random numbers
        // Random uses the system clock as a seed by default
        Random randomGenerator = new Random();

        // Generate a random number between 1 and 700 for positive cases
        // The upper bound (701) is exclusive, so it generates 1 to 700
        int positiveCases = randomGenerator.Next(1, 701);

        // Generate a random number between 1 and 15 for total deaths
        // The upper bound (16) is exclusive, so it generates 1 to 15
        int totalDeaths = randomGenerator.Next(1, 16);

        // Validate that generated values are not negative
        // This is a defensive check since Random.Next(1, x) should never return negative values
        // But validation standards require checking inputs before processing
        if (positiveCases < 0 || totalDeaths < 0)
        {
            // Display a user-friendly error message if negative values are somehow detected
            Console.WriteLine("Data error: Negative values detected. Please contact your administrator.");
            return; // Exit early since we cannot process invalid data
        }
        #endregion Data Generation And Validation

        #region Decision And Display
        // Call the method that determines the lockdown decision and displays results
        // Pass the generated and validated data as arguments
        DetermineAndDisplayDecision(positiveCases, totalDeaths);
        #endregion Decision And Display
    }

    /// <summary>
    /// Determines the lockdown status based on positive cases and deaths, then displays the results.
    /// </summary>
    /// <param name="positiveCases">Number of positive COVID-19 cases.</param>
    /// <param name="totalDeaths">Number of total deaths.</param>
    static void DetermineAndDisplayDecision(int positiveCases, int totalDeaths)
    {
        // Call the pure logic method to get the decision string
        // Separating logic from display makes the code more testable and maintainable
        string currentDecision = GetLockdownDecision(positiveCases, totalDeaths);

        // Display the positive cases count to the user
        Console.WriteLine($"Positive cases = {positiveCases}");

        // Display the total deaths count to the user
        Console.WriteLine($"Total deaths = {totalDeaths}");

        // Display the final lockdown decision based on the logic
        Console.WriteLine($"Decision: {currentDecision}");
    }

    /// <summary>
    /// Calculates the appropriate lockdown decision based on cases and deaths.
    /// This method contains only business logic with no console output, making it easily testable.
    /// </summary>
    /// <param name="positiveCases">Number of positive COVID-19 cases.</param>
    /// <param name="totalDeaths">Number of total deaths.</param>
    /// <returns>The decision string: "Lockdown the country", "Social distancing", or "Continue as normal".</returns>
    static string GetLockdownDecision(int positiveCases, int totalDeaths)
    {
        // Check if cases exceed 500 OR deaths exceed 10
        // The OR operator (||) means either condition triggers lockdown
        if (positiveCases > 500 || totalDeaths > 10)
        {
            // Return the most severe restriction if thresholds are breached
            return "Lockdown the country";
        }

        // If not lockdown, check if cases exceed 100
        // This is checked after the lockdown condition because it's less severe
        if (positiveCases > 100)
        {
            // Return moderate restriction for elevated case counts
            return "Social distancing";
        }

        // If neither condition above is met, cases are 100 or below and deaths are 10 or below
        // Return the least restrictive option
        return "Continue as normal";
    }
}