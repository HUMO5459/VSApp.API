using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models.Base;

namespace VSApp.Business.Models
{
    public class ServerModel : BaseModel
    {
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string ServerLogin { get; set; }
        public string ServerPassword { get; set; }
    }
}
