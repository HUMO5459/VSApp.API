using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Entities
{
    public class Server : Entity
    {
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string ServerLogin { get; set; }
        public string ServerPassword { get; set; }

    }
}
