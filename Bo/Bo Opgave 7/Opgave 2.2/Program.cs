namespace BoOpgave7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            //Opgave 2.2

            string hej = "Goddag allesammen, hvordan har i det?";
            Console.WriteLine("Den fulde sætning: " + hej);
            Console.WriteLine("Længden af den fulde sætning: " + hej.Length);
            Console.WriteLine("Substring med de første 6 bogstaver: " + hej.Substring(0, 6)); //trækker "Goddag" ud af den oprindelige string.
            Console.WriteLine("Længden af vores substring: " + hej.Substring(0, 6).Length); //Giver os længden på vores substring.

            //Med .Substring kan man tage dele af en string ud.

            Console.ReadLine();
           
        }
    }
}