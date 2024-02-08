namespace Anja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string navn;
            string alder;
            Console.Write("intast navn:"); // Console.Write skriver en ny sætning på samme linje, mens Console.WriteLine skriver efterfølgende sætning på en ny linje.
            navn = Console.ReadLine();
            Console.WriteLine("Navn: " + navn);
            
            Console.Write("indtast alder: ");
            alder = Console.ReadLine();
            Console.WriteLine("Alder: " + alder);
            Console.Write(navn + " er " + alder + " år gammel");
            Console.ReadLine();
            
            
            


        }
    }
}
