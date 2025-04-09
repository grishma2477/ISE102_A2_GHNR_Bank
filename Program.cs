// Importing required namespaces
using System;                       // Provides basic functionalities like Console operations
using System.Collections.Generic;   // Included for future use, such as collections like List<T>

// Define the namespace for this project
namespace GHNRBank
{
    // Entry point of the application
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the UserService to handle user-related operations
            UserService userService = new UserService();

            // Loop to continuously show the main menu until the user chooses to quit
            while (true)
            {
                // Display the main welcome menu
                Console.WriteLine("\nWelcome to GHNR Bank");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Signup");
                Console.WriteLine("3: Quit");
                Console.Write("\nSelect Option: ");

                // Read user input for menu selection
                string option = Console.ReadLine();

                // Handle the user input using a switch statement
                switch (option)
                {
                    case "1":
                        // Attempt to login the user
                        User user = userService.Login();

                        // If login is successful, create a Bank object and show the main menu
                        if (user != null)
                        {
                            Bank bank = new Bank(user);
                            bank.ShowMainMenu();
                        }
                        break;

                    case "2":
                        // Register a new user
                        userService.Signup();
                        break;

                    case "3":
                        // Exit the application
                        Console.WriteLine("Thank you for using GHNR Bank!");
                        return;

                    default:
                        // Handle invalid inputs
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
