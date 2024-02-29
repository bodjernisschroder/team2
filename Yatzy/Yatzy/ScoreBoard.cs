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

        public void Create(int playerAmount, string[] playerNames)
        {
            //try
            //{
            grid = new object[18, playerAmount + 1];

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
            grid[16, 0] = "Yatzy Bonus";
            grid[17, 0] = "Sum";

            for (int i = 0; i = playerAmount; i++)
            {
                grid[0, i + 1] = playerNames[i]; // Assign player names correctly
            }
            //catch (FormatException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }

        public void SetScore(int cat, int score, int playerNumber)
        {
            grid[cat, playerNumber] = score;
        }

        public void SetBonus(int playerAmount)
        {
            for (int i = 1; i < playerAmount; i++)
            {
                if (Convert.ToInt32(grid[1,i]) + Convert.ToInt32(grid[2,i]) + Convert.ToInt32(grid[3,i]) + Convert.ToInt32(grid[4,i]) + Convert.ToInt32(grid[5,i]) + Convert.ToInt32(grid[6,i]) >= 63)
                    grid[15,i] = 50;
                else
                    grid[15,i] = 0;
            }
        }

        public void SetYatzyBonus(int playerAmount)
        {
            for (int i = 1; i < playerAmount; i++)
            {
                if (Convert.ToInt32(grid[15,i]) != 0)
                    grid[15,i] = Convert.ToInt32(grid[15,i]) + 100;
            }
        }

        public void Sum(int playerNumber)
        {
            int sum = 0;
            for (int i = 2; i < 17; i++)
            {
                sum += Convert.ToInt32(grid[i,playerNumber + 1]);
            }
            grid[17,playerNumber] = sum;
        }

        public void Show(int playerAmount)
        {

            for (int i = 0; i < 18; i++) //Rækker
            {
                for (int j = 0; j < playerAmount; j++) //Kolonner
                {
                    Console.Write(grid[i,j] + "\t");
                }
                //if (i == 0 || i == 6 || i == 14 || i == 16)
                //    Console.WriteLine("----------------------------------------------------------------------------------------");
                //else
                Console.WriteLine();
            }
        }
    }
}