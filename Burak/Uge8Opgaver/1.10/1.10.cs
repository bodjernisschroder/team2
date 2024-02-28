using System.Net.Http.Headers;

namespace _1._10
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

            string hej = "bu22rak1er4sej0";

            int gemPlads = 0;

            for (int i = gemPlads; i < hej.Length; i++) 
            
            {
                if (tal.Contains(hej[i]))
                {
                    Console.WriteLine("Index: {0} for karakteren {1}", i, hej[i]);
                }
                
            }
            
            Console.ReadLine();
        }
    }
}
