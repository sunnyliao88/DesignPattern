using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Dept { get; set; }

        //public Nullable<int> ProductID { get; set; }
        //public Nullable<int> Quantity { get; set; }
    }
}
