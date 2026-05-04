public static class PrimeNExercise
{
    public static void Run()
    {
        #region Configuration And Validation
        // Set the upper limit for finding prime numbers
        // We want all prime numbers strictly less than this value
        int limitN = 100;

        // Validate that the limit is at least 2
        // 2 is the smallest prime number, so we need limit >= 2 to find any primes
        if (limitN < 2)
        {
            // Display a user-friendly error message if the limit is too small
            Console.WriteLine("Please provide a number greater than 1 to find primes.");
            return; // Exit early since no primes exist below 2
        }
        #endregion Configuration And Validation

        #region Processing And Display
        // Call the method that finds and displays all prime numbers below the limit
        // Pass the validated limit as an argument
        DisplayPrimes(limitN);
        #endregion Processing And Display
    }

    /// <summary>
    /// Finds and displays all prime numbers less than the specified limit.
    /// </summary>
    /// <param name="maxValue">Upper bound (exclusive) for finding prime numbers.</param>
    static void DisplayPrimes(int maxValue)
    {
        // Create a list to store all prime numbers we find
        // Using a List<int> because we don't know how many primes exist beforehand
        List<int> primes = new List<int>();

        // Loop through every number starting from 2 (the first prime number)
        // Continue until we reach the maxValue (exclusive, so we check up to maxValue - 1)
        for (int i = 2; i < maxValue; i++)
        {
            // Check if the current number is prime by calling the helper method
            if (IsPrime(i))
            {
                // If it's prime, add it to our collection
                primes.Add(i);
            }
            // If not prime, simply continue to the next number
        }

        // Display the header showing what range we're displaying
        Console.WriteLine($"Prime numbers less than {maxValue}:");

        // Check if we found any prime numbers in the range
        if (primes.Count == 0)
        {
            // This handles edge cases like limitN = 2 (no primes less than 2)
            Console.WriteLine("No prime numbers found in the specified range.");
        }
        else
        {
            // Join all prime numbers with commas and display them as a single string
            Console.WriteLine(string.Join(", ", primes));
        }
    }

    /// <summary>
    /// Determines whether a given number is a prime number.
    /// A prime number is only divisible by 1 and itself.
    /// </summary>
    /// <param name="numberToCheck">The integer to test for primality.</param>
    /// <returns>True if the number is prime; otherwise, false.</returns>
    static bool IsPrime(int numberToCheck)
    {
        // Guard clause: numbers less than 2 are not prime by definition
        // 0 and 1 are neither prime nor composite
        if (numberToCheck < 2) return false;

        // Guard clause: 2 is the only even prime number
        // We handle it separately so we can skip all other even numbers later
        if (numberToCheck == 2) return true;

        // Guard clause: all other even numbers (4, 6, 8, etc.) are divisible by 2
        // This eliminates half of all numbers before entering the loop
        if (numberToCheck % 2 == 0) return false;

        // Check for odd divisors only, starting from 3
        // We only need to check up to the square root of the number
        // If a number has a factor larger than its square root, the corresponding factor would be smaller than the square root
        // We already checked for factor 2, so we start at 3 and increment by 2 to skip even numbers
        for (int i = 3; i * i <= numberToCheck; i += 2)
        {
            // Check if the number is evenly divisible by i (no remainder)
            if (numberToCheck % i == 0)
            {
                // If divisible, the number has a factor other than 1 and itself, so it's not prime
                return false;
            }
        }

        // If we checked all possible divisors up to the square root and found none,
        // the number is only divisible by 1 and itself, so it is prime
        return true;
    }
}