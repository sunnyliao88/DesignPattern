using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<Employee> GetByName(string name)
        {
            return Task.FromResult<Employee>(_table.FirstOrDefault(e => e.Name == name));
        }
    }
}
