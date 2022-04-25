using System;
using System.Collections.Generic;
using System.Linq;

namespace T._18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> list = new List<int>();
            
            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count); i++)
            {
                list.Add(firstList[i]);
                list.Add(secondList[secondList.Count - 1 - i]);
            }

            int startRange = 0;
            int endRange = 0;

            if (firstList.Count > secondList.Count)
            {
                startRange = Math.Min(firstList[firstList.Count - 1], firstList[firstList.Count - 2]);
                endRange = Math.Max(firstList[firstList.Count - 1], firstList[firstList.Count - 2]);
            }
            else
            {
                startRange = Math.Min(secondList[secondList.Count - 1], secondList[secondList.Count - 2]);
                endRange = Math.Max(secondList[secondList.Count - 1], secondList[secondList.Count - 2]);
            }

            foreach (int number in list.OrderBy(x => x))
            {
                if (number > startRange && number < endRange)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
