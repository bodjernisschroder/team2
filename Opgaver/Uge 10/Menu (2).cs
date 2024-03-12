//using System;
//public class Menu3
//{
//    static void Main3(string[] args)
//    {
//        Menu myMenu = new Menu("Hovedmenu", 10); // Lad os sige, der er plads til 10 items
//        myMenu.AddMenuItem("Spil Spil");
//        myMenu.AddMenuItem("Indstillinger");
//        myMenu.AddMenuItem("Afslut");

//        myMenu.Show();

//        Console.ReadKey(); // Vent på et tastetryk for at holde konsollen åben
//    }

//    public string Title { get; set; }
//    private string[] menuItems;
//    private int itemCount = 0;

//    public Menu(string title, int size)
//    {
//        Title = title;
//        menuItems = new string[size];
//        itemCount = 0;
//    }
//    public void AddMenuItem(string item)
//    {
//        if (itemCount < menuItems.Length)
//        {
//            menuItems[itemCount++] = item;
//        }
//    }

//    public void Show()
//    {
//        Console.Clear();
//        Console.WriteLine(Title + "\n");
//        for (int i = 0; i < itemCount; i++)
//        {
//            Console.WriteLine($"{i + 1}. {menuItems[i]}");
//        }
//        Console.WriteLine("\nVælg en mulighed fra menuen ovenfor:");
//    }
//}