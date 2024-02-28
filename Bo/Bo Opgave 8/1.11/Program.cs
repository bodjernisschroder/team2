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
            string op = "+-";
            string hej = "bu22rak-1er4se+j0";

            for (int i = 0; i < hej.Length; i++)
            {

                if (tal.Contains(hej[i]))
                {
                    Console.WriteLine("På plads {0} finder vi {1} (ciffer)", i, hej[i]);
                }
                else if (op.Contains(hej[i]))
                {
                    Console.WriteLine("På plads {0} finder vi {1} (operator)", i, hej[i]);
                }
                else 
                {
                    Console.WriteLine("På plads {0} finder vi {1} (ukendt)", i, hej[i]);
                }
            }



            Console.ReadLine();

        }
    }
}