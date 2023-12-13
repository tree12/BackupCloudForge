using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATom.CommonDB.DataObjects
{    
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute:Attribute
    {
        public FieldAttribute(DBColType colType=DBColType.Default, int size=0)
        {
            ColType = colType;
            Size = size;
        }



        public int Size { get; set; }

        public DBColType ColType { get; set; }

        public enum DBColType {
            Default,
            Text
        }
    }
}
