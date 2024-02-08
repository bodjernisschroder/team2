using System;

namespace AnnaConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Write("Navn: "); //Write udskriver en tekst til konsollen uden at hoppe ned på den efterfølgende linje
            // Console.WriteLine("Anna"); //WriteLine udskriver en tekst og hopper ned på efterfølgende linje
            // Console.Write("Alder: ");
            // Console.WriteLine("25");

            string navn;
            string alder;

            Console.Write("Indtast navn: ");
            navn = Console.ReadLine();
            Console.WriteLine("Navn: " + navn);
            Console.Write("Indtast alder: ");
            alder = Console.ReadLine();
            Console.WriteLine("Alder: " + alder);
            Console.WriteLine(navn + " er " + alder + " år gammel");
            Console.ReadLine(); //Vi bruger ReadLine() til at sikre, at programmet forbliver åbent i terminalen
            //Kommentar tilføjet for GitHub prøve
        }
    }
}