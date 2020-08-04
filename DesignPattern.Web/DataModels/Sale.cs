using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public class Sale
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime SaleData { get; set; }
        public int Count { get; set; }
    }
}
