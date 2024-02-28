using System;
using System.Collections;
using System.Xml.Serialization;

namespace opgave8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string tal = "0123456789";

            string hej = "bu22rak1er4sej0";

            for (int i = 0; i < hej.Length; i++)
            {

                if (tal.Contains(hej[i]))
                {
                    Console.WriteLine("På plads {0} finder vi {1}", i, hej[i]);
                }
            }

            Console.ReadLine();

        }
    }
}