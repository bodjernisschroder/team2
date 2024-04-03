using System;
using System.Collections;
using System.Collections.Generic;

namespace Genspil
{
    internal static class ConsoleManager
    {
        /////////////////////////////////////////////////////////////////////////////
        // Related to Menu
        public static void EndOfCase()
        {
            Console.WriteLine("\nPress enter to return to the main menu...");
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Exiting...");
        }
        public static void ShowMenu(string title, MenuItem[] menuItems)
        {
            int menuWidth = 48;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{title}\n");
            Console.ResetColor();

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.BackgroundColor = i % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                string menuItem = $"{i + 1}. {menuItems[i].Title}";
                menuItem = menuItem.PadRight(menuWidth, ' ');

                Console.WriteLine(menuItem);
                Console.ResetColor();
            }

            Console.Write("\nPick a number or type 0 to exit the program: ");
        }

        /////////////////////////////////////////////////////////////////////////////
        // Show
        public static void ShowGame(Game game)
        {
            int boxWidth = 50;
            Console.WriteLine($"║ Name: {game.Name}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Condition: {game.Condition}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Price: {game.Price.ToString("F2")}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Language: {game.Language}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Category: {game.Category}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Players: {game.MinPlayers}-{game.MaxPlayers}".PadRight(boxWidth) + " ║");
            Console.WriteLine("╚" + new string('═', boxWidth) + "╝");
        }

        public static void ShowGameOnly(Game game)
        {
            int boxWidth = 50;
            Console.WriteLine($"╔" + new string('═', boxWidth) + "╗");
            ShowGame(game);
        }

        public static void ShowReservation(Customer customer, Game game)
        {
            int boxWidth = 50;
            Console.WriteLine($"║ Customer".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('-', boxWidth) + "║");
            Console.WriteLine($"║ Name: {customer.Name}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Email: {customer.Email}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Phone Number: {customer.PhoneNumber}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            Console.WriteLine($"║ Game".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('-', boxWidth) + "║");
            ShowGame(game);
        }

        public static void ShowReservationOnly(Customer customer, Game game)
        {
            int boxWidth = 50;
            Console.WriteLine("╔" + new string('═', boxWidth) + "╗");
            ShowReservation(customer, game);
        }

        /////////////////////////////////////////////////////////////////////////////
        // Related to Game
        public static string AddName()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 1/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine("Enter the name of the game...");
            Console.Write("\nName: ");
            string name = Console.ReadLine();
            return name;
        }

        public static string AddCondition()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 2/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine("Choose the game's condition...");
            Console.WriteLine("\n1. New");
            Console.WriteLine("2. Good");
            Console.WriteLine("3. Ok");
            Console.WriteLine("4. Bad");
            Console.WriteLine("5. Needs repairing");
            Console.Write("\nCondition: ");
            string condition = "";
            int conditionInput = 0;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out conditionInput) && conditionInput >= 1 && conditionInput <= 5)
                {
                    switch (conditionInput)
                    {
                        case 1:
                            condition = "New";
                            break;
                        case 2:
                            condition = "Good";
                            break;
                        case 3:
                            condition = "Ok";
                            break;
                        case 4:
                            condition = "Bad";
                            break;
                        case 5:
                            condition = "Needs repairing";
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Addition Form (Step 2/7) ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Invalid input. Please enter a valid number from 1-5...");
                    Console.WriteLine("\n1. New");
                    Console.WriteLine("2. Good");
                    Console.WriteLine("3. Ok");
                    Console.WriteLine("4. Bad");
                    Console.WriteLine("5. Needs repairing");
                    Console.Write("\nCondition: ");
                }
            }
            return condition;
        }

        public static decimal AddPrice(string condition)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 3/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine("What's the games price when brand new?");
            Console.Write("\nPrice: ");
            decimal priceInput = decimal.Parse(Console.ReadLine());
            decimal price = 0;

            if (condition == "New") price = priceInput;
            else if (condition == "Good") price = priceInput * 0.80m;
            else if (condition == "Ok") price = priceInput * 0.55m;
            else if (condition == "Bad") price = priceInput * 0.30m;
            else if (condition == "Needs repairing") price = 0;
            return price;
        }

        public static string AddLanguage()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 4/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Enter the language of the game: ");
            Console.Write("\nLanguage: ");
            string language = Console.ReadLine();
            return language;
        }

        public static string AddCategory()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 5/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Choose the games category...");
            Console.WriteLine("\n1. Strategy");
            Console.WriteLine("2. Card");
            Console.WriteLine("3. Role-Playing");
            Console.WriteLine("4. Adventure");
            Console.WriteLine("5. Puzzle");
            Console.WriteLine("6. Quiz");
            Console.Write("\nCategory: ");
            string category = "";
            int categoryInput = 0;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out categoryInput) && categoryInput >= 1 && categoryInput <= 6)
                {
                    switch (categoryInput)
                    {
                        case 1:
                            category = "Strategy";
                            break;
                        case 2:
                            category = "Card";
                            break;
                        case 3:
                            category = "Role-Playing";
                            break;
                        case 4:
                            category = "Adventure";
                            break;
                        case 5:
                            category = "Puzzle";
                            break;
                        case 6:
                            category = "Quiz";
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Addition Form (Step 5/7) ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Invalid input. Please enter a valid number from 1-6...");
                    Console.WriteLine("\n1. Strategy");
                    Console.WriteLine("2. Card");
                    Console.WriteLine("3. Role-Playing");
                    Console.WriteLine("4. Adventure");
                    Console.WriteLine("5. Puzzle");
                    Console.WriteLine("6. Quiz");
                    Console.Write("\nCategory: ");
                }
            }
            return category;
        }

        public static int AddMinPlayers()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 6/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Enter the minimum amount of players needed: ");
            Console.Write("\nMin players: ");
            int minPlayers = int.Parse(Console.ReadLine());
            return minPlayers;
        }

        public static int AddMaxPlayers()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 7/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Enter the minimum amount of players needed: ");
            Console.Write("\nMax players: ");
            int maxPlayers = int.Parse(Console.ReadLine());
            return maxPlayers;
        }

        /////////////////////////////////////////////////////////////////////////////
        // Related to Stock
        public static void GameAdded(Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Game successfully added to the inventory!".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowGame(game);
        }

        public static void GameRemoved(Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Game successfully removed from the inventory!".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowGame(game);
        }

        public static int RemoveGame(List<Game> stock)
        {
            for (int i = 0; i < stock.Count; i++)
            {
                int boxWidth = 50;
                Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
                Console.WriteLine($"║ Game ID: {i}".PadRight(boxWidth) + " ║");
                ShowGame(stock[i]);
            }
            Console.Write("Enter the ID of the game you want to remove from stock: ");
            int gameToRemove = int.Parse(Console.ReadLine());
            return gameToRemove;
        }

        /////////////////////////////////////////////////////////////////////////////
        // Related to Reservations
        public static void ReservationAdded(Customer customer, Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Reservation successfully added!".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowReservation(customer, game);
        }

        public static void ReservationRemoved(Customer customer, Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Reservation successfully removed!".PadRight(boxWidth) + " ║");
            ShowReservation(customer, game);
            ShowGame(game);
        }

        public static string AddCustomerName()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Customer Addition Form (Step 1/3) ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.WriteLine("Enter the name of the customer...");
            Console.Write("\nName: ");
            string name = Console.ReadLine();
            return name;
        }

        public static string AddCustomerEmail()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Customer Addition Form (Step 2/3) ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.WriteLine("Enter the email of the customer...");
            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            return email;
        }

        public static string AddCustomerPhoneNumber()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Customer Addition Form (Step 3/3) ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.WriteLine("Enter the phone number of the customer...");
            Console.Write("\nPhone Number: ");
            string phoneNumber = Console.ReadLine();
            return phoneNumber;
        }

        public static int ReserveGame(List<Game> stock)
        {
            Console.Clear();
            for (int i = 0; i < stock.Count; i++)
            {
                int boxWidth = 50;
                Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
                Console.WriteLine($"║ Game ID: {i}".PadRight(boxWidth) + " ║");
                ShowGame(stock[i]);
            }

            Console.Write("Enter the ID of the game you want to reserve: ");
            int gameToReserve = int.Parse(Console.ReadLine());
            return gameToReserve;
        }

        /////////////////////////////////////////////////////////////////////////////
        // Related to Search
        public static string SearchPrompt()
        {
            Console.Clear();
            Console.Write("Please enter game name, category, or condition: ");
            string searchQuery = Console.ReadLine();
            return searchQuery;
        }

        public static void SearchResults()
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Search Results ".PadRight(boxWidth) + " ║");
            Console.WriteLine("╚" + new string('═', boxWidth) + "╝");
        }
    }
}