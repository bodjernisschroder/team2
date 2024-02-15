namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Opgave 1.2 Beregn areal af rektanglet
            //// Vi bruger double, så decimaltal kan vises i konsolvinduet. 


            //double x1, x2, y1, y2;

            //Console.WriteLine("Indtast x1-koordinat: ");
            //x1 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Indtast y1-koordinat: ");
            //y1 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Indtast x2-koordinat: ");
            //x2 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Indtast y2-koordinat: ");
            //y2 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Hældningen af linjestykket " + (y2-y1) / (x2-x1));

            //Console.ReadLine(); 
            //Opgave 2.1 
            //string navn = "Burak Gültekin";
            //Console.WriteLine(navn.Length);

            //Console.ReadLine();
            // Opgave 2.2 

            //string navn = "Burak Gültekin";
            //Console.WriteLine(navn.Substring(0,5)); // kombiner med .lenght

            //Console.ReadLine();
            // Opgave

            //string navn = "Burak Gültekin";
            //char b = 'B'; 
            //Console.WriteLine(navn.IndexOf(b));

            //if (navn.IndexOf(b).Compare( ) { }

            //Console.ReadLine();
            
            // Opgave 2.3
            string navn = "Burak Gültekin";
            Console.WriteLine("Den fulde string: " + navn);
            char bogstav = 'B';
            
            double index = navn.IndexOf(bogstav);
            if (index >= 0) 
                {
                    Console.WriteLine(navn.IndexOf(bogstav));  
                }
            else
                {
                    Console.WriteLine("Karakteren blev ikke fundet. ");
                }

            Console.ReadLine();

        }
    }
}