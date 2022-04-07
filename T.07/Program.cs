using System;
using System.Collections.Generic;
using System.Linq;

namespace T._07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> allDeps = new List<string>();

            Dictionary<string, Employee> departments = new Dictionary<string, Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                decimal salary = decimal.Parse(data[1]);
                string currDep = data[2];

                allDeps.Add(currDep);

                if (!departments.ContainsKey(currDep))
                {
                    departments.Add(currDep, new Employee(0));
                }

                departments[currDep].Salary += salary;
                departments[currDep].Names.Add(name);
            }

            int count = 0;

            foreach (string dep in allDeps)
            {
                count++;
            }

            string bestDep = string.Empty;

            for (int i = 0; i < count; i++)
            {
                string currDep = allDeps[i];

                if (i == 0)
                {
                    bestDep = currDep;
                }
                else if (departments[currDep].Salary > departments[bestDep].Salary)
                {
                    bestDep = currDep;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDep}");

            foreach (KeyValuePair<string, Employee> kvp in departments
                         .Where(d => d.Key == bestDep)
                         .OrderByDescending(d => d.Value.Salary))
            {
                Console.WriteLine(kvp.Value.Salary);
            }
        }
    }
}
