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
            //upperSectionScores = new int[6]; // Kategorierne 1-6
            //lowerSectionScores = new int[7]; // Kategorierne 7-13
        }

        public void Create(int playerAmount, string[] playerNames)
        {
            object[][] grid = new object[17, playerAmount];

            grid[0][0] = "";
            grid[1][0] = "Ones";
            grid[2][0] = "Twos";
            grid[3][0] = "Threes";
            grid[4][0] = "Fours";
            grid[5][0] = "Fives";
            grid[6][0] = "Sixes";
            grid[7][0] = "One pair";
            grid[8][0] = "Two pairs";
            grid[9][0] = "Three of a kind";
            grid[10][0] = "Four of a kind";
            grid[11][0] = "Small straight";
            grid[12][0] = "Large straight";
            grid[13][0] = "Chance";
            grid[14][0] = "Yatzy";
            grid[15][0] = "Bonus";
            grid[16][0] = "Yatzy Bonus $$$";
            grid[17][0] = "Sum";

            for (int i = 0; i < playerAmount; i++)
            {
                grid[0][i+1] = playerName;
            }
            
        public void SetScore (int cat, int score, int playerNumber)
        {
            grid[cat, playerNumber] = score;
        }

        private void SetBonus()
        {
            if (grid[1][playerNumber] +
                grid[2][playerNumber] +
                grid[4][playerNumber] +
                grid[5][playerNumber] +
                grid[6][playerNumber] +
                grid[7][playerNumber]
                => 63)
                grid[15][playerNumber] = 50;
            else
                grid[15][playerNumber] = 0;
        }

        private void SetYatzyBonus()
        {
            if (grid[15][1] != 0) grid[15][1] += 100;
        }

        public void Sum(int playerNumber)
        {
            int sum = 0;
            for (i = 2; i < 17; i++)
            {
                sum += grid[i][playerNumber + 1];
            }
        }

        public void Show()
        {

            for (i = 0; i < 18; i++) //Rækker
            {
                for (int j = 0; j < playerAmount; j++) //Kolonner
                {
                        Console.Write(grid[i][j] + "\t");
                }
                if (i == 6)
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                else
                    Console.WriteLine();
                }
        }
        



        //Console.Write($"                            ""|{            }|{            }|{            }|{            }");
        //Console.Write($"----------------------------------------------------------------------------------------");
        //Console.Write($"{Category}                  ""|{cat1Score...}|{cat1Score...}|{cat1Score...}|{cat1Score...};");
        //Console.Write($"{Category}                  ""|{cat2Score...}|{cat2Score...}|{cat2Score...}|{cat2Score...};");
        //Console.Write($"{Category}                  ""|{cat3Score...}|{cat3Score...}|{cat3Score...}|{cat3Score...};");
        //Console.Write($"{Category}                  ""|{cat4Score...}|{cat4Score...}|{cat4Score...}|{cat4Score...};");
        //Console.Write($"{Category}                  ""|{cat5Score...}|{cat5Score...}|{cat5Score...}|{cat5Score...};");
        //Console.Write($"{Category}                  ""|{cat6Score...}|{cat6Score...}|{cat6Score...}|{cat6Score...};");
        //Console.Write($"{Category}                  ""|{cat7Score...}|{cat7Score...}|{cat7Score...}|{cat7Score...};");
        //Console.Write($"{Category}                  ""|{cat8Score...}|{cat8Score...}|{cat8Score...}|{cat8Score...};");
        //Console.Write($"{Category}                  ""|{cat9Score...}|{cat9Score...}|{cat9Score...}|{cat9Score...};");
        //Console.Write($"{Category}                  ""|{cat10Score..}|{cat10Score..}|{cat10Score..}|{cat10Score..};");
        //Console.Write($"{Category}                  ""|{cat11Score..}|{cat11Score..}|{cat11Score..}|{cat11Score..};");
        //Console.Write($"{Category}                  ""|{cat12Score..}|{cat12Score..}|{cat12Score..}|{cat12Score..};");
        //Console.Write($"{Category}                  ""|{cat13Score..}|{cat13Score..}|{cat13Score..}|{cat13Score..};");




            //public void SetUpperSectionScore(string category, int score, string playerName)
            //{
            //    upperSectionScores[category - 1] = score;  // Angiver scoren for de øverste kategorier 1-6
            //    score = sumOfLowerSection;
            //}

            //public void SetLowerSectionScore(int category, int score)
            //{
            //    lowerSectionScores[category - 7] = score; // Angiver scoren for de nederste kategorier 7-13. Scoren gemmes i indexet for de respektive arrays 
            //    score = sumOfUpperSection;
            //}


            // Selve "spillepladen" eller det scoreboard, som vises i konsolvinduet for den enkelte spiller.
            // Create() ændret til Show(), da det umiddelbart virker til, det er det den gør
            //public void Show()
            //{
            //             + playername + playername
            //    category + score + score
            //    category + score + score
            //    sum      + sumscore + sumscore

            //    (1,1) (1,2) (1,3)
            //    (2,1) (2,2)

            //    2,2 skal kende cat, score og playername
            //    1,2 skal kende playername
            //    2,1 skal kende cat


            //    (1,1)   (1,player)      (1,player)
            //    (cat,1) (cat,player)    (cat,player)
            //    (cat,1) (cat,player)    (cat,player)

            //    Console.WriteLine("Yatzy Scoreboard: ");

            //    foreach (x in row)
            //    {
            //        foreach (y in col)
            //    }

            //    foreach (List<int> row in grid)
            //    {
            //        foreach (int cell in row)
            //        {
            //            Console.Write(cell + " ");
            //        }
            //        Console.WriteLine();
            //    }




            /*When setPlayers method initialises, createScoreboard() with the right amount of players*/
            Console.WriteLine("Yatzy Scoreboard: ");
            Console.WriteLine("Upper section: ");
            for (int i = 0; i < upperSectionScores.Length; i++)
            {
                Console.WriteLine($"Category {i + 1}: {upperSectionScores[i]}");
            }

            // Her skal de individuelle scores skrives ind
            Console.WriteLine();
            Console.WriteLine("Lowersection: ");
            for (int i = 0; i < lowerSectionScores.Length; i++)
            {
                Console.WriteLine($"Category {i + 7}: {lowerSectionScores[i]}");
            }

            
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

           

            Console.WriteLine("Du har fået {0} i Yatzy-Bonus", yatzyBonus);
        }


        public void sumg() // Summen af spillernes point + bonus. 
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

    //Console.WriteLine("---------------");
    //        Console.WriteLine("7. Three of a kind");
    //        Console.WriteLine("8. Four of a kind");
    //        Console.WriteLine("9. Full house");
    //        Console.WriteLine("10. Small straight");
    //        Console.WriteLine("11. Large straight");
    //        Console.WriteLine("12. Yatzyyy");
    //        Console.WriteLine("13. Chance");
    //        Console.WriteLine("Yatzy Bonus $$$");

    //Console.WriteLine("---------------");
    //        Console.WriteLine("1. Ones");
    //        Console.WriteLine("2. Twos");
    //        Console.WriteLine("3. Threes");
    //        Console.WriteLine("4. Fours");
    //        Console.WriteLine("5. Fives");
    //        Console.WriteLine("6. Sixes");
    //        Console.WriteLine("Bonus");
}