namespace Recursion
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("1. Find Factorial");
            Console.WriteLine("2. Tower Of Hanoi");
            Console.Write("Choose what you would like to do: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Write the number you would like to calculate the factorial of:");
                    int f = int.Parse(Console.ReadLine());
                    int factorial = Factorial.FindFactorial(f);
                    Console.WriteLine($"The factorial of {f} is {factorial}");
                    break;
                case 2:
                    int n = 3;
                    TowerOfHanoi.SolveTowerOfHanoi(n, 'A', 'C', 'B');
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}