using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T._17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numberList = new List<int>();
            List<char> charList = new List<char>(); // The sequence of letters from which we have to form the final result.

            foreach (char ch in input)
            {
                if (char.IsDigit(ch))
                {
                    numberList.Add(int.Parse(ch.ToString()));
                }
                else
                {
                    charList.Add(ch);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numberList[i]);
                }
                else
                {
                    skipList.Add(numberList[i]);
                }
            }

            StringBuilder finalResult = new StringBuilder();

            for (int i = 0; i < takeList.Count; i++)
            {
                int lettersToTake = takeList[i];
                int lettersToSkip = skipList[i];

                if (lettersToTake > charList.Count)
                {
                    lettersToTake = charList.Count;
                }

                for (int j = 0; j < lettersToTake; j++)
                {
                    finalResult.Append(charList[j]);
                }

                charList.RemoveRange(0, lettersToTake);
                charList.RemoveRange(0, lettersToSkip);
            }

            Console.WriteLine(finalResult);
        }
    }
}
