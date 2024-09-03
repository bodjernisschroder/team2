using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public static class TowerOfHanoi
    {
        // n is the number of disks
        // All disks start on the fromRod and end on the toRod in a sorted order
        // auxRod is the auxiliary rod used for temporarily holding disks during the movement from one rod to another
        public static void SolveTowerOfHanoi (int n, char fromRod, char toRod, char auxRod)
        {
            if (n == 0) return;
            SolveTowerOfHanoi(n - 1, fromRod, auxRod, toRod);
            Console.WriteLine($"Move disk {n} from rod {fromRod} to rod {toRod}");
            SolveTowerOfHanoi(n-1, auxRod, toRod, fromRod);
        }
    }
}
