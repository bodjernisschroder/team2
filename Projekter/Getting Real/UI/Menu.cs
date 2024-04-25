using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Collections.Generic;

namespace GettingReal
{
    public class Menu
    {
        public string Title;
        private MenuItem[] menuItems;
        private int itemCount = 0;
        private int currentIndex = 0;

        public Menu(string title, int size)
        {
            this.Title = title;
            menuItems = new MenuItem[size];
        }

        public void AddMenuItem(string menuTitle)
        {
            if (itemCount < menuItems.Length)
            {
                menuItems[itemCount++] = new MenuItem(menuTitle);
            }
        }

        public void Show()
        {
            bool continueMenu = true;
            Console.CursorVisible = false;

            while (continueMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n{Title}\n");
                Console.ResetColor();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == currentIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    string menuItem = $" {menuItems[i].Title}";
                    menuItem = menuItem.PadRight(40, ' ');
                    Console.WriteLine(menuItem);
                }

                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║             Instruktioner            ║");
                Console.WriteLine("║══════════════════════════════════════║");
                Console.WriteLine("║ Naviger i menuen ved hjælp af pile-  ║");
                Console.WriteLine("║ tasterne. Tryk Enter for at foretage ║");
                Console.WriteLine("║ dit valg.                            ║");
                Console.WriteLine("╚══════════════════════════════════════╝");      

                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentIndex = (currentIndex > 0) ? currentIndex - 1 : menuItems.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        currentIndex = (currentIndex < menuItems.Length - 1) ? currentIndex + 1 : 0;
                        break;
                    case ConsoleKey.Enter:
                        continueMenu = SelectMenuItem(currentIndex + 1);
                        break;
                    case ConsoleKey.Escape:
                        continueMenu = false;
                        break;
                }      
            }
            Console.CursorVisible = true;
        }

        public bool SelectMenuItem(int userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    Exit();
                    return false;
                default:
                    Console.WriteLine("Ugyldigt input, prøv igen...");
                    break;
            }
            return true;
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Tryk en vilkårlig tast for at lukke programmet...");
        }
    }
}
