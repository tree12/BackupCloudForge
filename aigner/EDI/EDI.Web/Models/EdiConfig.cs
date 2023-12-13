using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDI.Web.Models
{
    public class EdiConfig
    {
        public string EdiSecretKey { get; set; }
        public string EcosioUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
