using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class FluentDP
    {
        public static void Demo()
        {
            var employee = new FluentEmployee()
                .Name("sunny")
                 .DateOfBirth(DateTime.Now)
                 .Department("IT")
                 .Address("Oakville")
                    .Employee;
            Console.WriteLine($"{employee.Name} {employee.Department} {employee.DateOfBirth} {employee.Address}");
        }
    }

    public class FluentEmployee
    {
        public Employee Employee = new Employee();

        public FluentEmployee Name(string value)
        {
            Employee.Name = value;
            return this;
        }
        public FluentEmployee DateOfBirth(DateTime value)
        {
            Employee.DateOfBirth = value;
            return this;
        }
        public FluentEmployee Department(string value)
        {
            Employee.Department = value;
            return this;
        }
        public FluentEmployee Address(string value)
        {
            Employee.Address = value;
            return this;
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
    }

}
