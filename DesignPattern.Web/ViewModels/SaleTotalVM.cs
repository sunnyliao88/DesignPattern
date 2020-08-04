using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.ViewModels
{
    public class SaleTotalVM
    {
        public int ProductID { get; set; }
        public int EmployeeID { get; set; }
        public int Total { get; set; }
    }
}
