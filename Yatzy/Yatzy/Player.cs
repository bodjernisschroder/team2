using System;

namespace Yatzy
{
    class Player
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        public void Create(int i)
        {
            Console.Write("Name of player {0}: ", (i+1));
            Name = Console.ReadLine();
            ScoreBoard scoreBoard = new ScoreBoard();
        }

        //public void ShowScoreBoard()
        //{
        //    scoreBoard.Show();
        //}
        public string Name { get; set; }
        public int Rolls { get; set; }

        public int Points { get; set; }
        public ScoreBoard ScoreBoard { get; set;}
    }
}