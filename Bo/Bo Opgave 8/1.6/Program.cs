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

            do
            {
                Console.WriteLine(hej[nyInt]);
                nyInt++;
            } while (nyInt < hej.Length);

            Console.ReadLine();


        }
    }
}