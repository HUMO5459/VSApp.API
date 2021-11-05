using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models.Base;
using VSApp.Core.Entities.Base;

namespace VSApp.Business.Repositories.Base
{
    public interface ILogicRepository<T, K> where T:Entity where K:BaseModel
    {
        int UserId { get; set; }
        Task<K> AddAsync(K entity);
        Task UpdateAsync(K entity);
        Task DeleteAsync(K entity);
        Task<K> GetByIdAsync(int id, bool disableTracking = true);
        Task<K> GetByIdIncAsync(int id, string[] includeTables, bool disableTracking = true);
        Task<K> GetAsync(Expression<Func<K, bool>> predicate, bool disableTracking = true);
        Task<K> GetAsync(Expression<Func<K, bool>> predicate, string[] includeTables, bool disableTracking = true);
        IQueryable<K> GetAllByExpIncOrder(Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, string[] includeTables, bool disableTracking = true);
        IQueryable<K> GetAllByInc(string[] includeTables, bool disableTracking = true);
        IQueryable<K> GetAllByExpInc(Expression<Func<K, bool>> predicate, string[] includeTables, bool disableTracking = true);
        IQueryable<K> GetAllByExp(Expression<Func<K, bool>> predicate, bool disableTracking = true);
        IQueryable<K> GetAllByExpIncOrder(Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, bool disableTracking = true);
        IQueryable<K> GetAllByPage(int page, Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, string[] includeTables, bool disableTracking = true);
        IQueryable<K> GetAllByPage(int page, Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, bool disableTracking = true);
        Task<List<K>> GetAll(bool disableTracking = true);
    }
}
