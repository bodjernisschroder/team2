namespace Genspil
{
    public class Menu
    {
        public string title;
        private MenuItem[] menuItems;
        private int itemCount = 0;
        int gameID;

        Stock stock = new Stock("stock.txt");
        Reservations reservations = new Reservations("reservations.txt");

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
                    stock.Save();
                    reservations.Save();
                    ConsoleManager.Exit();
                    return false;
                case 1:
                    stock.Show();

                    break;
                case 2:
                    stock.AddGame();
                    break;
                case 3:
                    gameID = ConsoleManager.SelectGameToModify(stock.list);
                    ConsoleManager.ModifyGameFromStock(stock.list[gameID]);
                    break;
                case 4:
                    stock.RemoveGame();
                    break;
                case 5:
                    reservations.Show();
                    break;
                case 6:
                    gameID = reservations.AddReservation(stock.list);
                    stock.MoveGameToReservations(gameID);
                    break;
                case 7:
                    gameID = ConsoleManager.SelectReservationToModify(reservations.list);
                    ConsoleManager.ModifyReservation(reservations.list[gameID]);
                    break;
                case 8:
                    KeyValuePair<Customer, Game> reservation = reservations.MoveGameToStock();
                    stock.MoveGameFromReservations(reservation.Value);
                    reservations.RemoveReservation(reservation);
                    break;
                case 9:
                    stock.SortByName();
                    break;
                case 10:
                    stock.SortByCategory();
                    break;
                case 11:
                    Search.PerformSearch(stock);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            ConsoleManager.EndOfCase();
            return true;
        }
    }
}