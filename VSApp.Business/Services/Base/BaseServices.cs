using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;
using VSApp.Core.Repositories.Base;

namespace VSApp.Business.Services
{
    public abstract class BaseServices<T> where T : Entity
    {
        public readonly IRepository<T> _repository;

        protected BaseServices(IRepository<T> repository)
        {
            this._repository = repository;
        }
    }
}
