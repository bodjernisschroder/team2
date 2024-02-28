namespace _1._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hej = "burakersej";
            //Console.WriteLine(hej[1]);
            //Console.WriteLine(hej[3]);
            //Console.WriteLine(hej[5]);

            int myInt = 0;
            
            while (myInt < hej.Length) 
            {
                if (myInt % 2==1)
                {
                    Console.WriteLine(hej[myInt]);
                }
                myInt++;
            }

            Console.ReadLine();
        }
    }
}
