using System.ComponentModel.Design;
using System.Net.NetworkInformation;

internal class Program
{
    private static void Main(string[] args)
    {
        // VARIABLER OG DATATYPER:

        // 'int' står for integer (heltal) og bruges til tal uden decimaler.
        int lilleHeltal = 1;

        // 'double' er en datatype for flydende tal, der kan indeholde meget store tal.
        double stortHeltal = 999999;

        // 'decimal' er en datatype for tal med decimaler, der kræver høj præcision, som f.eks. pengebeløb. Man skal sætte et m bagpå tallet, hvis man giver det en fast værdi.
        decimal decimaler = 100.21m;

        // 'string' repræsenterer en tekststreng.
        string voresString = "Hej med jer";

        // 'char' står for character og repræsenterer et enkelt tegn, omgivet af apostroffer.
        char minChar = 'A';

        // 'bool' står for boolean og kan enten være true (sand) eller false (falsk).
        bool minBool = false;

        // 'int[]' definerer et array af integers, som er en samling af tal. Et array er altid præsenteret med firkantede paranteser.
        int[] tal = { 1, 2, 3 };

        // 'string[]' definerer et array af strings, som er en samling af tekststrenge.
        string[] voresTekst = { "hej", "med", "dig" };

        // En simpel if-else statement, der tjekker om betingelsen i parantesen er sand.
        if (2 > 1) // Hvis 2 er større end 1, så udfør koden indeni.
        {
            Console.WriteLine("2 er større end 1"); // Denne linje udføres, da betingelsen er sand.
        }
        else // Hvis den ovenstående betingelse i if parantesen ikke er opfyldt, udfør så denne kodeblok i stedet.
        {
            Console.WriteLine("Hej"); // Printer "Hej" til konsollen. Denne linje udføres ikke, fordi den første jo var sand, så er der ikke brug for den her.
        }
        // En mere kompakt måde at skrive en if-sætning på, hvis kun én handling er nødvendig.
        if (2 > 1) Console.WriteLine("2 er større end 1"); // Virker kun med én operation.



        // SMÅ OPGAVER, DER BRUGER DET VI HAR GENNEMGÅET:


        -----------------------------------------------------------------------------------------------------
        // Et simpelt program der beder brugeren om to tal og lægger dem sammen.

        Console.WriteLine("Vælg dit første tal: "); // Viser en besked til brugeren.
        // 'Console.ReadLine()' venter på brugerinput, og 'int.Parse()' konverterer teksten til et tal.
        int førsteTal = int.Parse(Console.ReadLine());

        Console.WriteLine("Vælg dit andet tal: ");
        int andetTal = int.Parse(Console.ReadLine());

        // Lægger de to tal sammen og gemmer resultatet i 'resultat'.
        int resultat = førsteTal + andetTal;

        // Viser resultatet af de to tal.
        Console.WriteLine("Resultatet er: " + resultat);
        -----------------------------------------------------------------------------------------------------




        // Venter på endnu et brugerinput før programmet lukker. Dette sikrer, at konsolvinduet ikke lukker med det samme. Den er derfor god at have i bunden af sit program.
        Console.ReadLine();
    }
}