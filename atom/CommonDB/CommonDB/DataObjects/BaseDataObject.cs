using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATom.CommonDB.DataObjects
{
    public class BaseDataObject
    {
        
        public State ObjectState { get; set; } = State.New;

        public enum State
        {
            New,
            FromDB            
        }
    }
}
