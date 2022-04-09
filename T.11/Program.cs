using System;
using System.Collections.Generic;
using System.Linq;

namespace T._11
{
    class Student
    {
        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Dictionary<string, int> ContestsResults { get; set; } = new Dictionary<string, int>();

        public int TotalPoints { get; set; }

        public void AddPoints(string contest, int pointsToAdd)
        {
            if (ContestsResults[contest] < pointsToAdd)
            {
                ContestsResults[contest] = pointsToAdd;
                this.TotalPoints += pointsToAdd;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                contests.Add(contestInfo[0], contestInfo[1]);
            }

            List<Student> allStudents = new List<Student>();

            string command;
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                // {contest}=>{password}=>{username}=>{points}
                string[] cmdArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string currentContest = cmdArgs[0];
                string currentPassword = cmdArgs[1];
                string username = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (points < 0)
                {
                    continue;
                }

                if (contests.ContainsKey(currentContest))
                {
                    if (contests[currentContest] == currentPassword)
                    {
                        if (!allStudents.Any(s => s.Name == username))
                        {
                            allStudents.Add(new Student(username));
                        }

                        Student currStudent = allStudents.Find(s => s.Name == username);

                        if (!currStudent.ContestsResults.ContainsKey(currentContest))
                        {
                            currStudent.ContestsResults.Add(currentContest, 0);
                        }

                        currStudent.AddPoints(currentContest, points);
                    }
                }
            }

            Student bestStudent = allStudents.OrderByDescending(s => s.TotalPoints).First();

            Console.WriteLine($"Best candidate is {bestStudent.Name} with total {bestStudent.TotalPoints} points.");

            Console.WriteLine("Ranking:");

            foreach (Student student in allStudents.OrderBy(s => s.Name))
            {
                Console.WriteLine(student.Name);

                foreach (KeyValuePair<string, int> kvp in student.ContestsResults.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
