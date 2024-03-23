﻿using System;
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
        public int Condition { get; set; }

        public Game(string name, decimal price, string language, int minplayers, int maxplayers, string category, int condition) 
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