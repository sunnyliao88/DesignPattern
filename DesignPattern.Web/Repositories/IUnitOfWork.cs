using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Web.Repositories
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        TContext Context { get; }
        IGenericRepository<TContext, TEntity> GetGenericRepository<TEntity>() where TEntity : class;
        void CreateTransaction();
        void Commit();
        void Rollback();
    }
}
