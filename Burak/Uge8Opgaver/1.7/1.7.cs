namespace _1._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast første heltal: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Indtast andet heltal: "); 
            int b = int.Parse(Console.ReadLine());
            
            double et = a / b;
            double to = a % b;

            Console.WriteLine("Heltallet er: "+ et);
            Console.Write("Rest-delen er: "+ to);

            Console.ReadLine();
         }
    }
}
