using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public static class EdiExtensions
    {
        public static DateTime asDateTime(this S004 soo4)
        {
            return DateTime.ParseExact(soo4.Date_1 + soo4.Time_2,"yyMMddHHmm", CultureInfo.InvariantCulture);
        }
        public static DateTime asDateTime(this EdiFabric.Templates.EdifactD96A.C507 c507)
        {
            return DateTime.ParseExact(c507.Datetimeperiod_02, "yyyyMMdd", CultureInfo.InvariantCulture);
        }
    }
}
