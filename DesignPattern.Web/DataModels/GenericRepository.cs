using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        protected DbSet<T> _table;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _table = _appDbContext.Set<T>();
        }
        public async Task Delete(object id)
        {
            T employee = await GetById(id);
            _table.Remove(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {          
            return _appDbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(object id)
        {

            return await _table.FindAsync(id);
        }

        public async Task Insert(T employee)
        {
            await _table.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(T employee)
        {
            _table.Update(employee);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
