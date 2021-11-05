using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Entities
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }

    }
}
