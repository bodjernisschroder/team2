using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Stock
    {
        public List<Game> stock = new List<Game>();

        public void Add(Game game)
        {
            // Add er en indbygget metode i List<T>
            stock.Add(game);
        }

        public string Remove(int i) 
        {
            string gameName = stock[i-1].Name;

            // Remove er en indbygget metode i List<T>
            stock.Remove(stock[i-1]);

            return gameName;
        }

        public void Show() 
        {
            // Her skal vi beslutte, om vi vil vise flere oplysninger end navnet.
            // F.eks. navn, stand og pris, eller alt.
            for (int i = 0; i < stock.Count; i++)
            {
                Console.WriteLine((i+1) + " " + stock[i].Name + " " + stock[i].Category + "\n");
            }
        }

        public void SortByName()
        {
            // Samme som ved Category
            stock.Sort((game1, game2) => game1.Name.CompareTo(game2.Name));
        }

        public void SortByCategory()
        {
            // I List.Sort er der indbygget, at den er i stand til løbende at tage
            // to elementer fra listen og sammenligne dem. Derfor kender den automatisk
            // game1 og game2 og sørger for at iterere over dem, indtil den er igennem listen
            stock.Sort((game1, game2) => game1.Category.CompareTo(game2.Category));
        }
    }
}
