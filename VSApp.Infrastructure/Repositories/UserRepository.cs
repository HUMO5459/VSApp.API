using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities;
using VSApp.Core.Repositories;
using VSApp.Infrastructure.Data;
using VSApp.Infrastructure.Repositories.Base;

namespace VSApp.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDataContext dataContext) : base(dataContext)
        {

        }
        public async Task<User> CreateUser(User user)
        {
            var newUser = await AddAsync(user);
            return newUser;
        }

        public async Task<User> GetUser(string username, string password)
        {
            return  GetAllByExp(s => s.UserName == username && s.Password == password).FirstOrDefault();
        }
    }
}
