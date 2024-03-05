using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Yatzy
{
    class Player
    {
        //ScoreBoard scoreBoard = new ScoreBoard();
        //int[] emptyCats;
        public void Create(int i)
        {
            Console.Write("Name of player {0}: ", (i + 1));
            Name = Console.ReadLine();
            Number = i + 1;
            EmptyCats = new int[14];
            for (int j = 0; j < EmptyCats.Length; j++)
            {
                EmptyCats[j] = j+1;
            }
        }
        // Brug denne i Dice i stedet (se kommentar i Roll())
        //public bool CheckIfEmpty(int cat)
        //{
        //    if (emptyCats.Contains(cat)) return true;
        //    else return false;
        //}

        public int[] UpdateEmpty(int cat)
        {
            // The => condition represents a predicate that is applied to each element of the collection.
            // If the condition evaluates to true for a particular element, that element is included in the result.
            // Otherwise, it is excluded.
            EmptyCats = EmptyCats.Where(num => num != cat).ToArray();
            //for (int i = 0; i < EmptyCats.Length; i++)
            //{
            //    Console.WriteLine(EmptyCats);
            //}
            return EmptyCats;
        }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Rolls { get; set; }
        public int Points { get; set; }
        //public ScoreBoard ScoreBoard { get; set; }
        public int[] EmptyCats { get; set; }
    }
}