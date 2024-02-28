namespace _1._6
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

            do 
            {
                Console.WriteLine(hej[myInt]);
                myInt++;
            }
            while (myInt < hej.Length)

            Console.ReadLine();

        }
    }
}
