using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.Repositories
{
    public interface IGenericRepository<TContext, TEntity> where TEntity : class where TContext : DbContext
    {
        IQueryable<TEntity> Get();
        Task<TEntity> Insert(TEntity entity);
        Task BulkInsert(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void BulkUpdate(IEnumerable<TEntity> entities);
        Task<TEntity> Delete(TEntity entity);
        void BulkDelete(IEnumerable<TEntity> entities);

    }
}
