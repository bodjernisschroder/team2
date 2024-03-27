using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class ReservationList
    {
        public List<KeyValuePair<Customer, Game>> reservations;

        public void Add(Customer customer, Game game)
        {
            reservations.Add(new KeyValuePair<Customer, Game>(customer, game));
        }

        // How to know which reservation to remove, without specifying customer?
        public void Remove(Customer customer, Game game)
        {
            if (reservations.Remove(new KeyValuePair<Customer, Game>(customer, game)))
            {
                Console.WriteLine("Reservation removed");
            }
            else
            {
                Console.WriteLine("Reservation failed to be removed");
            }
        }

        public void Show()
        {
            Console.WriteLine(reservations);
        }
    }
}