using System;
internal class program
{
    private static void Main(string[] args)
    {
        bool active = true;
        Menu nyMenu = new Menu("Min fantastiske menu", 4);
        nyMenu.AddMenuItem("Gør dit");
        nyMenu.AddMenuItem("Gør dat");
        nyMenu.AddMenuItem("Gør noget");
        nyMenu.AddMenuItem("Få svaret på livet, universet og alting");

        while (active)
        {
            nyMenu.Show();
            try
            {
                int userChoice = int.Parse(Console.ReadLine());
                active = nyMenu.SelectMenuItem(userChoice);
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
        
    } 
}