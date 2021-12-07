using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSApp.Core.Entities.Base
{
    public class EntityA : Entity
    {
        public int CreatedUserId { get; set; }
        private int _updateUserId { get; set; }
        public int UpdatedUserId
        {
            set
            {
                _updateUserId = value;
            }
            get
            {
                return (_updateUserId == 0 && this.CreatedUserId != 0) ? CreatedUserId : _updateUserId;
            }
        }

        
        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }
    }
}
