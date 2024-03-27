using Genspil;
using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
        int minPlayers = 0;
        int maxPlayers = 0;
        //string category = "";
        int condition = 0;

        switch (userInput)
        {
            case 0:
                Console.WriteLine("Exiting...");
                return false;
            case 1:
                
                Console.Write("Enter the name of the game: ");
                string name = Console.ReadLine();
                Console.Write("Enter the price of the game: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter the language of the game: ");
                string language = Console.ReadLine();
                // Tilføjet af Anna
                Console.Write("Enter the category of the game: ");
                string category = Console.ReadLine();

                Console.WriteLine($"\nYou've added the following game:\n\nName: {name}\nPrice: {price.ToString("F2")}\nLanguage: {language}\nCategory: {category}");

                Game newGame = new Game(name, price, language, minPlayers, maxPlayers, category, condition);

                //Tilføjet af Anna
                stock.Add(newGame);

                Console.WriteLine("\nPress enter to return to the main menu...");

                break;

            case 2:
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
                Console.WriteLine("              _.--\"\"`-..\r\n            ,'          `.\r\n          ,'          __  `.\r\n         /|          \" __   \\\r\n        , |           / |.   .\r\n        |,'          !_.'|   |\r\n      ,'             '   |   |\r\n     /              |`--'|   |\r\n    |                `---'   |\r\n     .   ,                   |                       ,\".\r\n      ._     '           _'  |                    , ' \\ `\r\n  `.. `.`-...___,...---\"\"    |       __,.        ,`\"   L,|\r\n  |, `- .`._        _,-,.'   .  __.-'-. /        .   ,    \\\r\n-:..     `. `-..--_.,.<       `\"      / `.        `-/ |   .\r\n  `,         \"\"\"\"'     `.              ,'         |   |  ',,\r\n    `.      '            '            /          '    |'. |/\r\n      `.   |              \\       _,-'           |       ''\r\n        `._'               \\   '\"\\                .      |\r\n           |                '     \\                `._  ,'\r\n           |                 '     \\                 .'|\r\n           |                 .      \\                | |\r\n           |                 |       L              ,' |\r\n           `                 |       |             /   '\r\n            \\                |       |           ,'   /\r\n          ,' \\               |  _.._ ,-..___,..-'    ,'\r\n         /     .             .      `!             ,j'\r\n        /       `.          /        .           .'/\r\n       .          `.       /         |        _.'.'\r\n        `.          7`'---'          |------\"'_.'\r\n       _,.`,_     _'                ,''-----\"'\r\n   _,-_    '       `.     .'      ,\\\r\n   -\" /`.         _,'     | _  _  _.|\r\n    \"\"--'---\"\"\"\"\"'        `' '! |! /\r\n                            `\" \" -' ");
                break;
            // Tilføjet af Anna
            case 6:
                stock.Show();
                Console.Write("Enter the number of the game you want to remove from stock: ");
                int gameToRemove = int.Parse(Console.ReadLine());
                string gameName = stock.Remove(gameToRemove);
                Console.Write("The game {0} was successfully removed from stock", gameName);
                break;
            case 7:
                stock.SortByName();
                stock.Show();
                break;
            case 8:
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