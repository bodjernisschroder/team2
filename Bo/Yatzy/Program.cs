using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        bool isGameStarted = false;

        while (!isGameStarted) 
        {
            Console.Write("Time to play Yatzy - Choose Player Count (1-4): ");
            int players = int.Parse(Console.ReadLine());

            if (players <= 4)
            {
                Console.WriteLine("Press Enter To Begin The Game!");
                isGameStarted = true;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please choose a valid number of players between 1 and 4.");
            }
        }

        if (isGameStarted)
        {
            int rollsLeft = 3;
            int[] rolls = Roll();
            DisplayRollsAndCombinations(rolls);
            rollsLeft--;

            while (rollsLeft > 0) 
            {
                Console.Clear();
                Console.WriteLine();
                DisplayRollsAndCombinations(rolls);
                Console.WriteLine($"You have {rollsLeft} roll(s) left.");
                Console.Write("Select dice to keep (1-5), press Enter to roll all, or pick a combination (A-N) to score: ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    rolls = Roll();
                }
                else
                {
                    for (int i = 0; i < rolls.Length; i++)
                    {
                        if (!userInput.Contains((i + 1).ToString()))
                        {
                            rolls[i] = Select();
                        }
                    }
                }
                rollsLeft--;
                Console.WriteLine(rolls[1]);
            }
            Console.Clear();
            Console.WriteLine();
            DisplayRollsAndCombinations(rolls);
            Console.WriteLine("You're out of rolls. Pick or scratch something on the scoreboard!");
        }

        Console.ReadLine();
    }

    private static Random r = new Random();

    private static int[] Roll()
    {
        int[] rolls = new int[5];
        for (int i = 0; i < rolls.Length; i++)
        {
            rolls[i] = Select();
        }
        return rolls;
    }

    private static int Select()
    {
        return r.Next(1, 6);
    }

    private static void DisplayRollsAndCombinations(int[] rolls)
    {


        Console.WriteLine("Your rolls: " + string.Join(", ", rolls));
        Console.WriteLine();
        Console.WriteLine("Roll again or pick an available combination to score:");
        Console.WriteLine();
        if (ones(rolls) > 0)Console.WriteLine($"A - 1's .................. sum = {ones(rolls)}");
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
        for(int i = 0; i < rolls.Length; i++)
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
                twosCount +=2;
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