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
    public class ExitingService : BaseServices<Exiting>, IExitingService
    {
        private readonly IMapper _mapper;

        public ExitingService(IRepository<Exiting> repository, IMapper mapper) :base(repository)
        {
            this._mapper = mapper;
        }
        public async Task<ExitingModel> AddAsync(ExitingModel model)
        {
            var entity = _mapper.Map<Exiting>(model);
            var newEntity = await _repository.AddAsync(entity);
            var mapped = _mapper.Map<ExitingModel>(newEntity);
            return mapped;
        }

        public async Task DeleteAsync(ExitingModel model)
        {
            var entity = _mapper.Map<Exiting>(model);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<ExitingModel>> GetAllAsync()
        {
            List<Exiting> enterings = await _repository.GetAll().ToListAsync();
            List<ExitingModel> enteringModels = _mapper.Map<List<ExitingModel>>(enterings);
            return enteringModels;
        }

        public async Task<ExitingModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ExitingModel>(entity);
        }

        public async Task UpdateAsync(ExitingModel model)
        {
            var entering = await _repository.GetByIdAsync(model.Id);
            var entity = _mapper.Map(model, entering);
            await _repository.UpdateAsync(entity);
        }
    }
}
