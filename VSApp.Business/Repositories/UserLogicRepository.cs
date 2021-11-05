using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models;
using VSApp.Business.Repositories.Base;
using VSApp.Core.Entities;
using VSApp.Core.Repositories.Base;

namespace VSApp.Business.Repositories
{
    public class UserLogicRepository : LogicRepository<User, UserModel>, IUserLogicRepository
    {

        public UserLogicRepository(IRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {

        }
        public Task<UserModel> CreateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
