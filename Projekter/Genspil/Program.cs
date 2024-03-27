using Genspil;
using System;
internal class program
{
    private static void Main(string[] args)
    {

        bool active = true;
        Menu nyMenu = new Menu("   _____ ______ _   _  _____ _____ _____ _      \r\n  / ____|  ____| \\ | |/ ____|  __ \\_   _| |     \r\n | |  __| |__  |  \\| | (___ | |__) || | | |     \r\n | | |_ |  __| | . ` |\\___ \\|  ___/ | | | |     \r\n | |__| | |____| |\\  |____) | |    _| |_| |____ \r\n  \\_____|______|_| \\_|_____/|_|   |_____|______|", 5);
        nyMenu.AddMenuItem("Add Game");
        nyMenu.AddMenuItem("Search Stock");
        nyMenu.AddMenuItem("See Entire Stock");
        nyMenu.AddMenuItem("Create Reservation");
        nyMenu.AddMenuItem("???");

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