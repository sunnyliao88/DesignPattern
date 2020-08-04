using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Web.DataModels
{
  public  interface IGenericRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(object id);
        Task Insert(T employee);
        Task Update(T employee);
        Task Delete(object id);
    }
}
