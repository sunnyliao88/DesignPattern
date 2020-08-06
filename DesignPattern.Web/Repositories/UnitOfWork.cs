using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DesignPattern.Web.Repositories
{
    public class UnitOfWork<TContext> :IUnitOfWork<TContext> where TContext : DbContext
    {
        public TContext Context { get; private set; }
        IDbContextTransaction _transaction;

        public UnitOfWork(TContext dbContext)
        {
            Context = dbContext;
        }

        public IGenericRepository<TContext,TEntity> GetGenericRepository<TEntity>() where TEntity : class
        {         
            return new GenericRepository<TContext,TEntity>(this);
        }

        public void Commit()
        {
            Context.SaveChanges();
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public void CreateTransaction()
        {
            _transaction= Context.Database.BeginTransaction();
           
        }

        public void Rollback()
        {
            _transaction.Rollback();           
        }
      
    }
}
