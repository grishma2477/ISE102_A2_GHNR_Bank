// Importing required namespaces
using System;                       // Provides basic functionalities like Console operations
using System.Collections.Generic;   // Provides List<T> to store users

// Define the namespace for this project
namespace GHNRBank
{
    // Main Program class
    class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            Bank bank = new Bank(); // Create a new Bank object to access its methods

            // Keep showing the menu until user quits
            while (true)
            {
                // Display main menu
                Console.WriteLine("\nWelcome to GHNR Bank");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Signup");
                Console.WriteLine("3: Quit");
                Console.Write("\nSelect Option: ");
                string choice = Console.ReadLine(); // Read user's choice

                // Perform action based on user's input
                switch (choice)
                {
                    case "1": // If user selects Login
                        bank.Login(); // Call Login method
                        break;

                    case "2": // If user selects Signup
                        bank.Signup(); // Call Signup method
                        break;

                    case "3": // If user selects Quit
                        Console.WriteLine("Thank you for using GHNR Bank!");
                        return; // Exit the program

                    default: // For invalid input
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }
    }

    // User class to represent a bank user
    public class User
    {
        // User properties
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }

    // Bank class handles login and signup operations
    public class Bank
    {
        // List to store all registered users
        private List<User> users = new List<User>();

        // Constructor: Initializes the Bank object with a dummy user
        public Bank()
        {
            users.Add(new User
            {
                Username = "Joe.Doe",
                Email = "joe.doe@example.com",
                Age = 30,
                Phone = "0412345678",
                Password = "Password123"
            });
        }

        // Method to handle Signup process
        public void Signup()
        {
            Console.WriteLine("\n========== Signup ==============");

            // Prompt user for details
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter age: ");
            string ageInput = Console.ReadLine();

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(ageInput) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("\nAll fields are required. Please try again.");
                return; // Exit method
            }

            // Convert age to integer and validate
            if (!int.TryParse(ageInput, out int age))
            {
                Console.WriteLine("\nInvalid age. Please enter a number.");
                return; // Exit method
            }

            // Add the new user to the users list
            users.Add(new User
            {
                Username = username,
                Email = email,
                Age = age,
                Phone = phone,
                Password = password
            });

            Console.WriteLine("\n=============== Signup Successful ==================\n You can now login.");
        }

        // Method to handle Login process
        public void Login()
        {
            Console.WriteLine("\n=============== Login ==================");

            int attempts = 3; // Maximum 3 attempts allowed

            // Loop until attempts run out
            while (attempts > 0)
            {
                // Ask for login credentials
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                // Check if user exists in the list
                foreach (User user in users)
                {
                    if (user.Email == email && user.Password == password)
                    {
                        Console.WriteLine($"\n=============== Login Successful ==================\nWelcome {user.Username}!"); // Successful login
                        ShowMainMenu(); // Show the main banking menu
                        return; // Exit the Login method
                    }
                }

                // If login fails
                attempts--; // Reduce attempts
                Console.WriteLine("\nInvalid email or password");

                if (attempts > 0)
                {
                    Console.WriteLine($"\nYou have {attempts} attempt(s) remaining.\n");
                }
                else
                {
                    Console.WriteLine("\nToo many failed attempts. Returning to main menu.");
                }
            }
        }

        // Shows the placeholder banking menu after login
        private void ShowMainMenu()
        {
            // Loop the menu until user quits
            while (true)
            {
                // Display options
                Console.WriteLine("\n======== Main Menu =======");
                Console.WriteLine("1: View Balance");
                Console.WriteLine("2: Deposit");
                Console.WriteLine("3: Withdraw");
                Console.WriteLine("4: Transfer");
                Console.WriteLine("5: Quit");
                Console.Write("\nSelect Option: ");
                string choice = Console.ReadLine();

                // If user selects Quit, break the loop
                if (choice == "5")
                {
                    Console.WriteLine("Logging out...");
                    break;
                }
                else
                {
                    // For now, all features are coming soon
                    Console.WriteLine("This feature is Coming Soon!");
                }
            }
        }
    }
}
