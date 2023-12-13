using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATom.CommonBasics.Extension
{
    public static class IntExtensions
    {
        public static IEnumerable<int> To(this int intFrom, int intTo)
        {
            return Enumerable.Range(intFrom, intTo);
        }
    }
}
