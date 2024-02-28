using System;
using System.Collections;
using System.Xml.Serialization;

namespace opgave8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string hej = "burakersej";

            int nyInt = 0;

            while (nyInt < hej.Length)
            {
                if(nyInt % 2 == 1)

                {
                    Console.WriteLine(hej[nyInt]);
                }
                Console.WriteLine(nyInt % 2);
                nyInt++;

            }

            Console.ReadLine();


        }
    }
}