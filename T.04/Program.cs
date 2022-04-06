using System;

namespace T._04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            char biggerChar = (char)Math.Max(firstChar, secondChar);
            char smallerChar = (char)Math.Min(firstChar, secondChar);

            string str = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > smallerChar && str[i] < biggerChar)
                {
                    sum += str[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
