using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public interface ISaleRepository: IGenericRepository<Sale>
    {
        IEnumerable<Sale> GetTotalSalesByEmployee(int id);
    }
}
