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

        public string scoreBoard;
        public string upperSection;
        public string lowerSection;
        public int[] upperSectionScores;
        public int[] lowerSectionScores;
        public int sumOfUpperSection;
        public int sumOfLowerSection;

        public ScoreBoard()
        {
            upperSectionScores = new int[6]; // Kategorierne 1-6
            lowerSectionScores = new int[7]; // Kategorierne 7-13
        }

        public void SetUpperSectionScore(int category, int score)
        {
            upperSectionScores[category - 1] = score;  // Angiver scoren for de øverste kategorier 1-6
            score = sumOfLowerSection;
        }

        public void SetLowerSectionScore(int category, int score)
        {
            lowerSectionScores[category - 7] = score; // Angiver scoren for de nederste kategorier 7-13. Scoren gemmes i indexet for de respektive arrays 
            score = sumOfUpperSection;
        }


        // Selve "spillepladen" eller det scoreboard, som vises i konsolvinduet for den enkelte spiller.
        // Create() ændret til Show(), da det umiddelbart virker til, det er det den gør
        public void Show()
        {
            /*When setPlayers method initialises, createScoreboard() with the right amount of players*/
            Console.WriteLine("Yatzy Scoreboard: ");
            Console.WriteLine("Upper section: ");
            for (int i = 0; i < upperSectionScores.Length; i++)
            {
                Console.WriteLine($"Category {i + 1}: {upperSectionScores[i]}");
            }

            Console.WriteLine("---------------");
            Console.WriteLine("1. Ones");
            Console.WriteLine("2. Twos");
            Console.WriteLine("3. Threes");
            Console.WriteLine("4. Fours");
            Console.WriteLine("5. Fives");
            Console.WriteLine("6. Sixes");
            Console.WriteLine("Bonus");


            // Her skal de individuelle scores skrives ind
            Console.WriteLine();
            Console.WriteLine("Lowersection: ");
            for (int i = 0; i < lowerSectionScores.Length; i++)
            {
                Console.WriteLine($"Category {i + 7}: {lowerSectionScores[i]}");
            }

            Console.WriteLine("---------------");
            Console.WriteLine("7. Three of a kind");
            Console.WriteLine("8. Four of a kind");
            Console.WriteLine("9. Full house");
            Console.WriteLine("10. Small straight");
            Console.WriteLine("11. Large straight");
            Console.WriteLine("12. Yatzyyy");
            Console.WriteLine("13. Chance");
            Console.WriteLine("Yatzy Bonus $$$");
        }

        // Tilføjet at tage en værdi, som enten kan være scratch eller en kombination.
        // Lige nu sat til int for at undgå fejl, men skal måske være en anden type.
        public void SetField(int choice)
        {
            //Get from setPlayers()
        }

        // Udkommenteret, da det eventuelt giver bedre mening at have den som en del af SetField()
        //public void ScratchField()
        //{
        //    /* When scratch call the method NextPlayer - Comment: Not necessary*/ 
        //    Console.WriteLine("#");
        //}

        // Overvej om denne er nødvendig, eftersom vi har SetField
        public void UpdateScoreboard()
        {
            /*Changes the score of the player after each turn - just before playerTurn*/

        }

        public void SetUpperBonus()
        {
            /* regnes sammen, og hvis er tilfældet, lægges oveni sum af*/
            if (sumOfUpperSection >= 63)
            {
                sumOfUpperSection = sumOfUpperSection + 35;
            }
        }

        public void SetYatzyBonus() // sætter Yatzy-bonus 
        {

            /* regnes sammen, og hvis er tilfældet, lægges oveni sum af*/
            int yatzyBonus = 0;

            switch (yatzyBonus)
            {
                case 1:
                    sumOfLowerSection += 100;
                    break;

                case 2:
                    sumOfLowerSection += 200;
                    break;
                case 3:
                    sumOfLowerSection += 300;
                    break;
            }

            Console.WriteLine("Du har fået {0} i Yatzy-Bonus", yatzyBonus);
        }


        public void sum() // Summen af spillernes point + bonus. 
        {
            int grandtotal = sumOfLowerSection + sumOfUpperSection;
        }
    }

    // Udkommenteret, da vi kalder den fra andre scripts i stedet.
    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            ScoreBoard scoreBoard = new ScoreBoard();
    //            scoreBoard.SetUpperSectionScore(1, 5); // Example score for Ones
    //            scoreBoard.SetUpperSectionScore(2, 10); // Example score for Twos
    //            scoreBoard.SetLowerSectionScore(7, 20); // Example score for Three of a Kind
    //            scoreBoard.createScoreboard();

    //            Console.ReadLine();
    //        }
    //    }
}