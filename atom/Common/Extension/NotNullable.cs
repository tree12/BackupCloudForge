using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyTeam.DarkMagick
{
    public class NotNullable<T> where T : class
    {
        private readonly T objInstance;

        public NotNullable(T objValue)
        {
            if (objValue == null)
                throw new ArgumentNullException("objValue", "objValue darf nicht NULL sein.");

            this.objInstance = objValue;
        }

        public T Value
        {
            get { return this.objInstance; }
        }

        public override bool Equals(object obj)
        {
            return this.objInstance.Equals(obj);
        }
        public bool Equals(NotNullable<T> obj)
        {
            return this.objInstance.Equals(obj.objInstance);
        }
        public override int GetHashCode()
        {
            return this.objInstance.GetHashCode();
        }
        public override string ToString()
        {
            return this.objInstance.ToString();
        }

        public static bool operator ==(NotNullable<T> obj1, NotNullable<T> obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(NotNullable<T> obj1, NotNullable<T> obj2)
        {
            return !obj1.Equals(obj2);
        }

        public static implicit operator T(NotNullable<T> obj)
        {
            return obj.Value;
        }
        public static implicit operator NotNullable<T>(T obj)
        {
            return new NotNullable<T>(obj);
        }
    }
}
