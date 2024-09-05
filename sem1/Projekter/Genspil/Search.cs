namespace Genspil
{
    public static class Search
    {
        public static void PerformSearch(Stock stock)
        {
            List<Game> results = new List<Game>(); // Listen, som indeholder søgeresultaterne
            string searchQueryName = ConsoleManager.SearchPromptName();
            string searchQueryCategory = ConsoleManager.SearchPromptCategory();
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

                //Negative values
                bool isMinPriceNotMatch = searchQueryMinPrice == 0 || searchQueryMinPrice < game.Price; 
                bool isMaxPriceNotMatch = searchQueryMaxPrice == 0 || searchQueryMaxPrice > game.Price;
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
            }

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