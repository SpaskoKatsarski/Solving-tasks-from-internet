using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace T._09
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
            this.Employees = new List<Employee>();
        }

        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }

        public decimal TotalSalaries { get; set; }

        public void AddEmpolee(string employeeName, decimal employeeSalary)
        {
            this.Employees.Add(new Employee(employeeName, employeeSalary));
            this.TotalSalaries += employeeSalary;
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
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                decimal salary = decimal.Parse(info[1]);
                string departmentName = info[2];

                if (!allDepartments.Any(d => d.DepartmentName == departmentName))
                {
                    allDepartments.Add(new Department(departmentName));
                }

                allDepartments.Find(d => d.DepartmentName == departmentName).AddEmpolee(name, salary);
            }

            Department bestDepartment =
                allDepartments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
