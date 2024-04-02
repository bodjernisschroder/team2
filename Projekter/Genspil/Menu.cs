using Genspil;
using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace Genspil
{

    public class Menu
    {
        public string Title;
        private MenuItem[] menuItems;
        private int itemCount = 0;
        private int menuWidth = 48;

        // Tilføjet af Anna
        // På en måde føler jeg denne hører hjemme i Program
        // eller alternativt i en manager, som så kan indeholde de metoder,
        // der skal kaldes, når vi indtaster forskellige tal
        Stock stock = new Stock();
        Search search = new Search();

        public Menu(string title, int size)
        {
            Title = title;
            menuItems = new MenuItem[size];
        }

        public void Show()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{Title}\n");
            Console.ResetColor();

            for (int i = 0; i < itemCount; i++)
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

        public void AddMenuItem(string menuTitle)
        {
            if (itemCount < menuItems.Length)
            {
                menuItems[itemCount++] = new MenuItem(menuTitle);
            }
        }


        public bool SelectMenuItem(int userInput)
        {


            switch (userInput)
            {
                case 0:
                    Console.WriteLine("Exiting...");
                    return false;
                case 1:

                    Console.Clear();

                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Addition Form (Step 1/7) ║");
                    Console.WriteLine("╚═══════════════════════════════╝");

                    Console.WriteLine("Enter the name of the game...");
                    Console.Write("\nName: ");
                    string name = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Addition Form (Step 2/7) ║");
                    Console.WriteLine("╚═══════════════════════════════╝");

                    Console.WriteLine("Choose the games condition...");
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

                    Console.Clear();

                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Addition Form (Step 4/7) ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Enter the language of the game: ");
                    Console.Write("\nLanguage: ");
                    string language = Console.ReadLine();
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

                    Console.Clear();

                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Addition Form (Step 6/7) ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Enter the minimum amount of players needed: ");
                    Console.Write("\nMin players: ");
                    int minPlayers = int.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine("║ Game Addition Form (Step 7/7) ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    Console.WriteLine("Enter the minimum amount of players needed: ");
                    Console.Write("\nMax players: ");
                    int maxPlayers = int.Parse(Console.ReadLine());
                    Console.Clear();

                    int boxWidth = 50;
                    Console.WriteLine("\n╔" + new string('═', boxWidth) + "╗");
                    Console.WriteLine($"║ Game successfully added to the inventory!".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Here are the details:".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║" + new string('═', boxWidth) + "║");
                    Console.WriteLine($"║ Name: {name}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Condition: {condition}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Price: {price.ToString("F2")}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Language: {language}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Category: {category}".PadRight(boxWidth) + " ║");
                    Console.WriteLine($"║ Players: {minPlayers}-{maxPlayers}".PadRight(boxWidth) + " ║");
                    Console.WriteLine("╚" + new string('═', boxWidth) + "╝");

                    Game newGame = new Game(name, price, language, minPlayers, maxPlayers, category, condition);

                    stock.Add(newGame);

                    Console.WriteLine("\nPress enter to return to the main menu...");
                    break;

                case 2:
                    search.StartSearch();
                    //Søg efter et spil på lageret ved navn, kategori, stand, pris, eller mængde af spillere
                    break;
                case 3:
                    //Tilføjet af Anna
                    stock.Show();
                    // Måske dette print skal være i en fælles afrunding i stedet?
                    Console.WriteLine("\nPress enter to return to the main menu...");
                    break;
                case 4:
                    //Opret en reservation fra en kunde
                    break;
                case 5:
                    stock.Show();
                    Console.Write("Enter the number of the game you want to remove from stock: ");
                    int gameToRemove = int.Parse(Console.ReadLine());
                    string gameName = stock.Remove(gameToRemove);
                    Console.Write("The game {0} was successfully removed from stock", gameName);
                    break;
                case 6:
                    stock.SortByName();
                    stock.Show();
                    break;
                case 7:
                    stock.SortByCategory();
                    stock.Show();
                    break;
                default:
                    Console.WriteLine("Invalid input, press enter to try again...");
                    break;
            }

            return true;
        }


    }
}