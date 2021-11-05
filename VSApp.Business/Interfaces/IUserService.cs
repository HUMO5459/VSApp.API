using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Interfaces.Base;
using VSApp.Business.Models;
using VSApp.Core.Repositories;

namespace VSApp.Business.Interfaces
{
    public interface IUserService
    {
        Task<LoginTokenModel> Login(UserLoginModel userLoginModel);
        Task<UserModel> Register(UserModel userModel);
        Task UpdateAsync(UserModel user);
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> AddAsync(UserModel user);
        Task<UserModel> DeleteAsync(int id);

 //       Task<UserModel> Activate(ActivateUserModel userModel);
 //       Task AccessUser(List<UserAccessModel> controlUserModels);
 //        Task<UserInfoModel> UsersInfo(int id);
 //       Task<List<string>> GetAllPermissions(int id);
 //       Task<List<string>> GetAllPermissions(int id, int companyId);
    }
}
