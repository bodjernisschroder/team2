﻿using System.Collections;
using System.Xml.Serialization;

namespace opgave8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Min fantastiske menu");
            Console.WriteLine("1. Gør dit");
            Console.WriteLine("2. Gør dat");
            Console.WriteLine("3. Gør noget");
            Console.WriteLine("4. Få svaret på livet, universet og alting");
            int userValue = int.Parse(Console.ReadLine());
            string message = "";


            switch (userValue)
            {
                case 1:
                    message = "Punkt 1 er valgt: Gør dit";
                    break;

                case 2:
                    message = "Punkt 2 er valgt: Gør dat";
                    break;

                case 3:
                    message = "Punkt 3 er valgt: Gør noget";
                    break;

                case 4:
                    message = "Punkt 4 er valgt: 42";
                    break;

                default:
                    message = "Forkert valg ";
                    message += "Du gjorde ingenting";
                    break;
            }

            Console.WriteLine(message);

            string hej = "burakersej";

            Console.WriteLine(hej[1]);
            Console.WriteLine(hej[3]);
            Console.WriteLine(hej[5]);

            int nyInt = 0;

            while (nyInt < hej.Length) 
            {
                Console.WriteLine(hej[nyInt]);
                nyInt++;
            }

            Console.ReadLine();



            //if (userValue == "1")
            //    message = "Punkt 1 er valgt: Gør dit";
            //else if (userValue == "2")
            //    message = "Punkt 2 er valgt: Gør dat";
            //else if (userValue == "3")
            //    message = "Punkt 3 er valgt: Gør noget";
            //else if (userValue == "4")
            //    message = "Punkt 4 er valgt: 42";
            //else
            //{
            //    message = "Forkert valg ";
            //    message += "Du gjorde ingenting"; // Assignment og concatement i en. 
            //}// Vi beholder tuborgklammerne her for at sammensætte den sidste besked. 

        }
    }
}