using DesignPattern.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public IEnumerable<SaleTotalVM> GetTotalSalesByEmployeeId(int id)
        {
            return GetAll().GroupBy(s => new { s.EmployeeID, s.ProductID })
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
