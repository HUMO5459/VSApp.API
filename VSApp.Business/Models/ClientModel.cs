using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models.Base;

namespace VSApp.Business.Models
{
    public class ClientModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
