namespace BoConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Write skriver ny sætning på samme linje.
            //WriteLine skriver ny sætning på næste linje.
            //ReadLine beder brugeren om input.

            string navn; //datatypen string indeholder tekst pakket inde i quotes ("tekst her").
            string alder;

            Console.Write("Indtast navn: ");
            navn = Console.ReadLine(); //Her ændres værdien af vores variabel kaldet navn, og bliver sat til at være brugers input.
            Console.WriteLine("Navn: " + navn);
            
            Console.Write("Indtast alder: ");
            alder = Console.ReadLine();
            Console.WriteLine("Alder: " + alder);

            Console.Write(navn + " er " + alder + " år gammel"); //Her sammenkæder vi flere elementer (concatinate).

            Console.ReadLine(); //Når vi afslutter med denne linje, sørger vi for at programmet ikke lukker terminalen automatisk til sidst.

        }
    }
}