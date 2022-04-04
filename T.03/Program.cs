using System;
using System.Collections.Generic;
using System.Linq;

namespace T._03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sentence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> uppercaseWords = new List<string>();

            foreach (var word in sentence)
            {
                bool isUpper = true;

                foreach (char letter in word)
                {
                    if (Char.IsLower(letter))
                    {
                        isUpper = false;
                    }
                }

                if (isUpper)
                {
                    uppercaseWords.Add(word);
                }
            }

            if (uppercaseWords.Any())
            {
                Console.WriteLine($"The uppercase words are {{{uppercaseWords.Count}}}:");

                Console.WriteLine(string.Join(", ", uppercaseWords));
            }
            else
            {
                Console.WriteLine("No uppercase words.");
            }
        }
    }
}
