    namespace StringExtensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("mit navn er Bo!".Capitalize());

            bool coinFlip = true;
            int num = 10;
            Random random = new Random();
            string[] def = { "east", "west", "north", "south" };

            while (num > 0)
            {
                string result = random.CoinFlip(coinFlip) ? "Tails" : "Heads";
                Console.WriteLine("Coinflip landed on " + result);

                Console.WriteLine("We're going " + random.NextString(def) + "!");

                num--;
            }

            Sparegris sparegris = new Sparegris();
            MySubcriber subcriber = new MySubcriber();

            subcriber.Subscribe(sparegris);

            while (true)
            {
                Console.WriteLine("Hvilket beløb vil du indsætte i sparegrisen?");
                double amount = Double.Parse(Console.ReadLine());

                if (amount == 0) break;
                sparegris.InsertAmount(amount);
            }

            Metronome metronome = new Metronome();
            subcriber.TickListener(metronome);

            for (int i = 0; i < 5; i++)
            {
                metronome.Start();
            }
        }
    }
}
