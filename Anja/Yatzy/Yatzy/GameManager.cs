using System.Collections;

namespace Yatzy
{
    internal class GameManager

    {
        int index = 0;
        string currentPlayerName;
        int currentPlayerPoints;
        int roundCounter = 0;
        Player[] players;
        Dice dice;
        public void Run()
        {

            Start();
            while (roundCounter < 15)
            {
                for (int i = 0; i< players.Length; i++) 
                {
                    PlayRound();
                    NextPlayer();
                }
            }
            End();
            
        }

        private void Start()
        {
           players = SetPlayers();
           dice = new Dice()
        }
        private Player[] SetPlayers()
        {

            Console.Write("Time to play Yatzy - Choose Player Count (1-4): ");

            //man tar input fra terminalen og omdanner det fra string til int, så vi kan bruge det i vores forloop.
            int playerCount = int.Parse(Console.ReadLine()); 

            // vi laver et array hvor vi opretter et antal spillere der er angivet
            Player[] playerArray = new Player[playerCount];


            // vi stater med i er 0 vi vil fortsætte indtil i er 1 mindre en playcount
            // og hver gang loopet gentages tilføjes en til i.
            for (int i = 0; i<playerCount; i++ )
            {
                // der opretter men på pladsen typen player og bruger metoden Create til at definere den.  
                playerArray[i] = new Player();
                playerArray[i].Create();

            }
            currentPlayerName = players[index].GetPlayer();
            return playerArray;
        }

        public void PlayRound()
        {
            int rolls = players[index].GetRolls();

            for (int i = 0; i<rolls; i++)
            {
                dice.Roll();
                dice.Select();
            }

            players[index].SetStatus();
        }

        public void NextPlayer()
        {

            Console.WriteLine("{0}'s round ended.", currentPlayerName);
            index++;
            currentPlayerName = players[index].GetName();
            Console.WriteLine("it is now {0}'s turn.", currentPlayerName);


        }

        public void End()
        {
            Show();
            Console.WriteLine("player { 0 } won with { 1 } points", currentPlayerName, currentPlayerPoints);
            
        }
    }
}
