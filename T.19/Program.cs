using System;
using System.Collections.Generic;
using System.Linq;

namespace T._19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalSavings = decimal.Parse(Console.ReadLine());
            List<decimal> drumSet = Console.ReadLine().Split().Select(decimal.Parse).ToList();

            Dictionary<string, decimal> initialPrices = new Dictionary<string, decimal>();

            for (int i = 0; i < drumSet.Count; i++)
            {
                initialPrices.Add(i.ToString(), drumSet[i]);
            }

            string command;

            //{initialQuality} * 3
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;
                }

                while (drumSet.Any(d => d <= 0))
                {
                    decimal brokenDrum = drumSet.Find(d => d <= 0);

                    decimal priceForBrokenDrum = initialPrices[drumSet.IndexOf(brokenDrum).ToString()] * 3;

                    if (totalSavings >= priceForBrokenDrum)
                    {
                        drumSet[drumSet.IndexOf(brokenDrum)] = priceForBrokenDrum / 3;
                        totalSavings -= priceForBrokenDrum;
                    }
                    else
                    {
                        drumSet.Remove(brokenDrum);
                    }
                }

                Console.WriteLine(string.Join(' ', drumSet));
            }

            Console.WriteLine(string.Join(' ', drumSet));
            Console.WriteLine($"Gabsy has {totalSavings}lv.");
        }
    }
}
