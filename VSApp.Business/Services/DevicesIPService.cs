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
    public class DevicesIPService : BaseServices<DevicesIP>, IDevicesIPService
    {
        private readonly IMapper _mapper;

        public DevicesIPService(IRepository<DevicesIP> repository, IMapper mapper) : base (repository)
        {
            this._mapper = mapper;
        }
        public async Task<DevicesIPModel> AddAsync(DevicesIPModel model)
        {
            var entity = _mapper.Map<DevicesIP>(model);
            var newEntity = await _repository.AddAsync(entity);
            var mapped = _mapper.Map<DevicesIPModel>(newEntity);
            return mapped;
        }

        public async Task DeleteAsync(DevicesIPModel model)
        {
            var entity = _mapper.Map<DevicesIP>(model);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<DevicesIPModel>> GetAllAsync()
        {
            List<DevicesIP> devicesIPs = await _repository.GetAll().ToListAsync();
            List<DevicesIPModel> devicesIPModels = _mapper.Map<List<DevicesIPModel>>(devicesIPs);
            return devicesIPModels;
        }

        public async Task<DevicesIPModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<DevicesIPModel>(entity);
        }

        public async Task UpdateAsync(DevicesIPModel model)
        {
            var deviceIP = await _repository.GetByIdAsync(model.Id);
            var entity = _mapper.Map(model, deviceIP);
            await _repository.UpdateAsync(entity);
        }
    }
}
