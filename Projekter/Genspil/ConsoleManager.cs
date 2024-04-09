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

        public static void ShowGameOnly(Game game, int i)
        {
            int boxWidth = 50;
            Console.WriteLine($"╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Game ID: {i}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowGame(game);
        }

        public static void ShowReservation(Customer customer, Game game)
        {
            int boxWidth = 50;
            Console.WriteLine($"║ Customer".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('─', boxWidth) + "║");
            Console.WriteLine($"║ Name: {customer.Name}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Email: {customer.Email}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Phone Number: {customer.PhoneNumber}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            Console.WriteLine($"║ Game".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('─', boxWidth) + "║");
            ShowGame(game);
        }

        public static void ShowReservationOnly(Customer customer, Game game, int i)
        {
            int boxWidth = 50;
            Console.WriteLine("╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Reservation ID: {i}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowReservation(customer, game);
        }

        /////////////////////////////////////////////////////////////////////////////
        // Related to Game Add
        public static string AddGameName()
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

        public static string AddGameCondition()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 2/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine("Choose the game's condition...");
            Console.WriteLine("\n1. Ny");
            Console.WriteLine("2. God");
            Console.WriteLine("3. Ok");
            Console.WriteLine("4. Dårlig");
            Console.WriteLine("5. Reparation");
            Console.WriteLine("6. N/A");
            Console.Write("\nCondition: ");
            string condition = "";
            int conditionInput = 0;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out conditionInput) && conditionInput >= 1 && conditionInput <= 6)
                {
                    switch (conditionInput)
                    {
                        case 1:
                            condition = "Ny";
                            break;
                        case 2:
                            condition = "God";
                            break;
                        case 3:
                            condition = "Ok";
                            break;
                        case 4:
                            condition = "Dårlig";
                            break;
                        case 5:
                            condition = "Reparation";
                            break;
                        case 6:
                            condition = "N/A";
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
                    Console.WriteLine("Invalid input. Please enter a valid number from 1-6...");
                    Console.WriteLine("\n1. Ny");
                    Console.WriteLine("2. God");
                    Console.WriteLine("3. Ok");
                    Console.WriteLine("4. Dårlig");
                    Console.WriteLine("5. Reparation");
                    Console.WriteLine("6. N/A");
                    Console.Write("\nCondition: ");
                }
            }
            return condition;
        }

        public static decimal AddGamePrice(string condition)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 3/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine("What's the games price when brand new?");
            Console.Write("\nPrice: ");
            decimal priceInput = decimal.Parse(Console.ReadLine());
            decimal price = 0;

            if (condition == "Ny") price = priceInput;
            else if (condition == "God") price = priceInput * 0.80m;
            else if (condition == "Ok") price = priceInput * 0.55m;
            else if (condition == "Dårlig") price = priceInput * 0.30m;
            else if (condition == "Reparation" || condition == "N/A") price = 0;
            return price;
        }

        public static string AddGameLanguage()
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

        public static string AddGameCategory()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Addition Form (Step 5/7) ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Choose the games category...");
            Console.WriteLine("\n1. Familiespil");
            Console.WriteLine("2. Børnespil");
            Console.WriteLine("3. Rejsespil");
            Console.WriteLine("4. Strategispil");
            Console.WriteLine("5. Quizspil");
            Console.WriteLine("6. Selskabsspil");
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
                            category = "Familiespil";
                            break;
                        case 2:
                            category = "Børnespil";
                            break;
                        case 3:
                            category = "Rejsespil";
                            break;
                        case 4:
                            category = "Strategispil";
                            break;
                        case 5:
                            category = "Quizspil";
                            break;
                        case 6:
                            category = "Selskabsspil";
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
                    Console.WriteLine("\n1. Familiespil");
                    Console.WriteLine("2. Børnespil");
                    Console.WriteLine("3. Rejsespil");
                    Console.WriteLine("4. Strategispil");
                    Console.WriteLine("5. Quizspil");
                    Console.WriteLine("6. Selskabsspil");
                    Console.Write("\nCategory: ");
                }
            }
            return category;
        }

        public static int AddGameMinPlayers()
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

        public static int AddGameMaxPlayers()
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
        // Related to Game Modify
        public static int SelectGameToModify(List<Game> stock)
        {
            Console.Clear();
            for (int i = 0; i < stock.Count; i++)
            {
                ShowGameOnly(stock[i], i);
            }
            Console.Write("\nEnter the ID of the game you wish to modify: ");
            int gameID = int.Parse(Console.ReadLine());
            return gameID;
        }

        public static bool ModifyGame(Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Game To Modify".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowGame(game);
            Console.WriteLine("\n1. Name");
            Console.WriteLine("2. Condition");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Language");
            Console.WriteLine("5. Category");
            Console.WriteLine("6. Minimum Players");
            Console.WriteLine("7. Maximum Players");
            Console.Write("\nSelect which parameter of the game you wish to modify or press Enter to exit modification of game: ");
            string userInput = "";
            int input = 0;

            while (true)
            {
                userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput)) return false;
                if (int.TryParse(userInput, out input) && input >= 1 && input <= 7)
                {
                    switch (input)
                    {
                        case 1:
                            game.Name = ModifyGameName();
                            break;
                        case 2:
                            game.Condition = ModifyGameCondition();
                            break;
                        case 3:
                            game.Price = ModifyGamePrice(game.Condition);
                            break;
                        case 4:
                            game.Language = ModifyGameLanguage();
                            break;
                        case 5:
                            game.Category = ModifyGameCategory();
                            break;
                        case 6:
                            game.MinPlayers = ModifyGameMinPlayers();
                            break;
                        case 7:
                            game.MaxPlayers = ModifyGameMaxPlayers();
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
                    Console.WriteLine($"║ Game To Modify".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║" + new string('═', boxWidth) + "║");
                    ShowGame(game);
                    Console.WriteLine("Invalid input. Please enter a valid number from 1-7...");
                    Console.WriteLine("\n1. Name");
                    Console.WriteLine("2. Condition");
                    Console.WriteLine("3. Price");
                    Console.WriteLine("4. Language");
                    Console.WriteLine("5. Category");
                    Console.WriteLine("6. Minimum Players");
                    Console.WriteLine("7. Maximum Players");
                    Console.Write("\nSelect which parameter of the game you wish to modify: ");
                }
            }
            return true;
        }

        public static void ModifyGameFromStock(Game game)
        {
            bool modified = ModifyGame(game);
            if (modified == true) GameModified(game);
        }

        public static void GameModified(Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Game successfully modified!".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowGame(game);
            Console.Write("\nPress Enter to return to modification of game");
            Console.ReadKey();
            ModifyGame(game);
        }

        public static string ModifyGameName()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Modification             ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Enter the name of the game...");
            Console.Write("\nName: ");
            string name = Console.ReadLine();
            return name;
        }


        public static string ModifyGameCondition()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Modification             ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine("Choose the game's condition...");
            Console.WriteLine("\n1. Ny");
            Console.WriteLine("2. God");
            Console.WriteLine("3. Ok");
            Console.WriteLine("4. Dårlig");
            Console.WriteLine("5. Reparation");
            Console.WriteLine("6. N/A");
            Console.Write("\nCondition: ");
            string condition = "";
            int conditionInput = 0;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out conditionInput) && conditionInput >= 1 && conditionInput <= 6)
                {
                    switch (conditionInput)
                    {
                        case 1:
                            condition = "Ny";
                            break;
                        case 2:
                            condition = "God";
                            break;
                        case 3:
                            condition = "Ok";
                            break;
                        case 4:
                            condition = "Dårlig";
                            break;
                        case 5:
                            condition = "Reparation";
                            break;
                        case 6:
                            condition = "N/A";
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Modification             ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Invalid input. Please enter a valid number from 1-6...");
                    Console.WriteLine("\n1. Ny");
                    Console.WriteLine("2. God");
                    Console.WriteLine("3. Ok");
                    Console.WriteLine("4. Dårlig");
                    Console.WriteLine("5. Reparation");
                    Console.WriteLine("6. N/A");
                    Console.Write("\nCondition: ");
                }
            }
            return condition;
        }

        public static decimal ModifyGamePrice(string condition)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Modification             ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            Console.WriteLine("What's the games price when brand new?");
            Console.Write("\nPrice: ");
            decimal priceInput = decimal.Parse(Console.ReadLine());
            decimal price = 0;

            if (condition == "Ny") price = priceInput;
            else if (condition == "God") price = priceInput * 0.80m;
            else if (condition == "Ok") price = priceInput * 0.55m;
            else if (condition == "Dårlig") price = priceInput * 0.30m;
            else if (condition == "Reparation" || condition == "N/A") price = 0;
            return price;
        }

        public static string ModifyGameLanguage()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Modification             ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Enter the language of the game: ");
            Console.Write("\nLanguage: ");
            string language = Console.ReadLine();
            return language;
        }

        public static string ModifyGameCategory()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Modification             ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Choose the games category...");
            Console.WriteLine("\n1. Familiespil");
            Console.WriteLine("2. Børnespil");
            Console.WriteLine("3. Rejsespil");
            Console.WriteLine("4. Strategispil");
            Console.WriteLine("5. Quizspil");
            Console.WriteLine("6. Selskabsspil");
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
                            category = "Familiespil";
                            break;
                        case 2:
                            category = "Børnespil";
                            break;
                        case 3:
                            category = "Rejsespil";
                            break;
                        case 4:
                            category = "Strategispil";
                            break;
                        case 5:
                            category = "Quizspil";
                            break;
                        case 6:
                            category = "Selskabsspil";
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Modification             ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Invalid input. Please enter a valid number from 1-6...");
                    Console.WriteLine("\n1. Familiespil");
                    Console.WriteLine("2. Børnespil");
                    Console.WriteLine("3. Rejsespil");
                    Console.WriteLine("4. Strategispil");
                    Console.WriteLine("5. Quizspil");
                    Console.WriteLine("6. Selskabsspil");
                    Console.Write("\nCategory: ");
                }
            }
            return category;
        }

        public static int ModifyGameMinPlayers()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Modification             ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.WriteLine("Enter the minimum amount of players needed: ");
            Console.Write("\nMin players: ");
            int minPlayers = int.Parse(Console.ReadLine());
            return minPlayers;
        }

        public static int ModifyGameMaxPlayers()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Game Modification             ║");
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

        public static int RemoveGame(List<Game> stock)
        {
            Console.Clear();
            for (int i = 0; i < stock.Count; i++)
            {
                ShowGameOnly(stock[i], i);
            }
            Console.Write("Enter the ID of the game you want to remove from stock: ");
            int gameToRemove = int.Parse(Console.ReadLine());
            return gameToRemove;
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

        /////////////////////////////////////////////////////////////////////////////
        // Related to Reservations
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
                ShowGameOnly(stock[i], i);
            }
            Console.Write("Enter the ID of the game you want to reserve: ");
            int gameToReserve = int.Parse(Console.ReadLine());
            return gameToReserve;
        }

        public static void ReservationAdded(Customer customer, Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Reservation successfully added!".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowReservation(customer, game);
        }

        public static int RemoveReservedGame(List<KeyValuePair<Customer, Game>> reservations)
        {
            Console.Clear();
            for (int i = 0; i < reservations.Count; i++)
            {
                ShowReservationOnly(reservations[i].Key, reservations[i].Value, i);
            }
            Console.Write("Enter the ID of the reservation you want to remove: ");
            int reservationID = int.Parse(Console.ReadLine());
            return reservationID;
        }

        public static void ReservationRemoved(Customer customer, Game game)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Reservation successfully removed!".PadRight(boxWidth) + " ║");
            ShowReservation(customer, game);
        }

        /////////////////////////////////////////////////////////////////////////////
        // Related to Reservation Modification
        public static int SelectReservationToModify(List<KeyValuePair<Customer, Game>> reservations)
        {
            // Change to fit list reservation & ID
            Console.Clear();
            for (int i = 0; i < reservations.Count; i++)
            {
                ShowReservationOnly(reservations[i].Key, reservations[i].Value, i);
            }
            Console.Write("\nEnter the ID of the reservation you wish to modify: ");
            int reservationID = int.Parse(Console.ReadLine());
            return reservationID;
        }

        public static void ModifyReservation(KeyValuePair<Customer, Game> reservation)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Reservation To Modify".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowReservation(reservation.Key, reservation.Value);
            Console.WriteLine("\n1. Customer");
            Console.WriteLine("2. Game");
            Console.Write("\nSelect which part of the reservation you wish to modify or press Enter to exit modification of reservation: ");
            int input = 0;

            while (true)
            {
                string userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput)) return;
                if (int.TryParse(userInput, out input) && input >= 1 && input <= 2)
                {
                    switch (input)
                    {
                        case 1:
                            ModifyCustomer(reservation);
                            break;
                        case 2:
                            ModifyGameFromReservation(reservation);
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
                    Console.WriteLine($"║ Reservation To Modify".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║" + new string('═', boxWidth) + "║");
                    ShowReservation(reservation.Key, reservation.Value);
                    Console.WriteLine("Invalid input. Please enter a valid number from 1-2...");
                    Console.WriteLine("\n1. Customer");
                    Console.WriteLine("2. Game");
                    Console.Write("\nSelect which part of the reservation you wish to modify or press Enter to exit modification of reservation: ");
                }
            }
        }

        public static void ModifyCustomer(KeyValuePair<Customer, Game> reservation)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Customer To Modify".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            Console.WriteLine($"║ Name: {reservation.Key.Name}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Email: {reservation.Key.Email}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║ Phone Number: {reservation.Key.PhoneNumber}".PadRight(boxWidth) + " ║");
            Console.WriteLine($"╚" + new string('═', boxWidth) + "╝");
            Console.WriteLine("\n1. Name");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Phone Number");
            Console.Write("\nSelect which parameter of the customer you wish to modify or press Enter to exit modification of customer: ");
            int input = 0;

            while (true)
            {
                string userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    ModifyReservation(reservation);
                    return;
                }
                if (int.TryParse(userInput, out input) && input >= 1 && input <= 3)
                {
                    switch (input)
                    {
                        case 1:
                            reservation.Key.Name = ModifyCustomerName();
                            break;
                        case 2:
                            reservation.Key.Email = ModifyCustomerEmail();
                            break;
                        case 3:
                            reservation.Key.PhoneNumber = ModifyCustomerPhoneNumber();
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
                    Console.WriteLine($"║ Customer To Modify".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║" + new string('═', boxWidth) + "║");
                    Console.WriteLine($"║ Name: {reservation.Key.Name}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Email: {reservation.Key.Email}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Phone Number: {reservation.Key.PhoneNumber}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"╚" + new string('═', boxWidth) + "╝");
                    Console.WriteLine("\n1. Name");
                    Console.WriteLine("2. Email");
                    Console.WriteLine("3. Phone Number");
                    Console.Write("\nSelect which parameter of the customer you wish to modify or press Enter to exit modification of customer: ");
                }
            }
            ReservationModified(reservation);
        }

        public static void ModifyGameFromReservation(KeyValuePair<Customer, Game> reservation)
        {
            bool modified = ModifyGame(reservation.Value);
            if (modified) ReservationModified(reservation);
            else ModifyReservation(reservation);
        }

        public static void ReservationModified(KeyValuePair<Customer, Game> reservation)
        {
            Console.Clear();
            int boxWidth = 50;
            Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
            Console.WriteLine($"║ Reservation successfully modified!".PadRight(boxWidth) + " ║");
            Console.WriteLine($"║" + new string('═', boxWidth) + "║");
            ShowReservation(reservation.Key, reservation.Value);
            Console.Write("\nPress Enter to return to modification of reservation");
            Console.ReadKey();
            ModifyReservation(reservation);
        }

        public static string ModifyCustomerName()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Customer Modification             ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.WriteLine("Enter the name of the customer...");
            Console.Write("\nName: ");
            string name = Console.ReadLine();
            return name;
        }

        public static string ModifyCustomerEmail()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Customer Modification             ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.WriteLine("Enter the email of the customer...");
            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            return email;
        }

        public static string ModifyCustomerPhoneNumber()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Customer Modification             ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.WriteLine("Enter the phone number of the customer...");
            Console.Write("\nPhone Number: ");
            string phoneNumber = Console.ReadLine();
            return phoneNumber;
        }

        /////////////////////////////////////////////////////////////////////////////
        // Related to Search
        public static string SearchPromptName()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Game name (Step 1/5)              ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.Write("Please enter the name of the game: ");
            string searchQueryName = Console.ReadLine();
            return searchQueryName;
        }

        public static string SearchPromptCategory()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Game category (Step 2/5)          ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.Write("Please enter game category: ");
            string searchQueryCategory = Console.ReadLine();
            return searchQueryCategory;
        }

        public static decimal SearchPromptMinPrice()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Lower range price (Step 3/5)      ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            Console.Write("Please enter the lower range of the price: ");
            decimal searchQueryMinPrice = decimal.Parse(Console.ReadLine());
            return searchQueryMinPrice;
        }

        public static decimal SearchPromptMaxPrice()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Upper range price (Step 4/5)      ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.Write("Please enter the upper range of the price: ");
            decimal searchQueryMaxPrice = decimal.Parse(Console.ReadLine());
            return searchQueryMaxPrice;
        }

        public static int SearchPromptPlayers()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║ Amount of players (Step 5/5)      ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.Write("Please enter the number of players: ");
            int searchQueryPlayers = int.Parse(Console.ReadLine());
            return searchQueryPlayers;
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