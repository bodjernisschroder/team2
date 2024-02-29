using System.ComponentModel.Design;
using System.Net.NetworkInformation;

internal class Program
{
    private static void Main(string[] args)
    {
        //Data typer

        int lilleHeltal = 1; //Heltal uden decimaler
        double stortHeltal = 999999; //Heltal, men kan indeholde et langt større tal
        decimal decimaler = 10021; //Tal der kan indeholde decimaler

        string voresString = "Hej med jersssssssssssssssssssssssssssssssssssssssss"; //Sætning inde i quotes
        char minChar = 'A'; // Et enkelt symbol, tal, eller bogstav, inde i apostrof

        bool minBool = false; //true ller false

        int[] tal = { 1, 2, 3 }; //array er en slags liste, hvor vi kan opbevare flere ting af gangen

        string[] voresTekst = { "hej", "med", "dig" };
        
        if (1 > 2) //Gør noget hvis det der står i parantesen er opfyldt, ellers gå videre
        {
            Console.WriteLine("2 er større end 1");
            Console.WriteLine("2 er større end 1");
        }
        else
        {
            Console.WriteLine("Hej");
        }

        if (1 > 2) Console.WriteLine("2 er større end 1"); //en måde at gøre en if statement lidt pænere på, men virker kun hvis der er én kodelinje der skal udføres

        //Lav et program, der tager to tal fra brugeren, og lægger dem sammen.

        Console.WriteLine("Vælg dit første tal: "); //Printer noget tekst til brugeren
        int førsteTal = int.Parse(Console.ReadLine()); //Tager brugeres svar, og gemmer det som et tal i førsteTal variablen. int.Parse() laver en string om til et tal

        Console.WriteLine("Vælg dit andet tal: ");
        int andetTal = int.Parse(Console.ReadLine());

        int resultat = førsteTal + andetTal;

        Console.WriteLine("Resultat er: " + resultat);



        Console.ReadLine();
    }
}