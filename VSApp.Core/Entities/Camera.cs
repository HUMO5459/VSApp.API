using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities.Base;

namespace VSApp.Core.Entities
{
    public class Camera : Entity
    {
        public int UserId { get; set; }
        public string CamIP { get; set; }
        public string CamPort { get; set; }
        public string CamLogin { get; set; }
        public string CamPassword { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}
