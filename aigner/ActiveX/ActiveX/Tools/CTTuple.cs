using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AignerDLL.Tools
{
    [Serializable]
    public class CTTuple<T1, T2>
    {
        public CTTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        protected bool Equals(CTTuple<T1, T2> other)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CTTuple<T1, T2>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T1>.Default.GetHashCode(Item1) * 397) ^ EqualityComparer<T2>.Default.GetHashCode(Item2);
            }
        }

        public static bool operator ==(CTTuple<T1, T2> left, CTTuple<T1, T2> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CTTuple<T1, T2> left, CTTuple<T1, T2> right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class CTTuple<T1, T2, T3>
    {
        public CTTuple(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public T3 Item3 { get; set; }

        protected bool Equals(CTTuple<T1, T2, T3> other)
        {
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(Item3, other.Item3);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CTTuple<T1, T2, T3>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EqualityComparer<T1>.Default.GetHashCode(Item1);
                hashCode = (hashCode * 397) ^ EqualityComparer<T2>.Default.GetHashCode(Item2);
                hashCode = (hashCode * 397) ^ EqualityComparer<T3>.Default.GetHashCode(Item3);
                return hashCode;
            }
        }

        public static bool operator ==(CTTuple<T1, T2, T3> left, CTTuple<T1, T2, T3> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CTTuple<T1, T2, T3> left, CTTuple<T1, T2, T3> right)
        {
            return !Equals(left, right);
        }
    }
}
