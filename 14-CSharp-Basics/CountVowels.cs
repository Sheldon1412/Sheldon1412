public static class CountVowelsExercise
{
    public static void Run()
    {
        #region Input And Validation
        // Prompt the user to enter a sentence for vowel counting
        Console.Write("Enter a sentence to count the vowels: ");
        // Read the user's input from the console
        // Note: Console.ReadLine() can return null, so we handle that in validation
        string userSentence = Console.ReadLine()!;

        // Validate that the user actually entered something (not null, empty, or just whitespace)
        // string.IsNullOrWhiteSpace checks for null, empty string "", and strings with only spaces/tabs
        if (string.IsNullOrWhiteSpace(userSentence))
        {
            // Display a friendly error message if the input is invalid
            Console.WriteLine("The sentence cannot be empty. Please try again.");
            return; // Exit early since we cannot process empty input
        }
        #endregion Input And Validation

        #region Process And Display
        // Call the CountVowels method and pass the validated sentence
        // Store the returned integer (vowel count) in a variable
        int totalVowels = CountVowels(userSentence);
        // Display the final result to the user using string interpolation ($"...")
        Console.WriteLine($"Total number of vowels found: {totalVowels}");
        #endregion Process And Display
    }

    /// <summary>
    /// Calculates the number of vowels (a, e, i, o, u) in a string.
    /// </summary>
    /// <param name="inputSentence">The string to analyze for vowels.</param>
    /// <returns>Total count of vowels in the sentence.</returns>
    static int CountVowels(string inputSentence)
    {
        // Initialize a counter variable to keep track of how many vowels we find
        // Starting at 0 because we haven't counted any yet
        int vowelCount = 0;

        // Loop through each character in the input string one by one
        // The 'char' variable 'character' will hold the current letter in each iteration
        foreach (char character in inputSentence)
        {
            // Convert the current character to lowercase so we only check against lowercase vowels
            // This avoids needing to check both uppercase 'A' and lowercase 'a'
            char lowerChar = char.ToLower(character);

            // Check if the current character is one of the five vowels
            // Using the OR operator (||) means if ANY of these conditions is true, the whole if is true
            if (lowerChar == 'a' || lowerChar == 'e' || lowerChar == 'i' ||
                lowerChar == 'o' || lowerChar == 'u')
            {
                // If the character is a vowel, increment the counter by 1
                vowelCount++;
            }
            // If the character is not a vowel, we simply do nothing and move to the next character
        }

        // Return the final count back to the caller (the Run method)
        return vowelCount;
    }
}