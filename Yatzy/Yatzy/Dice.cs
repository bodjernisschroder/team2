﻿using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Yatzy
{
    internal class Dice
    {
        private static Random r = new Random();

        public static int Roll(int rollsLeft, string player)
        {
            int[] dice = new int[5];

            Console.Clear();
            Console.WriteLine();

            dice = RollAll(dice);
            rollsLeft--;

            for (int i = 0; i < rollsLeft; i++)
            {
                Console.Clear();
                Console.WriteLine(player);

                DisplayRollsAndCombinations(dice);
                Console.WriteLine("You have {0} roll(s) left.", rollsLeft);

                // Player chooses what dice to keep inbetween the 5 dice.
                Console.Write("Select dice to keep (1-5), Enter to roll all, or 0 to finish round: ");
                string userInput = Console.ReadLine();

                // If the player chooses no die, then all dice are rerolled.
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    dice = RollAll(dice);
                }
                // flet tjek om brugeren afslutter runden med A-N ind
                else if (int.Parse(userInput) == 0)
                {
                    break;
                }
                else
                {
                    // If the player chose any number of dice to keep, we go through each die.
                    // If the die does not exist in the user selection of dice to keep, the die will be rerolled.
                    for (int j = 0; j < dice.Length; j++)
                    {
                        if (!userInput.Contains((j + 1).ToString()))
                        {
                            dice[j] = RollDie();
                        }
                    }
                }
            }
            Console.WriteLine("{0}'s round ended.", player);

            return (rollsLeft);

            // Dette skal det ændres til, når vi har DisplayRolls...() til at returnere resultatet
            //result = DisplayRollsAndCombinations(dice);
            //return (rollsLeft, result);
        }

        // Ændret int[] position til Roll() og tager det nu som input i stedet
        private static int[] RollAll(int[] dice)
        {
            for (int i = 0; i < 5; i++)
            {
                dice[i] = RollDie();
            }
            return dice;
        }

        // Select ændret til RollDie
        private static int RollDie()
        {
            return r.Next(1, 7);
        }

        // Lav metode, der holder øje med om brugeren inputter A-N - afslut runde og returnér resultat og rolls
        // Og hvor den stopper op og venter på brugerens input før den går videre til næste bruger

        private static void DisplayRollsAndCombinations(int[] rolls)
        {
            Console.WriteLine("Your rolls: " + string.Join(", ", rolls));
            Console.WriteLine();
            Console.WriteLine("Roll again or pick an available combination to score:");
            Console.WriteLine();
            if (ones(rolls) > 0) Console.WriteLine($"A - 1's .................. sum = {ones(rolls)}");
            if (twos(rolls) > 0) Console.WriteLine($"B - 2's .................. sum = {twos(rolls)}");
            if (threes(rolls) > 0) Console.WriteLine($"C - 3's .................. sum = {threes(rolls)}");
            if (fours(rolls) > 0) Console.WriteLine($"D - 4's .................. sum = {fours(rolls)}");
            if (fives(rolls) > 0) Console.WriteLine($"E - 5's .................. sum = {fives(rolls)}");
            if (sixes(rolls) > 0) Console.WriteLine($"F - 6's .................. sum = {sixes(rolls)}");
            if (onePair(rolls) > 0) Console.WriteLine($"G - One Pair ............. sum = {onePair(rolls)}");
            if (twoPairs(rolls) > 0) Console.WriteLine($"H - Two Pairs ............ sum = {twoPairs(rolls)}");
            if (calcThreeOfAKind(rolls) > 0) Console.WriteLine($"I - Three-of-a-Kind ...... sum = {calcThreeOfAKind(rolls)}");
            if (calcFourOfAKind(rolls) > 0) Console.WriteLine($"J - Four-of-a-Kind ....... sum = {calcFourOfAKind(rolls)}");
            if (smallStraight(rolls)) Console.WriteLine("K - Small Straight ....... sum = 15");
            if (largeStraight(rolls)) Console.WriteLine("L - Large Straight ....... sum = 20");
            Console.WriteLine($"M - Chance ............... sum = {chance(rolls)}");
            if (yatzy(rolls)) Console.WriteLine($"N - YATZY! ............... sum = 50");
            Console.WriteLine();
        }

        private static int ones(int[] rolls)
        {
            int onesCount = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == 1)
                {
                    onesCount++;
                }
            }
            return onesCount;
        }
        private static int twos(int[] rolls)
        {
            int twosCount = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == 2)
                {
                    twosCount += 2;
                }
            }
            return twosCount;
        }
        private static int threes(int[] rolls)
        {
            int threesCount = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == 3)
                {
                    threesCount += 3;
                }
            }
            return threesCount;
        }
        private static int fours(int[] rolls)
        {
            int foursCount = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == 4)
                {
                    foursCount += 4;
                }
            }
            return foursCount;
        }
        private static int fives(int[] rolls)
        {
            int fivesCount = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == 5)
                {
                    fivesCount += 5;
                }
            }
            return fivesCount;
        }
        private static int sixes(int[] rolls)
        {
            int sixesCount = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == 6)
                {
                    sixesCount += 6;
                }
            }
            return sixesCount;
        }

        private static int onePair(int[] rolls)
        {
            var counts = new int[6];
            foreach (var roll in rolls)
            {
                counts[roll - 1]++;
            }

            int largestPairValue = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] >= 2)
                {
                    largestPairValue = Math.Max(largestPairValue, (i + 1) * 2);
                }
            }

            return largestPairValue;
        }

        private static int twoPairs(int[] rolls)
        {
            var counts = new int[6];
            foreach (var roll in rolls)
            {
                counts[roll - 1]++;
            }

            int firstPairValue = 0;
            int secondPairValue = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] >= 2)
                {
                    if (firstPairValue == 0)
                    {
                        firstPairValue = (i + 1) * 2;
                    }
                    else
                    {
                        secondPairValue = (i + 1) * 2;
                    }
                }
            }

            if (firstPairValue > 0 && secondPairValue > 0)
            {
                return firstPairValue + secondPairValue;
            }
            else
            {
                return 0;
            }
        }

        private static int calcThreeOfAKind(int[] rolls)
        {
            int[] sortArray = (int[])rolls.Clone();
            Array.Sort(sortArray);

            for (int i = 0; i < sortArray.Length - 2; i++)
            {
                if (sortArray[i] == sortArray[i + 1] && sortArray[i] == sortArray[i + 2])
                {
                    return sortArray[i] * 3;
                }
            }
            return 0;
        }
        private static int calcFourOfAKind(int[] rolls)
        {
            int[] sortArray = (int[])rolls.Clone();
            Array.Sort(sortArray);

            if ((sortArray[0] == sortArray[3]) || (sortArray[1] == sortArray[4]))
            {
                return sortArray[2] * 4;
            }
            return 0;
        }

        private static bool smallStraight(int[] rolls)
        {
            int[] sortArray = (int[])rolls.Clone();
            Array.Sort(sortArray);
            if (sortArray[0] == 1 && sortArray[1] == 2 && sortArray[2] == 3 && sortArray[3] == 4 && sortArray[4] == 5) return true;
            else return false;
        }

        private static bool largeStraight(int[] rolls)
        {
            int[] sortArray = (int[])rolls.Clone();
            Array.Sort(sortArray);
            if (sortArray[4] == 6 && sortArray[3] == 5 && sortArray[2] == 4 && sortArray[1] == 3 && sortArray[0] == 2) return true;
            else return false;
        }
        private static int chance(int[] rolls)
        {
            int chanceCount = 0;

            for (int i = 0; i < rolls.Length; i++)
            {
                chanceCount += rolls[i];
            }

            return chanceCount;
        }
        private static bool yatzy(int[] rolls)
        {
            var counts = new int[6];
            foreach (var roll in rolls)
            {
                counts[roll - 1]++;
            }

            return counts.Any(count => count >= 5);
        }

    }
}