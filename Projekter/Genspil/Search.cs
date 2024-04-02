using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Search
    {
        public List<Game> Search(string searchQuery)
        {
            CurrentGames(game); // Placeholder for den liste, jeg brugte til test
            List<Game> results = new List<Game>(); // Listen, som indeholder søgeresultaterne

            // Går igennem alle spil i listen med spil
            foreach (Game game in stock)
            {

                // Tjekker om vores søgning matcher med enten navn, kategori eller stand
                if (game.Name.ToLower().Contains(searchQuery.ToLower()) ||
                    game.Category.ToLower().Contains(searchQuery.ToLower()) ||
                    game.Condition.ToLower().Contains(searchQuery.ToLower()))
                {

                    // Hvis der er et match, bliver spillene tilføjet til listen med søgeresultater
                    results.Add(game);
                }
            }

            // Returnerer listen med søgeresultater
            return results;
        }



        public void StartSearch()
        {
            // Spørger brugeren om input til søgningen, som gemmes i en string, der hedder searchQuery
            Console.Write("Please enter game name, category, or condition: ");
            string searchQuery = Console.ReadLine();

            // Foretager selve søgningen via search metoden
            List<Game> results = Search(searchQuery);


            // Printer søgeresulaterne 
            if (results.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (Game result in results)
                {
                    // Printer detaljer fra spillene
                    Console.WriteLine($"Name: {result.Name}, Category: {result.Category}, Condition: {result.Condition}");
                }
            }
            else
            {
                Console.WriteLine("No results found. Try again");
            }
        }

    }
}
