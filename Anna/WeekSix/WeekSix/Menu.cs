using System;
using System.Reflection.Metadata.Ecma335;

namespace WeekSix
{
    public class Menu
    {
        string menuText;
        string resultMessage;
        int menuChoice;

        public void Create()
        {
            Write();
            Choose();
            Result();
        }
        private void Write()
        {
            menuText = "Min fantastiske menu:\n1. Gør dit\n2. Gør dat\n3. Gør noget\n4. Få svaret på livet, universet og alting\n\n(Tryk menupunkt 1, 2, 3 eller 4)";
            Console.WriteLine(menuText);
        }

        private void Choose()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // jeg vælger her ikke at bruge else, da det ikke betyder noget, om menuChoice ikke settes,
            // da vi har et else statement i Result(), der tager højde for dette
            if (char.IsDigit(keyInfo.KeyChar)) // tjekker om den indtastede key er et tal
            {
                int key = int.Parse(keyInfo.KeyChar.ToString()); // konverterer char til string til int
                menuChoice = key;
            }
        }

        private void Result()
        {
            switch (menuChoice)
            {
                case 1:
                    resultMessage = "Gør dit";
                    break;
                case 2:
                    resultMessage = "Gør dat";
                    break;
                case 3:
                    resultMessage = "Gør noget";
                    break;
                case 4:
                    resultMessage = "42";
                    break;
                default:
                    resultMessage = "Forkert valg";
                    Console.WriteLine(resultMessage);
                    return; // Går ud af metoden, så den WriteLine, der køres på de andre cases, ikke sker for denne case
            }
            Console.WriteLine("Punkt {0} er valgt: {1}", menuChoice, resultMessage);
        }
    }
}