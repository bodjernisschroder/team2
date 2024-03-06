using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Yatzy
{
    class ScoreBoard
    {
        object?[,] grid;

        public void Create(string[] players)
        {
            grid = new object[18, players.Length + 1];

            grid[0, 0] = "";
            grid[1, 0] = "Ones";
            grid[2, 0] = "Twos";
            grid[3, 0] = "Threes";
            grid[4, 0] = "Fours";
            grid[5, 0] = "Fives";
            grid[6, 0] = "Sixes";
            grid[7, 0] = "One pair";
            grid[8, 0] = "Two pairs";
            grid[9, 0] = "Three of a kind";
            grid[10, 0] = "Four of a kind";
            grid[11, 0] = "Small straight";
            grid[12, 0] = "Large straight";
            grid[13, 0] = "Chance";
            grid[14, 0] = "Yatzy";
            grid[15, 0] = "Bonus";
            grid[16, 0] = "Sum";

            for (int i = 0; i < players.Length; i++)
            {
                grid[0, i+1] = players[i];
            }

            for (int i = 1; i < 17; i++)
            {
                for (int j = 1; j <= players.Length; j++)
                {
                    grid[i, j] = "";
                }
            }
        }

        public void SetScore(int cat, int score, int playerNumber)
        {
            grid[cat, playerNumber] = score;
        }

        public void SetBonus(int playerAmount)
        {
            for (int i = 1; i <= playerAmount; i++)
            {
                int topSum = Convert.ToInt32(grid[1, i]) + Convert.ToInt32(grid[2, i]) + Convert.ToInt32(grid[3, i]) + Convert.ToInt32(grid[4, i]) + Convert.ToInt32(grid[5, i]) + Convert.ToInt32(grid[6, i]);
                if (topSum >= 93)
                {
                    grid[15, i] = 100;
                }
                else if (topSum >= 63)
                    grid[15, i] = 50;
                else
                    grid[15,i] = 0;
            }
        }

        public void Sum(int playerNumber, int playerPoints)
        {
            grid[16, playerNumber] = playerPoints;
        }

        public void Show(int playerAmount)
        {

            for (int i = 0; i < 17; i++) //Rækker
            {
                for (int j = 0; j <= playerAmount; j++) //Kolonner
                {
                    if (j == 0)
                        Console.Write(PadObject(grid[i, j], 18));
                    else
                        Console.Write(PadObject(grid[i, j], 8));
                }
                Console.WriteLine();
            }
        }


        static string PadObject(object obj, int totalWidth)
        {
            string objString = obj.ToString();
            int padding = totalWidth - objString.Length; 
            if (padding > 0)
            {
                return objString + new string(' ', padding);
            }
            else
            {
                return objString;
            }
        }
    }
}