using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Helpers;
using VSApp.Business.Interfaces;
using VSApp.Business.Interfaces.Base;
using VSApp.Business.Models;
using VSApp.Business.Settings;
using VSApp.Core.Entities;
using VSApp.Core.Repositories;

namespace VSApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly TokenHelper _tokenHelper;
        private readonly TokenSetting _tokenSetting;

        public UserService(IUserRepository userRepository, 
                           IMapper mapper,
                           IOptions<TokenSetting> tokenSetting)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._tokenSetting = tokenSetting.Value;
            this._tokenHelper = new TokenHelper(_tokenSetting);
        }
        public async Task<UserModel> AddAsync(UserModel user)
        {
            var entity = _mapper.Map<User>(user);
            var newEntity = await _userRepository.AddAsync(entity);
            return _mapper.Map<UserModel>(newEntity);
        }

        public async Task<UserModel> DeleteAsync(int id)
        {
            var userModel = await _userRepository.GetByIdAsync(id);
            if(userModel == null)
            {
                throw new Exception("User Not Found");
            }
            var entity = _mapper.Map<User>(userModel);
            await _userRepository.DeleteAsync(entity);
            return _mapper.Map<UserModel>(userModel);
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var entityList = await _userRepository.GetAll().ToListAsync();
            return _mapper.Map<List<User>, List<UserModel>>(entityList);
        }

        public Task<List<string>> GetAllPermissions(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAllPermissions(int id, int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetAllByExp(s => s.Id == id).FirstOrDefaultAsync();
            var mapped = _mapper.Map<UserModel>(user);
            return mapped;
        }

        public async Task<LoginTokenModel> Login(UserLoginModel userLoginModel)
        {
            var user = await _userRepository.GetUser(userLoginModel.UserName, userLoginModel.Password);
            if(user != null)
            {
                var mapped = _mapper.Map<UserModel>(user);
                if(mapped == null)
                {
                    throw new Exception($"Entity could not be mapped");
                }
                LoginTokenModel loginTokenModel = _tokenHelper.CreateToken(mapped);
                return loginTokenModel;
            }
            return null;
        }

        public async Task<UserModel> Register(UserModel userModel)
        {
            var userExists = await _userRepository.GetUser(userModel.UserName, userModel.Password);

            if (userExists != null)
                throw new ApplicationException("User already exists!");
            var user = _mapper.Map<User>(userModel);
            if (user == null)
                throw new Exception($"Entity could not be mapped.");
            var result = await _userRepository.CreateUser(user);
            if (result == null)
                throw new ApplicationException("User creation failed! Please check user details and try again");

            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateAsync(UserModel user)
        {
            var entity = _mapper.Map<User>(user);
            await _userRepository.UpdateAsync(entity);
        }
    }
}
