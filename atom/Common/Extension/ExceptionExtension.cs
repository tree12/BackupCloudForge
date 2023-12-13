using System;
using System.Collections.Generic;
using System.Text;

namespace ATom.CommonBasics.Extension
{
    public static class ExceptionExtension
    {
        public static Exception GetMostInnerException(this Exception ex) {
            if (ex.InnerException == null) return ex;
            return GetMostInnerException(ex.InnerException);
        }
    }
}
