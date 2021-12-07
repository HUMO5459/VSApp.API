using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id, bool disableTracking = true);
        Task<T> GetByIdIncAsync(int id, string[] includeTables, bool disableTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByInc(string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByExpInc(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByExp(Expression<Func<T, bool>> predicate, bool disableTracking = true);
        IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
        IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAllByPage(int page, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
        IQueryable<T> GetAll(bool disableTracking = true);
        IQueryable<T> GetAllByPage(int page, int limit, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
    }
}
