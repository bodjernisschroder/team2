using System;

class YatzyScoreboard
{
    private int[] upperSectionScores;
    private int[] lowerSectionScores;

    public YatzyScoreboard()
    {
        upperSectionScores = new int[6]; // Categories 1-6
        lowerSectionScores = new int[7]; // Categories 7-13
    }

    public void SetUpperSectionScore(int category, int score)
    {
        upperSectionScores[category - 1] = score;
    }

    public void SetLowerSectionScore(int category, int score)
    {
        lowerSectionScores[category - 7] = score;
    }

    public void PrintScoreboard()
    {
        Console.WriteLine("Yatzy Scoreboard:");
        Console.WriteLine("Upper Section:");
        for (int i = 0; i < upperSectionScores.Length; i++)
        {
            Console.WriteLine($"Category {i + 1}: {upperSectionScores[i]}");
        }
        Console.WriteLine("--------------------");
        Console.WriteLine("1. Ones");
        Console.WriteLine("2. Twos");
        Console.WriteLine("3. Threes");
        Console.WriteLine("4. Fours");
        Console.WriteLine("5. Fives");
        Console.WriteLine("6. Sixes");

        Console.WriteLine();
        Console.WriteLine("Lower Section:");
        for (int i = 0; i < lowerSectionScores.Length; i++)
        {
            Console.WriteLine($"Category {i + 7}: {lowerSectionScores[i]}");
        }
        Console.WriteLine("--------------------");
        Console.WriteLine("7. Three of a Kind");
        Console.WriteLine("8. Four of a Kind");
        Console.WriteLine("9. Full House");
        Console.WriteLine("10. Small Straight");
        Console.WriteLine("11. Large Straight");
        Console.WriteLine("12. Yatzy");
        Console.WriteLine("13. Chance");
    }
}


