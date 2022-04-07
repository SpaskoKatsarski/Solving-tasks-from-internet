using System;
using System.Collections.Generic;

namespace T._07
{
    internal class Employee
    {
        public Employee(decimal salary)
        {
            this.Names = new List<string>();
            this.Salary = salary;
        }

        public List<string> Names { get; set; }

        public decimal Salary { get; set; }
    }
}
