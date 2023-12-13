using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess
{
    class EdiConvertException: Exception
    {
        public EdiConvertException(string message) : base(message)
        {

        }
    }
}
