using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models.Base;

namespace VSApp.Business.Interfaces.Base
{
    public interface IBaseService<T> where T : BaseModel
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(T model);
    }
}
