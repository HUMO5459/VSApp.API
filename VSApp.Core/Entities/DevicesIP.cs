using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Entities
{
    public class DevicesIP : Entity
    {
        public int UserId { get; set; }
        public int MCP_IP { get; set; }
        public string MCP_Login { get; set; }
        public string MCP_Password { get; set; }
        public int Cam_IP { get; set; }
        public int Cam_Login { get; set; }
        public int Cam_Password { get; set; }
        public User User { get; set; }
    }
}
