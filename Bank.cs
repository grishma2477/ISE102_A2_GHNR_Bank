using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHNRBank
{
    public class Bank
    {
        private User[] users = new User[100]; // Fixed-size user array
        private int userCount = 0;            // Tracks current user total

        // Default constructor: creates a test user
        public Bank()
        {
            users[userCount] = new User
            {
                Username = "Joe.Doe",
                Email = "joe.doe@example.com",
                Age = 30,
                Phone = "0412345678",
                Password = "Password123"
            };
            userCount++;
        }

        // Sign-up new users
        public void Signup()
        {
            Console.WriteLine("\n========== Signup ==============");

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

            // Manual empty check (no IsNullOrWhiteSpace)
            if (username == "" || email == "" || ageInput == "" || phone == "" || password == "")
            {
                Console.WriteLine("All fields are required. Please try again.");
                return;
            }

            // Manual parsing of age
            int age = 0;
            bool isValidAge = true;
            for (int i = 0; i < ageInput.Length; i++)
            {
                if (ageInput[i] < '0' || ageInput[i] > '9')
                {
                    isValidAge = false;
                    break;
                }
                age = age * 10 + (ageInput[i] - '0');
            }

            if (!isValidAge)
            {
                Console.WriteLine("Invalid age input. Please enter a valid number.");
                return;
            }

            if (userCount >= 100)
            {
                Console.WriteLine("User limit reached.");
                return;
            }

            users[userCount] = new User
            {
                Username = username,
                Email = email,
                Age = age,
                Phone = phone,
                Password = password
            };

            userCount++;
            Console.WriteLine("Signup successful! You can now login.");
        }

        // Login existing users
        public void Login()
        {
            Console.WriteLine("\n========== Login ==============");
            int attempts = 3;

            while (attempts > 0)
            {
                Console.Write("Enter email: ");
                string email = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                bool isFound = false;

                for (int i = 0; i < userCount; i++)
                {
                    if (users[i].Email == email && users[i].Password == password)
                    {
                        Console.WriteLine($"\nLogin Successful. Welcome, {users[i].Username}!");
                        ShowMainMenu();
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    return;
                }
                else
                {
                    attempts--;
                    Console.WriteLine("Invalid email or password.");

                    switch (attempts)
                    {
                        case 2:
                        case 1:
                            Console.WriteLine($"You have {attempts} attempt(s) remaining.");
                            break;

                        case 0:
                            Console.WriteLine("Too many failed attempts. Returning to main menu.");
                            break;
                    }
                }
            }
        }

        // Logged-in main menu
        private void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n======== Main Menu =======");
                Console.WriteLine("1: View Balance");
                Console.WriteLine("2: Deposit");
                Console.WriteLine("3: Withdraw");
                Console.WriteLine("4: Transfer");
                Console.WriteLine("5: Quit");
                Console.Write("Select Option: ");
                string option = Console.ReadLine();

                // Use switch here too
                switch (option)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        Console.WriteLine("This feature is coming soon!");
                        break;

                    case "5":
                        Console.WriteLine("Logging out...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}

