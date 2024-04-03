using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Game
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }

        public Game()
        {
            Name = ConsoleManager.AddName();
            Condition = ConsoleManager.AddCondition();
            Price = ConsoleManager.AddPrice(Condition);
            Language = ConsoleManager.AddLanguage();
            Category = ConsoleManager.AddCategory();
            MinPlayers = ConsoleManager.AddMinPlayers();
            MaxPlayers = ConsoleManager.AddMaxPlayers();
        }
        public Game(string name, decimal price, string language, int minplayers, int maxplayers, string category, string condition) 
        {
            Name = name;
            Price = price;
            Language = language;
            MinPlayers = minplayers;
            MaxPlayers = maxplayers;
            Category = category;
            Condition = condition;
        }
    }
}
