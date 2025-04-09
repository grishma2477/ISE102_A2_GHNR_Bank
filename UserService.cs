using System;

namespace GHNRBank
{
    // Handles all user-related operations like Signup and Login
    public class UserService
    {
        // Fixed-size array to store up to 100 users
        private User[] users = new User[100];

        // Tracks the number of users currently in the system
        private int userCount = 0;

        // Constructor: Initializes the user list with a default test user
        public UserService()
        {
            users[userCount] = new User
            {
                Username = "Joe.Doe",
                Email = "joe.doe@example.com",
                Age = 30,
                Phone = "0412345678",
                Password = "Password123"
            };
            userCount++; // Increments the count after adding the user
        }

        // Handles user registration
        public void Signup()
        {
            Console.WriteLine("\n========== Signup ==============");

            // Collect user details
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

            // Manual check for empty input fields (no built-in string methods)
            if (username == "" || email == "" || ageInput == "" || phone == "" || password == "")
            {
                Console.WriteLine("All fields are required. Please try again.");
                return;
            }

            // Manual validation and parsing of age (character by character)
            int age = 0;
            bool isValidAge = true;
            for (int i = 0; i < ageInput.Length; i++)
            {
                if (ageInput[i] < '0' || ageInput[i] > '9') // Not a digit
                {
                    isValidAge = false;
                    break;
                }
                age = age * 10 + (ageInput[i] - '0'); // Convert char to int
            }

            if (!isValidAge)
            {
                Console.WriteLine("Invalid age input. Please enter a valid number.");
                return;
            }

            // Check if user limit has been reached
            if (userCount >= 100)
            {
                Console.WriteLine("User limit reached.");
                return;
            }

            // Add new user to array
            users[userCount] = new User
            {
                Username = username,
                Email = email,
                Age = age,
                Phone = phone,
                Password = password
            };

            userCount++; // Increase the user count
            Console.WriteLine("Signup successful! You can now login.");
        }

        // Handles user login
        public User Login()
        {
            Console.WriteLine("\n========== Login ==============");

            int attempts = 3; // Allow up to 3 login attempts

            while (attempts > 0)
            {
                // Ask for credentials
                Console.Write("Enter email: ");
                string email = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                // Search through users to find a match
                for (int i = 0; i < userCount; i++)
                {
                    if (users[i].Email == email && users[i].Password == password)
                    {
                        Console.WriteLine($"\nLogin Successful. Welcome, {users[i].Username}!");
                        return users[i]; // Return the logged-in user
                    }
                }

                // If no match is found
                attempts--;
                Console.WriteLine("Invalid email or password.");

                if (attempts > 0)
                    Console.WriteLine($"You have {attempts} attempt(s) remaining.");
                else
                    Console.WriteLine("Too many failed attempts. Returning to main menu.");
            }

            return null; // Login failed
        }
    }
}
