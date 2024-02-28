using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace opgave8
{
    internal class Program
    {
        static void Main(string[] args)

        {
            // genStart og while loopen den bliver brugt i, gør at brugeren i sidste ende kan vælge om de vil lave endnu et regnestykke eller lukke programmet
            bool genstart = true;

            while (genstart) { 
                Console.WriteLine("Indtast et regnestykke med tal fra 0-9, plus (+), minus (-), multiplikation (*) og division (/): ");
                string userInput = Console.ReadLine();

                string tal = "0123456789";
                string op = "+-/*";
                int validCount = 0;
                bool valid = false;

                //Denne for loop skanner brugeres input, og tjekker om der er brugt godkendte tal og operators
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (tal.Contains(userInput[i])) validCount += 1;
                    else if (op.Contains(userInput[i])) validCount += 1;
                }

                //Efter for loopen har fyldt validCount op, så tjekker vi her om samtlige karakterer i brugerens input var godkendte
                if (validCount == userInput.Length) valid = true;

                //Er brugeres input valid, så bruger vi den næste sektion til at kæde regnestykket korrekt sammen inde i 'resultat'
                int resultat = 0;
                int tal2 = 0;
                char op2 = '+';

                if (valid) { 
                    for (int i = 0; i < userInput.Length; i++)
                    {
                        char denneChar = userInput[i];

                        if (char.IsDigit(denneChar)) tal2 = tal2 * 10 + (denneChar - '0');

                        if (denneChar == '+' || denneChar == '-' || denneChar == '/' || denneChar == '*' || i == userInput.Length -1)
                        {
                            if (op2 == '+') resultat += tal2;
                            else if (op2 == '-') resultat -= tal2;
                            else if (op2 == '*') resultat *= tal2;
                            else if (op2 == '/') resultat /= tal2;

                            tal2 = 0;
                            op2 = denneChar;
                        }
                    }
                }

                //Hvis brugeres input er korrekt, så laver den regnestykket, og ellers melder den fejl
                if (valid) Console.WriteLine("{0} = {1}", userInput, resultat);
                else Console.WriteLine("Fejl - Indtast et gyldigt regnestykke.");

                //Spørg brugeren om de vil prøve igen eller lukke programmet
                Console.WriteLine("Vil du prøve igen? (ja/nej): ");
                string userResponse = Console.ReadLine().ToLower();

                if (userResponse != "ja") genstart = false;
            }
        }
    }
}