using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.Repositories
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TContext, TEntity> where TEntity : class where TContext : DbContext
    {
        private readonly DbSet<TEntity> _entities;

        public GenericRepository(IUnitOfWork<TContext> unitOfWork)
        {
            _entities = unitOfWork.Context.Set<TEntity>();

        }
        public async Task<TEntity> Delete(TEntity entity)
        {
            TEntity model = await _entities.FindAsync(entity);
            if (model != null)
            {
                _entities.Remove(model);
            }
            return model;
        }
        public void  BulkDelete(IEnumerable<TEntity> entities)
        {
             _entities.RemoveRange(entities);
        }

        public IQueryable<TEntity> Get()
        {
            return _entities;
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }
        public async Task BulkInsert(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public TEntity Update(TEntity entity)
        {
            _entities.Update(entity);
            return entity;
        }
        public void BulkUpdate(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

    }
}
