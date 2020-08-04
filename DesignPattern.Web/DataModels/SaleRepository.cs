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
        public IEnumerable<Sale> GetTotalSalesByEmployee(int id)
        {
            return GetAll().Where(p => p.EmployeeID == id);
        }
    }
}
