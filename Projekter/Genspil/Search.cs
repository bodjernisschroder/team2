// Search

using Genspil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public static class Search
    {

        public static void PerformSearch(Stock stock)
        {
            List<Game> results = new List<Game>(); // Listen, som indeholder søgeresultaterne
            List<KeyValuePair<string, string>> searchList = new List<KeyValuePair<string, string>>();

            foreach (Game game in stock.list)
            {
                string searchQueryName = ConsoleManager.SearchPromptName();
                if (searchQueryName != null)
                {
                    KeyValuePair<string, string> searchPair = new KeyValuePair<string, string>(game.Name, searchQueryName);
                    searchList.Add(searchPair);
                }
                // Tilføj tjek for alle typer, men lav om til string, dvs. også return string i ConsoleManager
                //string searchQueryCategory = ConsoleManager.SearchPromptCategory();
                //decimal searchQueryMinPrice = ConsoleManager.SearchPromptMinPrice();
                //decimal searchQueryMaxPrice = ConsoleManager.SearchPromptMaxPrice();
                //int searchQueryPlayers = ConsoleManager.SearchPromptPlayers();
            }

            // Omdan strings til decimaler og int, hvor de skal
            // results = searchList som Game elementer i stedet for KeyValuePair, ved at bruge Contains med for i, results[i].Contains(searchList.Key)

            searchList = MakeSearch(searchList);
        }

        public static List<KeyValuePair<string, string>> MakeSearch(List<KeyValuePair<string, string>> searchList)
        {
            for (int i = 0; i < searchList.Count; i++)
            {
                if (!searchList[i].Key.ToLower().Contains(searchList[i].Value.ToLower())) searchList.Remove(searchList[i]);
            }
            return searchList;
        }
    }
}

        // Noter

        //string searchQueryCondition = ConsoleManager.SearchPromptCondition();

        // List efter name search
        // Pair: Catan, catan

        // List efter price search
        // Pair: Sequence, 50

        // List Remove
        // if Catan != catan
        // if Catan != 50, Remove
        // if Sequence != catan, Remove

        // Til sidst har vi kun alle dem, der passer til ALLE kriterier



        ///////////////////////////////////

            //// Går igennem alle spil i listen med spil


            ////Alle kriterier
            //foreach (Game game in stock.list)
            //{
            //    // Tjekker om vores søgning matcher med navn
            //    if (game.Name.ToLower().Contains(searchQueryName.ToLower()) && 
            //        game.Category.ToLower().Contains(searchQueryCategory.ToLower()) &&
            //        game.Condition.ToLower().Contains(searchQueryCondition.ToLower()) &&
            //        game.Price >= searchQueryMinPrice && game.Price <= searchQueryMaxPrice &&
            //        searchQueryPlayers >= game.MinPlayers && searchQueryPlayers <= game.MaxPlayers)
            //    {
            //        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
            //        results.Add(game);

            //    }
            //    else if (searchQueryName == "")
            //        break;

            //}

            //    //Name 
            //    foreach (Game game in stock.list)
            //    {
            //        // Tjekker om vores søgning matcher med navn
            //        if (game.Name.ToLower().Contains(searchQueryName.ToLower()) ||


            //                    {
            //            // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
            //            results.Add(game);

            //        }
            //        else if (searchQueryName = "")
            //            break;

            //    }

//if (game.Name.ToLower().Contains(searchQueryName.ToLower())) results.Add(game);
            //List<KeyValuePair<List<string>, List<string>>> searchList = new List<KeyValuePair<List<string>, List<string>>>();


////Category 
//foreach (Game game in stock.list)
//{
//    // Tjekker om vores søgning matcher med kategori
//    if (game.Category.ToLower().Contains(searchQueryCategory.ToLower()))


//    {
//        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
//        results.Add(game);

//    }
//    else if (searchQueryCategory == "")
//        break;
//}

//Condition 
//foreach (Game game in stock.list)
//{
//    // Tjekker om vores søgning matcher med enten navn, kategori eller stand
//    if (game.Condition.ToLower().Contains(searchQueryCondition.ToLower()) ||


//    {
//        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
//        results.Add(game);

//    }
//    else if (searchQueryCondition = "")
//        break;
//}

//Price
//foreach (Game game in stock.list)
//{
//    // Tjekker om vores søgning matcher med det prisinterval, som brugeren har angivet
//    if (game.Price >= searchQueryMinPrice && game.Price <= searchQueryMaxPrice)

//    {
//        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
//        results.Add(game);

//    }
//    else if (searchQueryMinPrice == null || searchQueryMaxPrice == null)
//        break;
//}

////Number of players
//foreach (Game game in stock.list)
//{
//    // Tjekker om vores søgning matcher med det spillerinterval, som brugeren har angivet 
//    if (searchQueryPlayers >= game.MinPlayers && searchQueryPlayers <= game.MaxPlayers)

//    {
//        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
//        results.Add(game);

//    }
//    else if (searchQueryPlayers == 0)
//        break;
//}



// Printer søgeresulaterne 
//if (results.Count > 0)
//            {
//                ConsoleManager.SearchResults();
//                for (int i = 0; i < results.Count; i++)
//                {
//                    ConsoleManager.ShowGameOnly(results[i], i);
//                }
//            }
//            else
//            {
//                Console.WriteLine("No results found. Try again");
//            }
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Genspil
//{
//    public class Search
//    {
//        public List<Game> Search(string searchQuery)
//        {
//            CurrentGames(game); // Placeholder for den liste, jeg brugte til test
//            List<Game> results = new List<Game>(); // Listen, som indeholder søgeresultaterne

//            // Går igennem alle spil i listen med spil
//            foreach (Game game in stock)
//            {

//                // Tjekker om vores søgning matcher med enten navn, kategori eller stand
//                if (game.Name.ToLower().Contains(searchQuery.ToLower()) ||
//                    game.Category.ToLower().Contains(searchQuery.ToLower()) ||
//                    game.Condition.ToLower().Contains(searchQuery.ToLower()))
//                {

//                    // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
//                    results.Add(game);
//                }
//            }

//            // Returnerer listen med søgeresultater
//            return results;
//        }



//        public void StartSearch()
//        {
//            // Spørger brugeren om input til søgningen, som gemmes i en string, der hedder searchQuery
//            Console.Write("Please enter game name, category, or condition: ");
//            string searchQuery = Console.ReadLine();

//            // Foretager selve søgningen via search metoden
//            List<Game> results = Search(searchQuery);


//            // Printer søgeresulaterne 
//            if (results.Count > 0)
//            {
//                Console.WriteLine("Search Results:");
//                foreach (Game result in results)
//                {
//                    // Printer detaljer fra spillene
//                    Console.WriteLine($"Name: {result.Name}, Category: {result.Category}, Condition: {result.Condition}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No results found. Try again");
//            }
//        }

//    }
//}
