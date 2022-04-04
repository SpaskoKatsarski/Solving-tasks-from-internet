using System;
using System.Linq;

namespace T._01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var num in arr.Where(x => x % 2 == 0))
            {
                Console.Write(num + " ");
            }
        }
    }
}
