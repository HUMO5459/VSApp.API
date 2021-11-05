using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Interfaces;
using VSApp.Business.Models;
using VSApp.Core.Entities;
using VSApp.Core.Repositories.Base;

namespace VSApp.Business.Services
{
    public class EnteringService : BaseServices<Entering>, IEnteringService
    {
        private readonly IMapper _mapper;

        public EnteringService(IRepository<Entering> repository, IMapper mapper) : base (repository)
        {
            this._mapper = mapper;
        }
        public async Task<EnteringModel> AddAsync(EnteringModel model)
        {
            var entity = _mapper.Map<Entering>(model);
            var newEntity = await _repository.AddAsync(entity);
            var mapped = _mapper.Map<EnteringModel>(newEntity);
            return mapped;
        }

        public async Task DeleteAsync(EnteringModel model)
        {
            var entity = _mapper.Map<Entering>(model);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<EnteringModel>> GetAllAsync()
        {
            List<Entering> enterings = await _repository.GetAll().ToListAsync();
            List<EnteringModel> enteringModels = _mapper.Map<List<EnteringModel>>(enterings);
            return enteringModels;
        }

        public async Task<EnteringModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<EnteringModel>(entity);
        }

        public async Task UpdateAsync(EnteringModel model)
        {
            var entering = await _repository.GetByIdAsync(model.Id);
            var entity = _mapper.Map(model, entering);
            await _repository.UpdateAsync(entity);
        }
    }
}
