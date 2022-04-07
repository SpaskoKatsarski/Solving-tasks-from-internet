using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace T._08
{
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }
    }

    class Department
    {
        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }

        public string DepartmentName { get; set; }

        public List<Employee> ListOfEmployees { get; set; } = new List<Employee>();

        public decimal TotalSalaries { get; set; }

        public void AddEmployee(string name, decimal salary)
        {
            this.TotalSalaries += salary;
            this.ListOfEmployees.Add(new Employee(name, salary));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> allDepartments = new List<Department>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = arguments[0];
                decimal salary = decimal.Parse(arguments[1]);
                string departmentName = arguments[2];

                if (!allDepartments.Any(x => x.DepartmentName == departmentName))
                {
                    allDepartments.Add(new Department(departmentName));
                }

                allDepartments.Find(x => x.DepartmentName == departmentName)
                    .AddEmployee(name, salary);
            }

            Department bestDepartment = allDepartments.OrderByDescending(x => x.TotalSalaries / x.ListOfEmployees.Count)
                .First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (Employee employee in bestDepartment.ListOfEmployees.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
