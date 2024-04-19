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
        public string title;
        private MenuItem[] menuItems;
        private int itemCount = 0;

        public Menu(string title, int size)
        {
            this.title = title;
            menuItems = new MenuItem[size];
        }

        public void Show()
        {
            ShowMenu(title, menuItems);
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
            Console.Clear();
            switch (userInput)
            {
                case 0:
                    Exit();
                    return false;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
 
                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:
                    
                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            
            return true;
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
    }
}
