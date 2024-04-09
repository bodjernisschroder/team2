using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Game
    {
        private string _name;
        private decimal _price;
        private string _language;
        private int _minPlayers;
        private int _maxPlayers;
        private string _category;
        private string _condition;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == "") throw new Exception("Customer must have a name");
                _name = value;
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value >= 0) _price = value;
                else throw new ArgumentException("Price cannot be negative");
            }
        }
        public string Language
        {
            get { return _language; }
            set
            {
                if (value == "") _language = "N/A";
                else _language = value;
            }
        }
        public int MinPlayers
        {
            get { return _minPlayers; }
            set
            {
                if (value >= 0) _minPlayers = value;
                else throw new Exception("Minimum players cannot be negative");
            }
        }
        public int MaxPlayers
        {
            get { return _maxPlayers; }
            set
            {
                if (value >= 0) _maxPlayers = value;
                else throw new Exception("Maximum players cannot be negative");
            }
        }
        public string Category
        {
            get { return _category; }
            set
            {
                if (value == "") _category = "N/A";
                else _category = value;
            }
        }
        public string Condition
        {
            get { return _condition; }
            set
            {
                if (value == "") _condition = "N/A";
                else _condition = value;
            }
        }

        public Game()
        {
            Name = ConsoleManager.AddGameName();
            Condition = ConsoleManager.AddGameCondition();
            Price = ConsoleManager.AddGamePrice(Condition);
            Language = ConsoleManager.AddGameLanguage();
            Category = ConsoleManager.AddGameCategory();
            MinPlayers = ConsoleManager.AddGameMinPlayers();
            MaxPlayers = ConsoleManager.AddGameMaxPlayers();
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
