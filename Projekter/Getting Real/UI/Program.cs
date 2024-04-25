using GettingReal;
using System;
internal class program
{
    private static void Main(string[] args)
    {
        bool active = true;
        Menu nyMenu = new Menu("\r  ____        _     _ _           \r\n |  _ \\ _   _| |__ | (_) ___ ___  \r\n | |_) | | | | '_ \\| | |/ __/ _ \\ \r\n |  __/| |_| | |_) | | | (_| (_) |\r\n |_|    \\__,_|_.__/|_|_|\\___\\___/ \r\n", 4);
        nyMenu.AddMenuItem("Opret nyt tilbud");
        nyMenu.AddMenuItem("Se og rediger aktive tilbud");
        nyMenu.AddMenuItem("Opret og rediger ydelser");
        nyMenu.AddMenuItem("Luk program");

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