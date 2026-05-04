using System;
using System.Text;

public static class RepeaterExercise
{
    public static void Run()
    {
        #region Read Region
        // Camel casing for all variables per standard
        int repeatCount = 3;
        char firstChar = 'e';
        char secondChar = 'r';
        #endregion Read Region

        #region Validation Region
        // Use regions for all if statements per standard
        if (repeatCount < 0)
        {
            // User friendly error messages are to be displayed on the UI
            Console.WriteLine("The repeat count cannot be a negative number.");
            return;
        }
        #endregion Validation Region

        #region Modify Region
        // Pascal casing for method names per standard
        string repeatedString = RepeatCharacters(repeatCount, firstChar, secondChar);
        Console.WriteLine($"Result: {repeatedString}");
        #endregion Modify Region
    }

    /// <summary>
    /// Repeats two characters a specified number of times.
    /// Pascal casing for all parameters per standard.
    /// </summary>
    static string RepeatCharacters(int RepeatTimes, char CharOne, char CharTwo)
    {
        #region Process Region
        try
        {
            // Using StringBuilder for efficiency in string manipulation
            StringBuilder resultBuilder = new StringBuilder();

            #region Loop Region
            for (int i = 0; i < RepeatTimes; i++)
            {
                resultBuilder.Append(CharOne);
                resultBuilder.Append(CharTwo);
            }
            #endregion Loop Region

            return resultBuilder.ToString();
        }
        catch (Exception ex)
        {
            // User friendly error messages per standard
            Console.WriteLine("An error occurred while repeating the characters. Please contact your administrator.");
            return string.Empty;
        }
        #endregion Process Region
    }
}