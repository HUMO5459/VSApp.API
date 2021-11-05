using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models.Base;

namespace VSApp.Business.Models
{
    class ShowDataModels: BaseModel
    {
        public int ClientId { get; set; }
        public int EnteringId { get; set; }
        public int ExitingId { get; set; }
        public ClientModel ClientModel { get; set; }
        public EnteringModel EnteringModel { get; set; }
        public ExitingModel ExitingModel { get; set; }
    }
}
