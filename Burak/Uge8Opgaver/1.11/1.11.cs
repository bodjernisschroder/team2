namespace _1._11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(hej[1]);
            //Console.WriteLine(hej[3]);
            //Console.WriteLine(hej[5]);

            string[] talArray = new string[10];

            string tal = "0123456789";
            string op = "+-";

            string hej = "b-ur22ak4+er-s2ej0";
            string ukendt = "Ukendt"; 
          
            for (int i = 0; i < hej.Length; i++)

            {
                if (tal.Contains(hej[i]))
                {
                    Console.WriteLine("Index: {0} for karakteren {1} (ciffer)", i, hej[i]);
                }
                else if (op.Contains(hej[i])) 
                {
                    Console.WriteLine("Index: {0} for karakteren {1} (operator)", i, hej[i]);
                }
                {
                    Console.WriteLine("Index: {0} for karakteren (Ukendt)", i, hej[i]);
                }
                
            }

            Console.ReadLine();
        }
    }
}
