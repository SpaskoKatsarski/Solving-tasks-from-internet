using System;
using System.Linq;

namespace T._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

            foreach (var i in arr.Where(x => x > 0))
            {
                Console.Write(i + " ");
            }
        }
    }
}
