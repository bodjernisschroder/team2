namespace BoOpgave7
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Opgave 2.3

            string hej = "Goddag allesammen, hvordan har i det?";
            Console.WriteLine("Den fulde string: " + hej);
            char bogstav = 'G';

            double index = hej.IndexOf(bogstav);

            if (index >= 0)
            { 
                Console.WriteLine(hej.IndexOf(bogstav));
            }
            else
            {
                Console.WriteLine("Karakteren blev ikke fundet.");
            }

            Console.ReadLine();

        }
    }
}