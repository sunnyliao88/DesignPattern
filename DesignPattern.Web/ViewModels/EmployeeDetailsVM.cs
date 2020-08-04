using DesignPattern.Web.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.ViewModels
{
    public class EmployeeDetailsVM
    {
        public Employee Employee { get; set; }   
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
    }
}
