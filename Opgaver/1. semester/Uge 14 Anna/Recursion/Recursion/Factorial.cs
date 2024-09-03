namespace Recursion
{
    public static class Factorial
    {
        public static int FindFactorial(int n)
        {
            if (n == 0) return 1;
            int factorial = n * FindFactorial(n - 1);
            return factorial;
        }
    }
}
