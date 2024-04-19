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
            ConsoleManager.ShowMenu(title, menuItems);
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
                    ConsoleManager.Exit();
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
    }
}
