using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Entities
{
    public class Exiting : EntityA
    {
        public DateTime ExitingTime { get; set; }
        public int? ClientId { get; set; }
        [NotMapped]
        public Client Client { get; set; }
    }
}
