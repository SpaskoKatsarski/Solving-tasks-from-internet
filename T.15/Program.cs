using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T._15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            List<int> indexes = Console.ReadLine().Split().Select(int.Parse).ToList();

            string inputStr = Console.ReadLine();

            foreach (int num in indexes)
            {
                string sequence = num.ToString();

                int sum = 0;

                foreach (char ch in sequence)
                {
                    sum += int.Parse(ch.ToString());
                }

                if (sum >= inputStr.Length)
                {
                    while (sum >= inputStr.Length)
                    {
                        sum -= inputStr.Length;
                    }
                }

                sb.Append(inputStr[sum]);
                inputStr = inputStr.Remove(sum, 1);
            }

            Console.WriteLine(sb);
        }
    }
}
