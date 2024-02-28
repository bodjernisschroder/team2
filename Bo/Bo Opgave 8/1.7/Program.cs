using System;
using System.Collections;
using System.Xml.Serialization;

namespace opgave8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Indtast et heltal: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast endnu et heltal: ");
            int b = int.Parse(Console.ReadLine());

            int k = a / b;

            int r = a % b;

            Console.WriteLine(r);

            Console.ReadLine();


        }
    }
}