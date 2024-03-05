using System.Collections;
using System.Numerics;

namespace Yatzy
{
    internal class GameManager

    {
        int index = 0;
        Player currentPlayer;
        Player[] players;
        string[] playerNames;
        ScoreBoard scoreBoard;

        public void Run()
        {
            Start();
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < players.Length; j++)
                {
                    PlayRound();
                    NextPlayer();
                }
            }
            End();
        }

        public void Start()
        {
            Console.Write("Time to play Yatzy - Choose Player Count (2+): ");

            int playerCount = int.Parse(Console.ReadLine());

            players = new Player[playerCount];
            playerNames = new string[playerCount];
            scoreBoard = new ScoreBoard();

            for (int i = 0; i < playerCount; i++)
            {
                players[i] = new Player();
                players[i].Create(i);
                playerNames[i] = players[i].Name;
            }
            scoreBoard.Create(playerNames);
            currentPlayer = players[index];
            Console.Clear();
        }

        public void PlayRound()
        {
            scoreBoard.Show(players.Length);
            Console.WriteLine("\nCurrent player: " + currentPlayer.Name + "\n");
            currentPlayer.Rolls += 3;

            var result = Dice.Roll(currentPlayer.Rolls, currentPlayer.Name, currentPlayer.EmptyCats);
            Console.Clear();
            currentPlayer.Rolls = result.rollsLeft;
            int cat = result.cat;
            int sum = result.sum;
            currentPlayer.EmptyCats = currentPlayer.UpdateEmpty(cat);
            currentPlayer.Points += sum;
            scoreBoard.SetScore(cat, sum, currentPlayer.Number);
            scoreBoard.Sum(currentPlayer.Number, currentPlayer.Points);
            scoreBoard.Show(players.Length);
        }

        public void NextPlayer()
        {
            Console.WriteLine("\n{0}'s turn is over.\nPress Enter for the next player's turn.", currentPlayer.Name);
            Console.ReadLine();
            Console.Clear();
            if (index == players.Length - 1) index = 0;
            else index++;
            currentPlayer = players[index];
        }

        public void End()
        {
            Console.Clear();
            scoreBoard.SetBonus(players.Length);
            scoreBoard.Show(players.Length);
            Console.WriteLine("\n{0} won with {1} points!\n", currentPlayer.Name, currentPlayer.Points);
            Console.WriteLine("Press Enter to start a new game");
            string userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.Clear();
                Run();
            }
        }
    }
}