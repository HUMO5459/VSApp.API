using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
