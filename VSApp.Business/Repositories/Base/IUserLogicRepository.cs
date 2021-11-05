using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models;
using VSApp.Core.Entities;

namespace VSApp.Business.Repositories.Base
{
    public interface IUserLogicRepository : ILogicRepository<User, UserModel>
    {
        Task<User> GetUser(string username, string password);
        Task<UserModel> CreateUser(UserModel user);
    }
}
