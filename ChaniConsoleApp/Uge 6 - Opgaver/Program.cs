using System.Security.Cryptography.X509Certificates;

namespace Uge_6___Opgaver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write is just write and write on same line. WriteLine writes it a whole line for itself
            //Console.Write("Navn:");
            //Console.WriteLine("Chanita");
            //Console.Write("Alder:");
            //Console.Write("21");

            //ReadLine will read the input of your text
            //Console.Write("Indtast navn: ");
            //Console.WriteLine("Navn: " + Console.ReadLine());

            //Console.Write("Indtast alder:");
            //Console.WriteLine("Alder: " + Console.ReadLine());

            //Console.ReadLine();

            ´//String put a value to something. 
            string navn;
            string alder;

            Console.Write("Indtast navn: ");
            navn = Console.ReadLine(); //This creates value to navn with user input
            Console.WriteLine("Navn: " + navn);
            
            Console.Write("Indtast alder:");
            alder = Console.ReadLine();
            Console.WriteLine("Alder: " + alder);
            Console.WriteLine(navn + " er " + alder + " år gammel"); // This is where we connect them together (concatinate)

            Console.ReadLine(); //Ending with this will cause the code to keep running instead of ending the terminal
        }
    }
}
