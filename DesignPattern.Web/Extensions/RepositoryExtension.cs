using DesignPattern.Web.DataModels;
using DesignPattern.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.Extensions
{
    public static class RepositoryExtension
    {
        public static IEnumerable<SaleTotalVM> GetTotalSalesByEmployeeId(this IEnumerable<Sale> sales, int id)
        {
            return sales.GroupBy(s => new { s.EmployeeID, s.ProductID })
                .Select(g =>
                            new SaleTotalVM
                            {
                                EmployeeID = g.Key.EmployeeID,
                                ProductID = g.Key.ProductID,
                                Total = g.Sum(c => c.Count)
                            }
                    )
                    .Where(r => r.EmployeeID == id);
        }
    }
}
