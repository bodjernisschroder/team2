// Search

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public static class Search
    {
        public static void PerformSearch(Stock stock)
        {
            List<Game> results = new List<Game>(); // Listen, som indeholder søgeresultaterne
            string searchQueryName = ConsoleManager.SearchPromptName();
            string searchQueryCategory = ConsoleManager.SearchPromptCategory();
            //string searchQueryCondition = ConsoleManager.SearchPromptCondition();
            decimal searchQueryMinPrice = ConsoleManager.SearchPromptMinPrice();
            decimal searchQueryMaxPrice = ConsoleManager.SearchPromptMaxPrice();
            int searchQueryPlayers = ConsoleManager.SearchPromptPlayers();


            
            // Går igennem alle spil i listen med spil 
            foreach (Game game in stock.list)
            {
                //Positive values
                bool isNameMatch = game.Name.ToLower().Contains(searchQueryName.ToLower());
                bool isCategoryMatch = game.Category.ToLower().Contains(searchQueryCategory.ToLower());
                bool isPriceMatch = game.Price >= searchQueryMinPrice && game.Price <= searchQueryMaxPrice;
                bool isPlayersMatch = searchQueryPlayers >= game.MinPlayers && searchQueryPlayers <= game.MaxPlayers;
                //bool isPlayersMatch = game.MinPlayers >= searchQueryPlayers && game.MaxPlayers <= searchQueryPlayers;

                //Negative values
                bool isMinPriceNotMatch = searchQueryMinPrice == 0 || searchQueryMinPrice < game.Price; 
                bool isMaxPriceNotMatch = searchQueryMaxPrice == 0 || searchQueryMaxPrice > game.Price;
                //bool isMinPlayersNotMatch = searchQueryPlayers == 0 || searchQueryPlayers < game.MinPlayers;
                //bool isMaxPlayersNotMatch = searchQueryPlayers == 0 || searchQueryPlayers > game.MaxPlayers;
                bool isMinPlayersNotMatch = game.MinPlayers < searchQueryPlayers || game.MinPlayers == 0;
                bool isMaxPlayersNotMatch = game.MaxPlayers > searchQueryPlayers || game.MaxPlayers == 0;


                bool isNameNotMatch = string.IsNullOrEmpty(game.Name);
                bool isCategoryNotMatch = string.IsNullOrEmpty(game.Category);
                


                //Alle kombinationer - Ikke den mest effektive måde, men det virker :)
                if (isNameMatch && isCategoryMatch && isPriceMatch && isPlayersMatch) //15
                {
                    results.Add(game);
                }
                else if (isCategoryMatch && isPriceMatch && isPlayersMatch && isNameNotMatch) //14
                {
                    results.Add(game);
                }
                else if (isNameMatch && isPriceMatch && isPlayersMatch && isCategoryNotMatch) //13
                {
                    results.Add(game);
                }
                else if (isNameMatch && isCategoryMatch && isPlayersMatch && isMinPriceNotMatch && isMaxPriceNotMatch) //12
                {
                    results.Add(game);
                }
                else if (isNameMatch && isCategoryMatch && isPriceMatch && isMinPriceNotMatch && isMaxPriceNotMatch) //11
                {
                    results.Add(game);
                }
                else if (isPriceMatch && isPlayersMatch && isNameNotMatch && isCategoryNotMatch) //10
                {
                    results.Add(game);
                }
                else if (isCategoryMatch && isPlayersMatch && isNameNotMatch && isMinPriceNotMatch && isMaxPriceNotMatch) //9
                {
                    results.Add(game);
                }
                else if (isCategoryMatch && isPriceMatch && isNameNotMatch && isMinPlayersNotMatch && isMaxPlayersNotMatch) //8
                {
                    results.Add(game);
                }
                else if (isNameMatch && isPlayersMatch && isCategoryNotMatch && isMinPriceNotMatch && isMaxPriceNotMatch) //7
                {
                    results.Add(game);
                }
                else if (isNameMatch && isPriceMatch && isCategoryNotMatch && isMinPlayersNotMatch && isMaxPlayersNotMatch) //6
                {
                    results.Add(game);
                }
                else if (isNameMatch && isCategoryMatch && isMinPriceNotMatch && isMaxPriceNotMatch && isMinPlayersNotMatch && isMaxPlayersNotMatch) //5 
                {
                    results.Add(game);
                }
                else if (isPlayersMatch && isCategoryNotMatch && isNameNotMatch && isMinPriceNotMatch && isMaxPlayersNotMatch) //4
                {
                    results.Add(game);
                }
                else if (isPriceMatch && isNameNotMatch && isCategoryNotMatch && isMinPlayersNotMatch && isMaxPlayersNotMatch) //3
                {
                    results.Add(game);
                }
                else if (isCategoryMatch && isNameNotMatch && isMinPlayersNotMatch && isMaxPlayersNotMatch && isMinPlayersNotMatch && isMaxPlayersNotMatch) //2
                {
                    results.Add(game);
                }

                else if (isNameMatch && isMinPriceNotMatch && isMaxPriceNotMatch && isMinPlayersNotMatch && isMaxPlayersNotMatch && isCategoryNotMatch) //1
                {
                    results.Add(game);
                }




                //if (game.Name.ToLower().Contains(searchQueryName.ToLower()) || isNameNotMatch &&
                //    game.Category.ToLower().Contains(searchQueryCategory.ToLower()) || isCategoryNotMatch &&
                //    game.Price >= searchQueryMinPrice && game.Price <= searchQueryMaxPrice || isPriceNotMatch &&
                //    searchQueryPlayers >= game.MinPlayers && searchQueryPlayers <= game.MaxPlayers || isPlayersNotMatch)

                //{
                //    results.Add(game);

                //}



            }

            ////Category 
            //foreach (Game game in stock.list)
            //{
            //    // Tjekker om vores søgning matcher med kategori
            //    if (game.Category.ToLower().Contains(searchQueryCategory.ToLower()))


            //    {
            //        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
                   

            //    }
            //    else if (searchQueryCategory == "")
            //        break;
            //}

            //////Condition 
            ////foreach (Game game in stock.list)
            ////{
            ////    // Tjekker om vores søgning matcher med enten navn, kategori eller stand
            ////    if (game.Condition.ToLower().Contains(searchQueryCondition.ToLower()))


            ////    {
            ////        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
            ////        results.Add(game);

            ////    }
            ////    //else if (searchQueryCondition == "")
            ////    //    break;
            ////}

            ////Price
            //foreach (Game game in stock.list)
            //{
            //    // Tjekker om vores søgning matcher med det prisinterval, som brugeren har angivet
            //    if (game.Price >= searchQueryMinPrice && game.Price <= searchQueryMaxPrice)

            //    {
            //        // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
            //        results.Add(game);

            //    }
            //    else if (searchQueryMinPrice == 0 || searchQueryMaxPrice == 0)
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
            if (results.Count > 0)
            {
                ConsoleManager.SearchResults();
                for (int i = 0; i < results.Count; i++)
                {
                    ConsoleManager.ShowGameOnly(results[i], i);
                }
            }
            else
            {
                Console.WriteLine("No results found. Try again");
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
