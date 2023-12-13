using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EDI.Web
{

    public class ValidateException: Exception
    {
        public ValidateException()
        {
        }

        protected ValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValidateException(string? message) : base(message)
        {
        }

        public ValidateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

}
