using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Interfaces;
using VSApp.Business.Models;
using VSApp.Business.Services;
using VSApp.Core.Entities;
using VSApp.Core.Repositories.Base;

namespace VSApp.Business.Services
{
    public class ClientService : BaseServices<Client>, IClientService
    {
        private readonly IMapper _mapper;
        public ClientService(IRepository<Client> repository, IMapper mapper) : base (repository)
        {
            this._mapper = mapper;
        }
        public async Task<ClientModel> AddAsync(ClientModel model)
        {
            var entity = _mapper.Map<Client>(model);
            var newEntity = await _repository.AddAsync(entity);
            var mapped = _mapper.Map<ClientModel>(newEntity);
            return mapped;
        }

        public async Task DeleteAsync(ClientModel model)
        {
            var entity = _mapper.Map<Client>(model);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<ClientModel>> GetAllAsync()
        {
            List<Client> clients = await _repository.GetAll().ToListAsync();
            List<ClientModel> clientModels = _mapper.Map<List<ClientModel>>(clients);
            return clientModels;
        }

        public async Task<ClientModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClientModel>(entity);
        }

        public async Task UpdateAsync(ClientModel model)
        {
            var client = await _repository.GetByIdAsync(model.Id);
            var entity = _mapper.Map(model, client);
            await _repository.UpdateAsync(entity);
        }
    }
}
