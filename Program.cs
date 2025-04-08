// Importing required namespaces
using System;                       // Provides basic functionalities like Console operations
using System.Collections.Generic;   // Provides List<T> to store users

// Define the namespace for this project
namespace GHNRBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(); // created bank object

            while (true)
            {
                Console.WriteLine("\nWelcome to GHNR Bank");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Signup");
                Console.WriteLine("3: Quit");
                Console.Write("\nSelect Option: ");
                string option = Console.ReadLine(); // asked for option 1, 2, 3 

                // Using switch statement for main menu
                switch (option)
                {
                    case "1":
                        bank.Login();
                        break;

                    case "2":
                        bank.Signup();
                        break;

                    case "3":
                        Console.WriteLine("Thank you for using GHNR Bank!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
