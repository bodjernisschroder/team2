using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;

namespace Genspil
{
    public class Stock
    {
        public List<Game> list = new List<Game>();
        public string stockFile;

        public Stock(string file)
        {
            stockFile = file;
            if (!File.Exists(stockFile)) File.Create(stockFile).Close();
            Load();
        }

        public void Save()
        {
            using (StreamWriter outputFile = new StreamWriter(stockFile))
            {
                foreach ( Game game in list )
                {
                    string gameString = game.Name + ";" + game.Price + ";" + game.Language + ";" + game.MinPlayers + ";" + game.MaxPlayers + ";" + game.Category + ";" + game.Condition + "\n";
                    outputFile.Write(gameString);
                }
            }
        }

        public void Load()
        {
            List<string> gameDetails = new List<string>();
            string line;

            using (StreamReader inputFile = new StreamReader(stockFile))
            {
                while ((line = inputFile.ReadLine()) != null)
                {
                    gameDetails = line.Split(";").ToList();
                    Game game = new Game(gameDetails[0], decimal.Parse(gameDetails[1]), gameDetails[2], int.Parse(gameDetails[3]), int.Parse(gameDetails[4]), gameDetails[5], gameDetails[6]);
                    list.Add(game);
                }
            }
        }

        public void AddGame()
        {
            Game game = new Game();

            list.Add(game);

            ConsoleManager.GameAdded(game);
        }

        public void RemoveGame()
        {
            int gameID = ConsoleManager.RemoveGame(list);
            ConsoleManager.GameRemoved(list[gameID]);
            list.Remove(list[gameID]);
        }

        public void MoveGameToReservations(int gameID)
        {
            list.Remove(list[gameID]);
        }

        public void MoveGameFromReservations(Game game)
        {
            list.Add(game);
        }

        public void Show()
        {
            for (int i = 0; i < list.Count; i++)
            {
                ConsoleManager.ShowGameOnly(list[i], i);
            }
        }

        public void SortByName()
        {
            list.Sort((game1, game2) => game1.Name.CompareTo(game2.Name));
            Show();
        }

        public void SortByCategory()
        {
            // I List.Sort er der indbygget, at den er i stand til løbende at tage
            // to elementer fra listen og sammenligne dem. Derfor kender den automatisk
            // game1 og game2 og sørger for at iterere over dem, indtil den er igennem listen
            list.Sort((game1, game2) => game1.Category.CompareTo(game2.Category));
            Show();
        }
    }
}

//namespace Genspil
//{
//    internal class Stock
//    {
//        public List<Game> stock = new List<Game>();

//        public void Add(Game game)
//        {
//            // Add er en indbygget metode i List<T>
//            stock.Add(game);
//        }

//        public string Remove(int i)
//        {
//            string gameName = stock[i - 1].Name;

//            // Remove er en indbygget metode i List<T>
//            stock.Remove(stock[i - 1]);

//            return gameName;
//        }

//        public void Show()
//        {
//            // Her skal vi beslutte, om vi vil vise flere oplysninger end navnet.
//            // F.eks. navn, stand og pris, eller alt.
//            for (int i = 0; i < stock.Count; i++)
//            {
//                Console.WriteLine((i + 1) + " " + stock[i].Name + " " + stock[i].Category + "\n");
//            }
//        }

//        public void SortByName()
//        {
//            // Samme som ved Category
//            stock.Sort((game1, game2) => game1.Name.CompareTo(game2.Name));
//        }

//        public void SortByCategory()
//        {
//            // I List.Sort er der indbygget, at den er i stand til løbende at tage
//            // to elementer fra listen og sammenligne dem. Derfor kender den automatisk
//            // game1 og game2 og sørger for at iterere over dem, indtil den er igennem listen
//            stock.Sort((game1, game2) => game1.Category.CompareTo(game2.Category));
//        }
//    }
//}

