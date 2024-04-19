using System;
using System.Collections;
using System.Collections.Generic;

namespace GettingReal
{
    internal static class ConsoleManager
    {

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