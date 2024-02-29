using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Yatzy
{
    internal class Dice
    {
        public static Random r = new Random();
        string str = "ABCDEFGHIJKLMN";

        public static (int rollsLeft, int cat, int sum) Roll(int rollsLeft, string player)
        {
            int[] dice = new int[5];

            //Console.Clear();
            Console.WriteLine();

            dice = RollAll(dice);
            rollsLeft--;
            int counter = rollsLeft;

            for (int i = 0; i < counter; i++)
            {
                //Console.Clear();

                Console.WriteLine("You have {0} roll(s) left.\n", rollsLeft);
                DisplayRollsAndCombinations(dice);
                // Player chooses what dice to keep inbetween the 5 dice.
                Console.Write("Select dice to keep (1-5), Enter to roll all, or pick a combo from A-N: ");
                string userInput = Console.ReadLine();

                // If the player chooses no die, then all dice are rerolled.
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    dice = RollAll(dice);
                }
                //else if (userInput.Contains())
                //{
                //    //string brugerinput = Console.ReadLine().ToUpper();

                //    var comboResult = pickCombo(brugerinput, dice);

                //    Console.WriteLine("Dit svar er gemt! Tryk enter for næste spillers tur.");
                //    Console.ReadLine();
                //}
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
                rollsLeft--;
            }
            //Console.Clear();
            //Console.WriteLine("Current player: " + player + "\n");
            DisplayRollsAndCombinations(dice);
            Console.WriteLine("Please select A-N to score or scratch a combination.");
            string brugerinput = Console.ReadLine().ToUpper();

            var comboResult = pickCombo(brugerinput, dice);

            Console.WriteLine("Dit svar er gemt! Tryk enter for næste spillers tur.");
            Console.ReadLine();

            return (rollsLeft, comboResult.comboCategory, comboResult.sum);
        }

        // Ændret int[] position til Roll() og tager det nu som input i stedet
        public static int[] RollAll(int[] dice)
        {
            for (int i = 0; i < 5; i++)
            {
                dice[i] = RollDie();
            }
            return dice;
        }

        // Select ændret til RollDie
        public static int RollDie()
        {
            return r.Next(1, 7);
        }

        // Lav metode, der holder øje med om brugeren inputter A-N - afslut runde og returnér resultat og rolls
        // Og hvor den stopper op og venter på brugerens input før den går videre til næste bruger

        public static void DisplayRollsAndCombinations(int[] dice)
        {
            Console.WriteLine("Your rolls: " + string.Join(", ", dice) + "\n");
            Console.WriteLine($"A - 1's .................. sum = {ones(dice)}");
            Console.WriteLine($"B - 2's .................. sum = {twos(dice)}");
            Console.WriteLine($"C - 3's .................. sum = {threes(dice)}");
            Console.WriteLine($"D - 4's .................. sum = {fours(dice)}");
            Console.WriteLine($"E - 5's .................. sum = {fives(dice)}");
            Console.WriteLine($"F - 6's .................. sum = {sixes(dice)}");
            Console.WriteLine($"G - One Pair ............. sum = {onePair(dice)}");
            Console.WriteLine($"H - Two Pairs ............ sum = {twoPairs(dice)}");
            Console.WriteLine($"I - Three-of-a-Kind ...... sum = {calcThreeOfAKind(dice)}");
            Console.WriteLine($"J - Four-of-a-Kind ....... sum = {calcFourOfAKind(dice)}");
            Console.WriteLine($"K - Small Straight ....... sum = {smallStraight(dice)}");
            Console.WriteLine($"L - Large Straight ....... sum = {largeStraight(dice)}");
            Console.WriteLine($"M - Chance ............... sum = {chance(dice)}");
            Console.WriteLine($"N - YATZY! ............... sum = {yatzy(dice)}");
            Console.WriteLine();
        }

        public static (int comboCategory, int sum) pickCombo(string brugerinput, int[] dice)
        {
            int comboCategory = 0;
            int sum = 0;

            switch (brugerinput)
            {
                case "A": comboCategory = 1;
                    sum = ones(dice);
                    break;
                case "B": comboCategory = 2;
                    sum = twos(dice);
                    break;
                case "C": comboCategory = 3;
                    sum = threes(dice);
                    break;
                case "D": comboCategory = 4;
                    sum = fours(dice);
                    break;
                case "E": comboCategory = 5;
                    sum = fives(dice);
                    break;
                case "F": comboCategory = 6;
                    sum = sixes(dice);
                    break;
                case "G": comboCategory = 7;
                    sum = onePair(dice);
                    break;
                case "H": comboCategory = 8;
                    sum = twoPairs(dice);
                    break;
                case "I": comboCategory = 9;
                    sum = calcThreeOfAKind(dice);
                    break;
                case "J": comboCategory = 10;
                    sum = calcFourOfAKind(dice);
                    break;
                case "K": comboCategory = 11;
                    sum = smallStraight(dice);
                    break;
                case "L": comboCategory = 12;
                    sum = largeStraight(dice);
                    break;
                case "M": comboCategory = 13;
                    sum = chance(dice);
                    break;
                case "N": comboCategory = 14;
                    sum = yatzy(dice);
                    break;
            }
            return (comboCategory, sum);
        }

        public static int ones(int[] dice)
        {
            int onesCount = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == 1)
                {
                    onesCount++;
                }
            }
            return onesCount;
        }
        public static int twos(int[] dice)
        {
            int twosCount = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == 2)
                {
                    twosCount += 2;
                }
            }
            return twosCount;
        }
        public static int threes(int[] dice)
        {
            int threesCount = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == 3)
                {
                    threesCount += 3;
                }
            }
            return threesCount;
        }
        public static int fours(int[] dice)
        {
            int foursCount = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == 4)
                {
                    foursCount += 4;
                }
            }
            return foursCount;
        }
        public static int fives(int[] dice)
        {
            int fivesCount = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == 5)
                {
                    fivesCount += 5;
                }
            }
            return fivesCount;
        }
        public static int sixes(int[] dice)
        {
            int sixesCount = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == 6)
                {
                    sixesCount += 6;
                }
            }
            return sixesCount;
        }

        public static int onePair(int[] dice)
        {
            var counts = new int[6];
            foreach (var roll in dice)
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

        public static int twoPairs(int[] dice)
        {
            var counts = new int[6];
            foreach (var roll in dice)
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

        public static int calcThreeOfAKind(int[] dice)
        {
            int[] sortArray = (int[])dice.Clone();
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
        public static int calcFourOfAKind(int[] dice)
        {
            int[] sortArray = (int[])dice.Clone();
            Array.Sort(sortArray);

            if ((sortArray[0] == sortArray[3]) || (sortArray[1] == sortArray[4]))
            {
                return sortArray[2] * 4;
            }
            return 0;
        }

        public static int smallStraight(int[] dice)
        {
            int[] sortArray = (int[])dice.Clone();
            Array.Sort(sortArray);
            if (sortArray[0] == 1 && sortArray[1] == 2 && sortArray[2] == 3 && sortArray[3] == 4 && sortArray[4] == 5) return 15;
            else return 0;
        }

        public static int largeStraight(int[] dice)
        {
            int[] sortArray = (int[])dice.Clone();
            Array.Sort(sortArray);
            if (sortArray[4] == 6 && sortArray[3] == 5 && sortArray[2] == 4 && sortArray[1] == 3 && sortArray[0] == 2) return 20;
            else return 0;
        }
        public static int chance(int[] dice)
        {
            int chanceCount = 0;

            for (int i = 0; i < dice.Length; i++)
            {
                chanceCount += dice[i];
            }

            return chanceCount;
        }
        public static int yatzy(int[] dice)
        {
            var counts = new int[6];
            foreach (var roll in dice)
            {
                counts[roll - 1]++;
            }

            foreach (var count in counts)
            {
                if (count == 5)
                {
                    return 50;
                }
            }
            return 0;
        }

    }
}