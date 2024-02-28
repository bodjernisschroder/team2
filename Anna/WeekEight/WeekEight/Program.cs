using System;
using System.Data;

namespace WeekEight
{
    class Program
    {
        static void Main(string[] args)
        {
            //string hej = "BurakErSej";
            //int myInt = 0;

            // Opgave 1.4
            //Console.WriteLine(hej[1]);
            //Console.WriteLine(hej[2]);
            //Console.WriteLine(hej[3]);

            // Opgave 1.5
            //while (myInt < hej.Length)
            //{
            //    Console.WriteLine(hej[myInt]);
            //    myInt++;
            //}

            //Console.ReadLine();

            // Opgave 1.6
            //do {
            //    Console.WriteLine(hej[myInt]);
            //    myInt++;
            //} while (myInt < hej.Length);

            //Console.ReadLine();

            // Opgave 1.7
            //int a;
            //int b;
            //int k;
            //int r;
            //string str;

            //Console.Write("Indtast første heltal: ");
            //str = Console.ReadLine();
            //a = int.Parse(str);

            //Console.Write("Indtast andet heltal: ");
            //str = Console.ReadLine();
            //b = int.Parse(str);

            //k = a / b;

            //r = a % b;

            //Console.WriteLine("Divisionen er {0} og restdelen er {1}", k, r);

            //Console.ReadLine();

            // Opgave 1.9
            //while (myInt < hej.Length)
            //{
            //    if (myInt % 2 == 1)
            //    {
            //        Console.WriteLine(hej[myInt]);
            //    }
            //    myInt++;
            //}

            // Opgave 1.10
            //string tal = "0123456789";
            //string hej = "bu22rak1er4sej0";
            //int gemPlads = 0;

            //for (int i = 0; i < hej.Length; i += gemPlads)
            //{
            //    if (tal.Contains(hej[i]))
            //    {
            //        Console.WriteLine("{0}: {1}", i, hej[i]);
            //    }
            //}

            // Opgave 1.11
            //string tal = "0123456789";
            //string hej = "bu22rak-1e+r4s+ej0";
            //string op = "+-";
            //string str;

            //for (int i = 0; i < hej.Length; i ++)
            //{
            //    if (tal.Contains(hej[i]))
            //        str = "ciffer";
            //    else if (op.Contains(hej[i]))
            //        str = "operator";
            //    else
            //        str = "ukendt";
            //    Console.WriteLine("{0}: {1} ({2})", i, hej[i], str);
            //}

            // Opgave 1.12 + 1.13
            string tal = "0123456789";
            string op = "+-*/";
            string str;
            string talCont;
            string opCont;
            string calc;
            bool invalid;

            DataTable dataTable = new DataTable();
            object result;

            while (true)
            {
                invalid = false;
                talCont = "";
                opCont = "";
                calc = "";
                Console.Write("Angiv et regnestykke bestående af étcifrede tal: ");
                str = Console.ReadLine();

                for (int i = 0; i < str.Length; i++)
                {
                    if (tal.Contains(str[i]))
                        talCont = String.Concat(talCont, str[i]);
                    else if (op.Contains(str[i]))
                        opCont = String.Concat(opCont, str[i]);
                    else
                    {
                        invalid = true;
                    }
                }

                if (talCont.Length > 0 && invalid == false)
                {
                    if (talCont.Length > opCont.Length)
                        talCont = talCont.Substring(0, (opCont.Length + 1));
                    else if (talCont.Length <= opCont.Length)
                        opCont = opCont.Substring(0, (talCont.Length - 1));

                    for (int i = 0; i < opCont.Length; i++)
                    {
                        calc = String.Concat(calc, talCont[i], opCont[i]);
                    }
                    calc = String.Concat(calc, talCont[talCont.Length - 1]);

                    result = dataTable.Compute(calc, "");
                    Console.WriteLine(result);
                }
                else
                    Console.WriteLine("Regnestykket er ugyldigt. Prøv igen.");
            }
        }
    }
}