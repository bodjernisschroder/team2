using System;

namespace BoConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Test
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
            Console.Write("Alder: " + alder);

            Console.WriteLine();
            Console.WriteLine();

            int alderInt = int.Parse(alder); //Konvertering af alder fra string til int.

            string aldersgruppe = ""; //Tom string, hvor vi senere kan indsætte hvilken aldersgruppe brugeren er i.

            bool gammel = false; //Denne bool kaldet gammel, er sat til at være false fra start. 


            //Her leger vi med if/else, så der sker noget bestemt baseret på brugers alders-input.
            if (alderInt <= 2) //Hvis brugeren er 2 år eller under, så bliver aldersgruppen 'Baby' tildelt.
            {
                aldersgruppe = "Baby.";
            }
            else if (alderInt >= 3 && alderInt <= 12) //Her bruger vi operators som <= (mindre end eller lig med), for at se om brugers input opfylder kravet for denne statement.
            {
                aldersgruppe = "Barn.";
            }
            else if (alderInt >= 13 && alderInt <= 17)
            {
                aldersgruppe = "Teenager.";
            }
            else if(alderInt >= 18 && alderInt <= 67)
            {
                aldersgruppe = "Voksen.";
            }
            else
            {
                gammel = true; //Er brugeren mere end 67 år gammel, så skifter vores bool kaldet gammel til at være true.
                aldersgruppe = "Pensionist.";
            }

            string output = (navn + " er " + alder + " år gammel, og er derfor i aldersgruppen: " + aldersgruppe);
            Console.Write(output);

            Console.WriteLine();
            Console.WriteLine();

            //for loop, der printer en linje til konsollen for hvert år brugeren har levet.
            for (int i = 1; i < alderInt+1; i++)
            {
                Console.Write(navn + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //While loop, der laver en operation indtil kriterierne ikke længere er opfyldt (gør x, så længe y er opfyldt).
            int decades = 0;

            while (alderInt >= 10)
            {
                alderInt = alderInt - 10;
                decades += 1;
            }
            Console.Write("Du har levet " + decades + " fulde årtier og " + alderInt + " år.");

            Console.WriteLine();
            Console.WriteLine();


            if (gammel == true)
            {
                Console.WriteLine("Husk stokken bedstefar!"); //Denne sætning bliver kun printet i konsollen, hvis brugeren er pensionist.
            }

            Console.ReadLine(); //Når vi afslutter med denne linje, sørger vi for at programmet ikke lukker terminalen automatisk til sidst.
        }
    }
}