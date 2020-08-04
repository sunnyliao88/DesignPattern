using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetByName(string name);
    }
}
