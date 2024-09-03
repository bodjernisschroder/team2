using System;

namespace WeekNine
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;

            Calculator calc = new Calculator();

            while (true)
            {

                try
                {
                    Console.WriteLine("Indtast første tal: ");
                    int x = int.Parse(Console.ReadLine());

                    Console.WriteLine("Indtast operator: ");
                    string op = Console.ReadLine();

                    Console.WriteLine("Indtast andet tal: ");
                    int y = int.Parse(Console.ReadLine());

                    if (op == "+") result = calc.Add(x, y);

                    else if (op == "-") result = calc.Subtract(x, y);

                    else if (op == "*") result = calc.Multiply(x, y);

                    else if (op == "/") result = calc.Divide(x, y);

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Forkert input. Prøv igen");
                }

                Console.WriteLine("Tryk enter for at prøve igen eller 0 for at afslutte");

                string str = Console.ReadLine();
                if (str != "") break;
                Console.Clear();
            }
        }
    }
}