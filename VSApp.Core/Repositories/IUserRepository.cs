using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities;
using VSApp.Core.Repositories.Base;

namespace VSApp.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(string username, string password);
        Task<User> CreateUser(User user);
    }
}
