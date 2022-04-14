using System;
using System.Collections.Generic;
using System.Linq;

namespace T._14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                int index = int.Parse(cmdArgs[1]);

                if (action == "Shoot")
                {
                    int power = int.Parse(cmdArgs[2]);

                    if (IsIndexValid(sequence, index))
                    {
                        sequence[index] -= power;

                        if (sequence[index] <= 0)
                        {
                            sequence.RemoveAt(index);
                        }
                    }
                }
                else if (action == "Add")
                {
                    if (IsIndexValid(sequence, index))
                    {
                        int valueToInsert = int.Parse(cmdArgs[2]);

                        sequence.Insert(index, valueToInsert);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (action == "Strike")
                {
                    int power = int.Parse(cmdArgs[2]);

                    if (IsIndexValid(sequence, index + power) && IsIndexValid(sequence, index - power))
                    {
                        int startIndex = index - power;

                        for (int i = 0; i < power * 2 + 1; i++)
                        {
                            sequence.RemoveAt(startIndex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }

            Console.WriteLine(string.Join('|', sequence));
        }

        public static bool IsIndexValid(List<int> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                return true;
            }

            return false;
        }
    }
}
