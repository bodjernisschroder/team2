using System;

class Program
{
    static void Main(string[] args)
    {
        // Areal
        //bool isAssigned = false;
        //int a;
        //int h = 0;
        //int w = 0;

        //Console.Write("Angiv rektanglets højde: ");

        //// Aflæs højde. Hvis højden er en int, set h.
        //// Ellers vis besked om ugyldig højde og gå først videre når højde = int
        //while (!isAssigned)
        //    if (int.TryParse(Console.ReadLine(), out int height))
        //    {
        //        h = height;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig højde. Indtast et gyldigt heltal.");

        //isAssigned = false;
        //Console.Write("Angiv rektanglets bredde: ");

        //// Aflæs bredde. Hvis bredden er en int, set h.
        //// Ellers vis besked om ugyldig bredde og gå først videre når bredde = int
        //while (isAssigned == false)
        //    if (int.TryParse(Console.ReadLine(), out int width))
        //    {
        //        w = width;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig bredde. Indtast et gyldigt heltal.");

        //a = h * w;
        //Console.WriteLine("Rektanglets areal er " + a);

        // Hældning int
        //bool isAssigned = false;
        //int h;
        //int x1 = 0;
        //int x2 = 0;
        //int y1 = 0;
        //int y2 = 0;

        //Console.Write("Angiv startpunktets x-koordinat: ");

        //while (!isAssigned)
        //    if (int.TryParse(Console.ReadLine(), out int startX))
        //    {
        //        x1 = startX;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi. Indtast et gyldigt heltal.");

        //isAssigned = false;
        //Console.Write("Angiv startpunktets y-koordinat: ");

        //while (isAssigned == false)
        //    if (int.TryParse(Console.ReadLine(), out int startY))
        //    {
        //        y1 = startY;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi. Indtast et gyldigt heltal.");

        //isAssigned = false;
        //Console.Write("Angiv slutpunktets x-koordinat: ");

        //while (!isAssigned)
        //    if (int.TryParse(Console.ReadLine(), out int endX))
        //    {
        //        x2 = endX;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi. Indtast et gyldigt heltal.");

        //isAssigned = false;
        //Console.Write("Angiv slutpunktets y-koordinat: ");

        //while (isAssigned == false)
        //    if (int.TryParse(Console.ReadLine(), out int endY))
        //    {
        //        y2 = endY;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi. Indtast et gyldigt heltal.");

        //h = (y2 - y1) / (x2 - x1);
        //Console.WriteLine("Hældningen af linjestykket er " + h);

        // Hældning double
        //bool isAssigned = false;
        //double h;
        //double x1 = 0.0;
        //double x2 = 0.0;
        //double y1 = 0.0;
        //double y2 = 0.0;

        //Console.Write("Angiv startpunktets x-koordinat: ");

        //while (!isAssigned)
        //    if (double.TryParse(Console.ReadLine(), out double startX))
        //    {
        //        x1 = startX;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi.");

        //isAssigned = false;
        //Console.Write("Angiv startpunktets y-koordinat: ");

        //while (isAssigned == false)
        //    if (double.TryParse(Console.ReadLine(), out double startY))
        //    {
        //        y1 = startY;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi.");

        //isAssigned = false;
        //Console.Write("Angiv slutpunktets x-koordinat: ");

        //while (!isAssigned)
        //    if (double.TryParse(Console.ReadLine(), out double endX))
        //    {
        //        x2 = endX;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi.");

        //isAssigned = false;
        //Console.Write("Angiv slutpunktets y-koordinat: ");

        //while (isAssigned == false)
        //    if (double.TryParse(Console.ReadLine(), out double endY))
        //    {
        //        y2 = endY;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi.");

        //h = (y2 - y1) / (x2 - x1);
        //Console.WriteLine("Hældningen af linjestykket er " + h);

        // String length
        //string s;

        //Console.Write("Angiv en sætning: ");
        //s = Console.ReadLine();
        //Console.WriteLine("Længden på sætningen er " + s.Length);

        // Substring
        //bool isAssigned = false;
        //string s;
        //int pos = 0;
        //int len = 0;
        //string partS;

        //Console.Write("Angiv en sætning: ");
        //s = Console.ReadLine();

        //Console.Write("Angiv en position: ");

        //while (isAssigned == false)
        //    if (int.TryParse(Console.ReadLine(), out int position))
        //    {
        //        pos = position;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi.");

        //isAssigned = false;
        //Console.Write("Angiv længde: ");

        //while (isAssigned == false)
        //    if (int.TryParse(Console.ReadLine(), out int length))
        //    {
        //        len = length;
        //        isAssigned = true;
        //    }
        //    else
        //        Console.WriteLine("Ugyldig værdi.");


        //partS = s.Substring(pos, len);
        //Console.WriteLine(partS);

        // IndexOf
        bool isAssigned = false;
        string s;
        char c = 'e';
        int pos;

        Console.Write("Angiv en sætning: ");
        s = Console.ReadLine();

        Console.Write("Angiv et bogstav: ");

        while (isAssigned == false)
            if (char.TryParse(Console.ReadLine(), out char letter))
            {
                c = letter;
                isAssigned = true;
            }
            else
                Console.WriteLine("Ugyldig værdi.");

        pos = s.IndexOf(c);
        if (pos > 0)
            Console.WriteLine("{0} er på position {1}", c, pos);
        else
            Console.WriteLine("Bogstavet blev ikke fundet.");
    }
}