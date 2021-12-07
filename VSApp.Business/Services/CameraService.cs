using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Interfaces.Base;
using VSApp.Business.Models;
using VSApp.Business.Models.CameraModels;
using VSApp.Core.Entities;
using VSApp.Core.Repositories.Base;

namespace VSApp.Business.Services
{
    public class CameraService : BaseServices<Camera>, ICameraService
    {
        private readonly IMapper _mapper;

        public CameraService(IRepository<Camera> repository, IMapper mapper) : base(repository)
        {
            this._mapper = mapper;
        }

        public async Task<CameraModel> AddAsync(CameraModel model)
        {
            var entity = _mapper.Map<Camera>(model);
            var newEntity = await _repository.AddAsync(entity);
            var mapped = _mapper.Map<CameraModel>(newEntity);
            return mapped;
        }

        public async Task DeleteAsync(CameraModel model)
        {
            var entity = _mapper.Map<Camera>(model);
            await _repository.DeleteAsync(entity); 
        }

        public async Task<List<CameraModel>> GetAllAsync()
        {
            List<Camera> cameras = await _repository.GetAll().ToListAsync();
            List<CameraModel> cameraModels = _mapper.Map<List<CameraModel>>(cameras);
            return cameraModels;
        }

        public async Task<CameraModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CameraModel>(entity);
        }

        public async Task UpdateAsync(CameraModel model)
        {
            var camera = await _repository.GetByIdAsync(model.Id);
            var entity = _mapper.Map(model, camera);
            await _repository.UpdateAsync(entity);
        }
    }
}
