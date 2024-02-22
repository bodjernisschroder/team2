namespace _1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opgave 1.1 Beregn areal af rektanglet
            Console.WriteLine("Indtast højde på rektanglet: ");
            int height = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Indtast bredde på rektanglet: ");
            int width = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Arealet af rektanglet er " + height*width);
        }
    }
}
