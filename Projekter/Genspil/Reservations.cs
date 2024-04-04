using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Reservations
    {
        public List<KeyValuePair<Customer, Game>> list = new List<KeyValuePair<Customer, Game>>();
        public string reservationsFile;

        public Reservations(string file)
        {
            reservationsFile = file;
            if (!File.Exists(reservationsFile)) File.Create(reservationsFile).Close();
            Load();
        }

        public void Save()
        {
            using (StreamWriter outputFile = new StreamWriter(reservationsFile))
            {
                foreach (KeyValuePair<Customer, Game> reservation in list)
                {
                    Customer c = reservation.Key;
                    Game g = reservation.Value;
                    string reservationString = c.Name + ";" + c.Email + ";" + c.PhoneNumber + ":" + g.Name + ";" + g.Price + ";" + g.Language + ";" + g.MinPlayers + ";" + g.MaxPlayers + ";" + g.Category + ";" + g.Condition + "\n";
                    outputFile.Write(reservationString);
                }
            }
        }
        public void Load()
        {
            string line;
            List<string> pair;
            List<string> customerDetails;
            List<string> gameDetails;

            using (StreamReader inputFile = new StreamReader(reservationsFile))
            {
                while ((line = inputFile.ReadLine()) != null)
                {
                    pair = line.Split(":").ToList();
                    customerDetails = pair[0].Split(";").ToList();
                    gameDetails = pair[1].Split(";").ToList();
                    Customer customer = new Customer(customerDetails[0], customerDetails[1], customerDetails[2]);
                    Game game = new Game(gameDetails[0], decimal.Parse(gameDetails[1]), gameDetails[2], int.Parse(gameDetails[3]), int.Parse(gameDetails[4]), gameDetails[5], gameDetails[5]);
                    list.Add(new KeyValuePair<Customer, Game>(customer, game));
                }
            }
        }

        public int AddReservation(List<Game> stock)
        {
            Customer customer = new Customer();
            int gameID = ConsoleManager.ReserveGame(stock);
            KeyValuePair<Customer,Game> reservation = new KeyValuePair<Customer, Game>(customer, stock[gameID]);
            list.Add(reservation);
            ConsoleManager.ReservationAdded(customer, stock[gameID]);
            return gameID;
        }

        public void RemoveReservation(KeyValuePair<Customer, Game> reservation)
        {
            if (list.Remove(reservation))
            {
                ConsoleManager.ReservationRemoved(reservation.Key, reservation.Value);
            }
            else
            {
                Console.WriteLine("Reservation failed to be removed");
            }
        }

        public KeyValuePair<Customer,Game> MoveGameToStock()
        {
            int reservationID = ConsoleManager.RemoveReservedGame(list);
            return list[reservationID];
        }

        public void Show()
        {
            foreach (KeyValuePair<Customer, Game> reservation in list)
            {
                ConsoleManager.ShowReservationOnly(reservation.Key, reservation.Value);
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Genspil
//{
//    internal class ReservationList
//    {
//        public List<KeyValuePair<Customer, Game>> reservations;

//        public void Add(Customer customer, Game game)
//        {
//            reservations.Add(new KeyValuePair<Customer, Game>(customer, game));
//        }

//        // How to know which reservation to remove, without specifying customer?
//        public void Remove(Customer customer, Game game)
//        {
//            if (reservations.Remove(new KeyValuePair<Customer, Game>(customer, game)))
//            {
//                Console.WriteLine("Reservation removed");
//            }
//            else
//            {
//                Console.WriteLine("Reservation failed to be removed");
//            }
//        }

//        public void Show()
//        {
//            Console.WriteLine(reservations);
//        }
//    }
//}