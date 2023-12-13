using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotSaveAttribute : System.Attribute
    {
    }
}
