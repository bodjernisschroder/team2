namespace BoOpgave7 {
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Opgave 1.1 - Beregn areal af rektangel
            Console.WriteLine("Indtast højde på rektanglet: ");
            int h = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Indtast bredde på rektanglet");
            int b = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Arealet på rektanglet er: " + h*b);
        }
    }
}