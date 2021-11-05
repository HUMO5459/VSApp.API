using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models.Base;
using VSApp.Business.Repositories.Base;
using VSApp.Core.Entities.Base;
using VSApp.Core.Repositories.Base;

namespace VSApp.Business.Repositories
{
    public class LogicRepository<T, K> : ILogicRepository<T, K> where T : Entity where K : BaseModel
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;
        private int _userId;

        public LogicRepository(IRepository<T> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        
        int ILogicRepository<T, K>.UserId
        {
            get => _userId;
            set
            {
                _userId = value;
            }
        }

        public async Task<K> AddAsync(K entity)
        {
            var newEntity = _mapper.Map<T>(entity);
            // newEntity
            var result = await _repository.AddAsync(newEntity);
            return _mapper.Map<K>(result);
        }

        public async Task DeleteAsync(K entity)
        {
            var newEntity = _mapper.Map<T>(entity);
            await _repository.DeleteAsync(newEntity);
        }

        public async Task<List<K>> GetAll(bool disableTracking = true)
        {
            var result = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<T>, List<K>>(result);
        }

        public IQueryable<K> GetAllByExp(Expression<Func<K, bool>> predicate, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<K> GetAllByExpInc(Expression<Func<K, bool>> predicate, string[] includeTables, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<K> GetAllByExpIncOrder(Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, string[] includeTables, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<K> GetAllByExpIncOrder(Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<K> GetAllByInc(string[] includeTables, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<K> GetAllByPage(int page, Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, string[] includeTables, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<K> GetAllByPage(int page, Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<K> GetAsync(Expression<Func<K, bool>> predicate, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<K> GetAsync(Expression<Func<K, bool>> predicate, string[] includeTables, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<K> GetByIdAsync(int id, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<K> GetByIdIncAsync(int id, string[] includeTables, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateAsync(K entity)
        {
            var newEntity = _mapper.Map<T>(entity);
            await _repository.UpdateAsync(newEntity);
        }
    }
}
