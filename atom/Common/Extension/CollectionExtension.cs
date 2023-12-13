using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATom.CommonBasics.Extension { 
    public static class CollectionExtension
    {
        public static Type GetListType<T>(this List<T> _)
        {
            return typeof(T);
        }
    }
}
