using System.Data;

namespace _1._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tal = "0123456789";
            string talCont;
            string regnestykke;
            string opCont;
            string op = "+-*/";
            string calc; 
            bool invalid;

            DataTable datatable = new DataTable();
            object result;

            while (true)
            {
                invalid = false;
                talCont = "";
                opCont = "";
                calc = ""; 
                
                Console.Write("Indtast et regnestykke bestående af étcifrede tal: ");

                regnestykke = Console.ReadLine();


                for (int i = 0; i < regnestykke.Length; i++)
                {
                    if (tal.Contains(regnestykke[i]))
                    {
                        talCont = String.Concat(talCont, regnestykke[i]);
                       
                    }
                    else if (op.Contains(regnestykke[i]))
                    {
                        opCont = String.Concat(opCont, regnestykke[i]);
                        
                    }
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

                    result = datatable.Compute(calc, "");
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Regnestykket er ugyldigt. Prøv igen");
                }
            }

        }
    }
}

                //    Console.WriteLine("Index: {0} for karakteren (Ukendt)", i, regnestykke[i]);
                //    Console.WriteLine("Index: {0} for karakteren {1} (operator)", i, regnestykke[i]);
                //    Console.WriteLine("Index: {0} for karakteren {1} (ciffer)", i, regnestykke[i]);
                //Console.ReadLine();