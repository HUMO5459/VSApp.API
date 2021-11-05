using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSApp.Business.Models
{
    public class ExceptionModel
    {
        public ExceptionModel(object message, int statusCode = 500)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; set; }
        public object Message { get; set; }
    }
}
