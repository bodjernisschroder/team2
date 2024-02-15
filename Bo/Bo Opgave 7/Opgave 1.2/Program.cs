namespace BoOpgave7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Opgave 1.2

            int y1, y2, x1, x2;

            Console.WriteLine("Angiv x1: ");
            x1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Angiv x2: ");
            x2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Angiv y1: ");
            y1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Angiv y2: ");
            y2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Hældningen for linjestykket er: " + (y2 - y1) / (x2 - x1));

            Console.ReadLine();
        }
    }
}