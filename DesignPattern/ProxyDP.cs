using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class ProxyDP
    {
        public static void Demo()
        {
            ProxyDPEmployee employee1 = new ProxyDPEmployee()
            {
                Username = "sunny",
                Role = "manager"
            };
            ProxyDPEmployee employee2 = new ProxyDPEmployee()
            {
                Username = "sunny",
                Role = "developer"
            };

            EmployeesSalaryProxy proxy1 = new EmployeesSalaryProxy(employee1);
            proxy1.GetEmployeesSalary();
            EmployeesSalaryProxy proxy2 = new EmployeesSalaryProxy(employee2);
            proxy2.GetEmployeesSalary();
          
        }
    }

    public class ProxyDPEmployee
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }
    interface IEmployeesSalary
    {
        Dictionary<string, double> GetEmployeesSalary();
    }

    public class EmployeesSalaryProxy : IEmployeesSalary
    {
        private readonly ProxyDPEmployee _employee;

        public EmployeesSalaryProxy(ProxyDPEmployee employee)
        {
            _employee = employee;

        }
        public Dictionary<string, double> GetEmployeesSalary()
        {

            if (_employee.Role.ToUpper() == "manager".ToUpper())
            {
                Console.WriteLine("Successed");
                EmployeesSalary employeesSalary = new EmployeesSalary(this);
                return employeesSalary.GetEmployeesSalary();
            }
            else
            {
                Console.WriteLine("Failed: can not access");
                return null;
            }

        }
    }
    public class EmployeesSalary : IEmployeesSalary
    {
        public EmployeesSalary(EmployeesSalaryProxy employeesSalaryProxy)
        {
        }

        Dictionary<string, double> _employeesSalary = new Dictionary<string, double>
        {
             {"Joge",100},
             {"Marie",98},
             {"Max",97},
       };

        public Dictionary<string, double> GetEmployeesSalary()
        {           
            return _employeesSalary;
        }
    }
}
