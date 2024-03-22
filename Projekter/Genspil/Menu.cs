using Genspil;
using System;
using System.ComponentModel.Design;
using System.Reflection;

public class Menu
{
    public string Title;
    private MenuItem[] menuItems;
    private int itemCount = 0;

    public Menu(string title, int size)
    {
        Title = title;
        menuItems = new MenuItem[size];
    }

    public void Show()
    {
        Console.Clear();

        Console.WriteLine($"{Title}\n");

        for (int i = 0; i < itemCount; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i].Title}");
        }
        Console.WriteLine("\n(Tryk menupunkt eller 0 for at afslutte)");
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
                break;
            case 1:
                Console.WriteLine("Gør dit");
                break;
            case 2:
                Console.WriteLine("Gør dat");
                break;
            case 3:
                Console.WriteLine("Gør noget");
                break;
            case 4:
                Console.WriteLine("42");
                break;
            default:
                Console.WriteLine("Forkert input, prøv igen.");
                break;
        }

        return true;
    }
}