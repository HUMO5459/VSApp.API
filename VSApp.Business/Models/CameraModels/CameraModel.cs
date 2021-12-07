using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models.Base;

namespace VSApp.Business.Models.CameraModels
{
    public class CameraModel : BaseModel
    {   
        public string CamIP { get; set; }
        public string CamPort { get; set; }
        public string CamLogin { get; set; }
        public string CamPassword { get; set; }
    }
}
