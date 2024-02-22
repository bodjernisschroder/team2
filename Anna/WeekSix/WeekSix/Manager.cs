using System;
using System.Reflection.Metadata.Ecma335;

namespace WeekSix
{
    public class Manager
    {
        string message;
        int programChoice;

        public int StartProgram()
        {
            message = "Hvilket program ønsker du at starte?\n1. Personprogram\n2. Menuprogram";
            Console.WriteLine(message);

            // Vi bruger while ( true ) til at give mulighed for at give et svar på ny, indtil programmet returnerer 1 eller 2.
            // Dette angives som, mens true er true, da true altid vil være true, og derfor vil while loop'et først brydes,
            // hvis der sker et break eller der er et return
            while (true)
            {
                GetKey();

                if ((programChoice == 1) || (programChoice == 2))
                    return programChoice;

                Console.WriteLine("Programmet findes ikke. Prøv igen.");
            }
        }

        public int Continue()
        {
            message = "Hvordan ønsker du at fortsætte?\n1. Opret ny person\n2. Kør menuprogram\n3. Afslut program";
            Console.WriteLine(message);

            while (true)
            {
                GetKey();

                if (programChoice == 1 || programChoice == 2 || programChoice == 3)
                    return programChoice;

                Console.WriteLine("Svarmuligheden findes ikke. Prøv igen.");
            }

        }

        private void GetKey()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (char.IsDigit(keyInfo.KeyChar)) // tjekker om den indtastede key er et tal
            {
                int key = int.Parse(keyInfo.KeyChar.ToString()); // konverterer char til string til int
                programChoice = key;
            }
        }
    }
}