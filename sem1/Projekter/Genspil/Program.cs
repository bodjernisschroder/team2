namespace Genspil
{
    internal class program
    {
        private static void Main(string[] args)
        {
            bool active = true;
            Menu nyMenu = new Menu("   _____ ______ _   _  _____ _____ _____ _      \r\n  / ____|  ____| \\ | |/ ____|  __ \\_   _| |     \r\n | |  __| |__  |  \\| | (___ | |__) || | | |     \r\n | | |_ |  __| | . ` |\\___ \\|  ___/ | | | |     \r\n | |__| | |____| |\\  |____) | |    _| |_| |____ \r\n  \\_____|______|_| \\_|_____/|_|   |_____|______|", 11);
            nyMenu.AddMenuItem("Print Entire Stock");
            nyMenu.AddMenuItem("Add Game To Stock");
            nyMenu.AddMenuItem("Modify Game");
            nyMenu.AddMenuItem("Remove Game From Stock");
            nyMenu.AddMenuItem("Show Reserved Games");
            nyMenu.AddMenuItem("Add Reservation");
            nyMenu.AddMenuItem("Modify Reservation");
            nyMenu.AddMenuItem("Remove Reservation");
            nyMenu.AddMenuItem("Sort Stock By Name");
            nyMenu.AddMenuItem("Sort Stock By Category");
            nyMenu.AddMenuItem("Search Stock");

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
}