﻿using System;
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
                if (nyInt % 2 == 0) 
                {
                    Console.WriteLine(hej[nyInt]);
                }

                nyInt++;
            }

            Console.ReadLine();


        }
    }
}