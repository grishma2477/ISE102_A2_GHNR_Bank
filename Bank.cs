using System;

namespace GHNRBank
{
    // Represents the main bank system accessible after user login
    public class Bank
    {
        // Stores the currently logged-in user
        private User currentUser;

        // Constructor: Initializes the bank with the logged-in user
        public Bank(User user)
        {
            currentUser = user;
        }

        // Displays the main menu for logged-in users
        public void ShowMainMenu()
        {
            while (true)
            {
                // Display the list of available options
                Console.WriteLine("\n======== Main Menu =======");
                Console.WriteLine("1: View Balance");
                Console.WriteLine("2: Deposit");
                Console.WriteLine("3: Withdraw");
                Console.WriteLine("4: Transfer");
                Console.WriteLine("5: Quit");
                Console.Write("Select Option: ");

                // Get user input
                string option = Console.ReadLine();

                // Handle user's selected option
                switch (option)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        // Placeholder for upcoming features
                        Console.WriteLine("This feature is coming soon!");
                        break;

                    case "5":
                        // Exit the menu and logout
                        Console.WriteLine("Logging out...");
                        return;

                    default:
                        // Handle invalid input
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
