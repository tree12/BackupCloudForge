using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATom.CommonDB.DataObjects
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute:Attribute
    {
    }
}
