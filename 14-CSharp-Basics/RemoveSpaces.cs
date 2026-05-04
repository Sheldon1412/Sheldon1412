using System;

public static class RemoveSpacesExercise
{
    public static void Run()
    {
        #region Input And Validation
        // Prompt the user to enter a sentence from which spaces will be removed
        Console.Write("Enter a sentence to remove spaces: ");
        // Read the user's input from the console
        // Console.ReadLine() returns null if input is redirected and empty, or the string entered by the user
        string userSentence = Console.ReadLine()!;

        // Validate that the input is not null or an empty string ""
        // string.IsNullOrEmpty checks for both null and empty string, but not whitespace-only strings
        // We use this instead of IsNullOrWhiteSpace to allow sentences with only spaces to be processed (all spaces removed = empty result)
        if (string.IsNullOrEmpty(userSentence))
        {
            // Display a user-friendly error message if no text was entered
            Console.WriteLine("Input cannot be empty. Please enter a valid sentence.");
            return; // Exit early since we have no text to process
        }
        #endregion Input And Validation

        #region Process And Display
        // Call the method that removes spaces and displays the result
        // Pass the validated sentence as an argument
        RemoveAndDisplayString(userSentence);
        #endregion Process And Display
    }

    /// <summary>
    /// Removes all spaces from a string and displays the result.
    /// </summary>
    /// <param name="inputText">The string to remove spaces from.</param>
    static void RemoveAndDisplayString(string inputText)
    {
        // Use the string.Replace method to remove all space characters
        // The first argument " " is the old value (space character) to find
        // The second argument "" is the new value (empty string) to replace it with
        // This creates a new string; the original inputText variable remains unchanged (strings are immutable in C#)
        string textWithoutSpaces = inputText.Replace(" ", "");

        // Display the processed result to the user using string interpolation
        Console.WriteLine($"Result: {textWithoutSpaces}");
    }
}