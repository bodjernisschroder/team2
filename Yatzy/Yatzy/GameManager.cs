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
            for (i = 0; i < 15; i++)
            {
                for (int j = 0; j < players.Length; j++)
                {
                    PlayRound();
                    NextPlayer();
                }
            }
            End();
        }

        private void Start()
        {
            Console.Write("Time to play Yatzy - Choose Player Count (1-4): ");

            // Man tager input fra terminalen og omdanner det fra string til int, så vi kan bruge det i vores forloop.
            int playerCount = int.Parse(Console.ReadLine());

            // Vi laver et array hvor vi opretter et antal spillere der er angivet
            players = new Player[playerCount];
            playerNames = new string[playerCount];
            scoreBoard = new ScoreBoard();

            // Vi stater med i er 0, vi vil fortsætte indtil i er 1 mindre en playerCount,
            // og hver gang loopet gentages tilføjes 1 til i.
            for (int i = 0; i < playerCount; i++)
            {
                // Typen Player oprettes på plads i i array'et.
                players[i] = new Player();
                players[i].Create(i);
                playerNames[i] = playerArray[i].Name;
            }
            scoreBoard.Create(playerCount, playerNames);
            currentPlayer = players[0];
        }

        public void PlayRound()
        {
            currentPlayer.Rolls += 3;
            var result = Dice.Roll(currentPlayer.Rolls, currentPlayer.Name);
            currentPlayer.Rolls = result.rollsLeft;
            int cat = result.cat;
            int sum = result.sum;
            scoreBoard.SetScore(cat, score, currentPlayer.Number)
            scoreBoard.Sum(currentPlayer.Number);
            scoreBoard.Show();
        }

        public void NextPlayer()
        {
            currentPlayer = players[index++];
        }

        public void End()
        {
            scoreBoard.SetBonus();
            scoreBoard.SetYatzyBonus();
            Console.WriteLine("{ 0 } won with { 1 } points", currentPlayer.Name, currentPlayer.Points);
        }
    }
}