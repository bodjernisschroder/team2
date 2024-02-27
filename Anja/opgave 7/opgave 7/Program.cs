namespace opgave_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 7.1 - Beregn areal af rektangel

            // Console.WriteLine("Indtast højden på rektanglet: ");
            //int h = Int32.Parse(Console.ReadLine()); // her konverteres fra string til int

            // Console.WriteLine("indtast bredde på rektangel: ");
            // int b = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Arealet på rektanglet er: " + h*b);


            //Opgave 7.2 - Beregn hældning på linjestykke

            //int y1, y2, x1, x2;

            // Console.WriteLine("Angiv x1: ");
            // x1 = Int32.Parse(Console.ReadLine());

            // Console.WriteLine("Angiv x2: ");
            // x2 = Int32.Parse(Console.ReadLine());

            // Console.WriteLine("Angiv y1: ");
            // y1 = Int32.Parse(Console.ReadLine());

            // Console.WriteLine("Angiv y2: ");
            // y2 = Int32.Parse(Console.ReadLine());

            // Console.WriteLine("Hældningen for linjestykket er: " + (y2 - y1) / (x2 - x1));

            // Console.ReadLine();


            //Opgave 7.3 Ny beregning af linjestykkets hældning

            // double x1, x2, y1, y2;

            //Console.WriteLine("Angiv x1: ");
            //x1 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Angiv x2: ");
            //x2 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Angiv y1: ");
            //y1 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Angiv y2: ");
            //y2 = Int32.Parse(Console.ReadLine());

            //Console.WriteLine("Hældningen for linjestykke er: " + (y2 - y1) / (x2-x1));

            //Console.ReadLine();

            //Opgave 2.1 Afgør længden af en streng (Length angiver hvor mange tegn der er i vores streng "indenfor ")

            // string navn = "Anja Petersen";
            // Console.WriteLine(navn.Length);


            // opgave 7 2.2 substring ( der skrives 0, og antal der skal visis, fordi programmet starter op 0)

            // string navn = "Anja Petersen"; 
            // Console.WriteLine(navn.Substring(0,13));

            // Console.ReadLine();


            // Opgave7 2.3 find potionen i en bestemt karakter i en angiven streng

            string navn = " Anja Petersen";
            Console.WriteLine("den fulde string:" + navn);

            char bogstav = 'x';

            double index = navn.IndexOf(bogstav);

            if (index >= 0 ) 
            {
              Console.WriteLine(navn.IndexOf(bogstav)); // her skriver den hvilken plads char: har i string
            }
            else 
            {
              Console.WriteLine("karakteren blev ikke fundet. "); // her finder den strengen hvis bogstavet fra char ikke er i
            }

            Console.ReadLine();





           
         


        }
    }
}
