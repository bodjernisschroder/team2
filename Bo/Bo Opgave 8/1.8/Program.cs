using System.Collections;
using System.Xml.Serialization;

namespace _7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
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

                Console.WriteLine("Vil du genstarte programmet?");
                Console.WriteLine("Tast 1 for at genstarte ellers tast en vilkårlig tast for at lukke programmet");
                int startOver = int.Parse(Console.ReadLine());

                if (startOver == 1)
                    Console.Clear();

                else
                {
                    break;
                }
            }

        }
    }
}