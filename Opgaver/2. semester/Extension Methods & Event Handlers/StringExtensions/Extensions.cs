using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public static class Extensions
    {
        public static string Capitalize(this string str)
        {
            return (!string.IsNullOrEmpty(str)) ? str[0].ToString().ToUpper() + str.Substring(1) : str;
        }

        public static double NextDouble(this Random random, double num)
        {
            return (num <= 0) ? random.NextDouble() * num : num;
        }

        public static bool CoinFlip(this Random random, bool coin) 
        { 
            return (random.Next(1, 101) >= 51);
        }

        public static string NextString(this Random random, string[] options)
        {
            return options[random.Next(0, options.Length)]; 
        }
    }
}
