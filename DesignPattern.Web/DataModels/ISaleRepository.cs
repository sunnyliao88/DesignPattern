using DesignPattern.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public interface ISaleRepository: IGenericRepository<Sale>
    {
        IEnumerable<SaleTotalVM> GetTotalSalesByEmployeeId(int id);
    }
}
