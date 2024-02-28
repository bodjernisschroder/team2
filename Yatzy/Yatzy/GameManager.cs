using System.Collections;
using System.Numerics;

namespace Yatzy
{
    internal class GameManager

    {
        int index = 0;
        Player currentPlayer;
        int roundCounter = 0;
        Player[] players;
        public void Run()
        {
            players = SetPlayers();
            while (roundCounter < 15)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    PlayRound();
                    NextPlayer();
                }
                roundCounter++;
            }
            End();
        }

        private Player[] SetPlayers()
        {

            Console.Write("Time to play Yatzy - Choose Player Count (1-4): ");

            // Man tager input fra terminalen og omdanner det fra string til int, så vi kan bruge det i vores forloop.
            int playerCount = int.Parse(Console.ReadLine());

            // Vi laver et array hvor vi opretter et antal spillere der er angivet
            Player[] playerArray = new Player[playerCount];


            // Vi stater med i er 0, vi vil fortsætte indtil i er 1 mindre en playerCount,
            // og hver gang loopet gentages tilføjes 1 til i.
            for (int i = 0; i < playerCount; i++)
            {
                // Typen Player oprettes på plads i i array'et.
                playerArray[i] = new Player();
                playerArray[i].Create(i);

            }
            currentPlayer = playerArray[0];
            return playerArray;
        }

        public void PlayRound()
        {
            int rollsLeft = currentPlayer.Rolls + 3;
            currentPlayer.Rolls = Dice.Roll(rollsLeft, currentPlayer.Name);
            //currentPlayer.ScoreBoard.SetField();
            //currentPlayer.ScoreBoard.Show();

            // Når Roll returnerer to værdier, brug nedenstående i stedet for ovenstående sidste 3 linjer
            //var result = Dice.Roll(rollsLeft);
            //currentPlayer.Rolls = result.Value1;
            //currentPlayer.ScoreBoard.SetField(result.Value2);
        }

        public void NextPlayer()
        {
            currentPlayer = players[index++];
        }

        public void End()
        {
            Console.WriteLine("{ 0 } won with { 1 } points", currentPlayer.Name, currentPlayer.Points);

        }
    }
}