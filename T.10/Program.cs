using System;
using System.Collections.Generic;
using System.Linq;

namespace T._10
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string nameOfPerson = personInfo[0];
                int age = int.Parse(personInfo[1]);

                allPeople.Add(new Person(nameOfPerson, age));
            }

            Person oldestPerson = allPeople.OrderByDescending(p => p.Age).First();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
