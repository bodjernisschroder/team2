namespace BoOpgave7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Opgave 1.3

            //Int er heltal uden decimaler, f.eks 42
            //float er tal med decimaler, op til 7 tal samlet f.eks 6.123456
            //double er tal med decimaler, op til 16 tal samlet f.eks 6.123456789123456
            //decimal er tal med decimaler, op til 28 samlet f.eks 6.111111111111111111111111111

            double y1, y2, x1, x2;

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