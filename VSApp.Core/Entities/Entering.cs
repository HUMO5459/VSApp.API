using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Entities
{
    public class Entering : Entity
    {
        public int ClientId { get; set; }
        public DateTime EnteringTime { get; set; }
        public Client Client { get; set; }
    }
}
