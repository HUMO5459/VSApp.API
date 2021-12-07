using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSApp.Business.Interfaces;
using VSApp.Business.Models;
using VSApp.Core.Entities;
using VSApp.Core.Repositories.Base;

namespace VSApp.Business.Services
{
    public class ServerService : BaseServices<Server>, IServerService
    {
        private readonly IMapper _mapper;

        public ServerService(IRepository<Server> repository, IMapper mapper) : base (repository)
        {
            this._mapper = mapper;
        }
        public async Task<ServerModel> AddAsync(ServerModel model)
        {
            var entity = _mapper.Map<Server>(model);
            var newEntity = await _repository.AddAsync(entity);
            var mapped = _mapper.Map<ServerModel>(newEntity);
            return mapped;
        }

        public async Task DeleteAsync(ServerModel model)
        {
            var entity = _mapper.Map<Server>(model);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<ServerModel>> GetAllAsync()
        {
            List<Server> devicesIPs = await _repository.GetAll().ToListAsync();
            List<ServerModel> devicesIPModels = _mapper.Map<List<ServerModel>>(devicesIPs);
            return devicesIPModels;
        }

        public async Task<ServerModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ServerModel>(entity);
        }

        public async Task UpdateAsync(ServerModel model)
        {
            var deviceIP = await _repository.GetByIdAsync(model.Id);
            var entity = _mapper.Map(model, deviceIP);
            await _repository.UpdateAsync(entity);
        }
    }
}
