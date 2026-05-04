using System;

class Program
{
    static void Main(string[] args)
    {
        // Variable to control the main application loop
        // Set to true so the menu displays at least once
        bool keepRunning = true;

        // Outer while loop keeps showing the menu until user selects exit (0)
        while (keepRunning)
        {
            // Clear the console for a clean menu display each iteration
            Console.Clear();

            // Display the main menu with all available exercises
            Console.WriteLine("--- C# Basics Exercises ---");
            Console.WriteLine("1. Mean");
            Console.WriteLine("2. EvenNumbers");
            Console.WriteLine("3. SumN");
            Console.WriteLine("4. Multiplication Table");
            Console.WriteLine("5. SortMedian");
            Console.WriteLine("6. Factorial");
            Console.WriteLine("7. Fibonacci");
            Console.WriteLine("8. ReverseArray");
            Console.WriteLine("9. CountVowels");
            Console.WriteLine("10. SecondLargest");
            Console.WriteLine("11. RemoveSpaces");
            Console.WriteLine("12. Repeater");
            Console.WriteLine("13. Coronavirus");
            Console.WriteLine("14. Calculate");
            Console.WriteLine("16. PrimeN");
            Console.WriteLine("17. SumDigits");
            Console.WriteLine("0. Exit");
            Console.Write("Selection: ");

            // Read the user's menu choice from console input
            // The ! suppresses nullable warning since ReadLine can return null
            string userChoice = Console.ReadLine()!;

            #region Exercise Switch Region
            // Use a switch statement to route to the selected exercise
            // Each case calls the static Run() method of the corresponding exercise class
            switch (userChoice)
            {
                case "1":
                    MeanExercise.Run();
                    break;
                case "2":
                    EvenNumbersExercise.Run();
                    break;
                case "3":
                    SumNExercise.Run();
                    break;
                case "4":
                    MultiplicationTableExercise.Run();
                    break;
                case "5":
                    SortMedianExercise.Run();
                    break;
                case "6":
                    FactorialExercise.Run();
                    break;
                case "7":
                    FibonacciExercise.Run();
                    break;
                case "8":
                    ReverseArrayExercise.Run();
                    break;
                case "9":
                    CountVowelsExercise.Run();
                    break;
                case "10":
                    SecondLargestExercise.Run();
                    break;
                case "11":
                    RemoveSpacesExercise.Run();
                    break;
                case "12":
                    RepeaterExercise.Run();
                    break;
                case "13":
                    CoronavirusExercise.Run();
                    break;
                case "14":
                    CalculateExercise.Run();
                    break;
                case "16":
                    PrimeNExercise.Run();
                    break;
                case "17":
                    SumDigitsExercise.Run();
                    break;
                case "0":
                    // User chose to exit - set flag to false to stop the while loop
                    Console.WriteLine("Exiting the program. Tata!");
                    keepRunning = false;
                    break;
                default:
                    // Handle invalid menu selections gracefully
                    Console.WriteLine("Invalid selection.");
                    break;
            }
            #endregion Exercise Switch Region

            // After executing the selected exercise (or handling invalid input/exit)
            // Check if we should pause before continuing or exiting
            if (keepRunning)
            {
                // If still running, pause so user can see results before menu reappears
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                // The while loop will naturally iterate again - NO recursive Main() call needed
            }
            else
            {
                // User selected exit (0) - display final message and pause before closing
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                // After ReadKey(), the while condition (keepRunning) is false, so loop exits
                // Program terminates naturally after Main() completes
            }
        }
        // End of while loop - program will exit normally
    }
}