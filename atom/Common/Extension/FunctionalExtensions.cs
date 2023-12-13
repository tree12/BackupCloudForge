using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATom.CommonBasics.Extension
{
    public static class FunctionalExtensions
    {
        public static Func<T2> Curry<T1, T2>(this Func<T1, T2> fnThis, T1 objParam1)
        {
            return () => fnThis(objParam1);
        }

        public static Func<T3> Curry<T1, T2, T3>(this Func<T1, T2, T3> fnThis, T1 objParam1, T2 objParam2)
        {
            return () => fnThis(objParam1, objParam2);
        }
        public static Func<T2, T3> Curry<T1, T2, T3>(this Func<T1, T2, T3> objThis, T1 objParam1)
        {
            return (T2 objParam2) => objThis(objParam1, objParam2);
        }

        public static Func<T4> Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> fnThis, T1 objParam1, T2 objParam2, T3 objParam3)
        {
            return () => fnThis(objParam1, objParam2, objParam3);
        }
        public static Func<T3, T4> Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> objThis, T1 objParam1, T2 objParam2)
        {
            return (T3 objParam3) => objThis(objParam1, objParam2, objParam3);
        }
        public static Func<T2, T3, T4> Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> objThis, T1 objParam1)
        {
            return (T2 objParam2, T3 objParam3) => objThis(objParam1, objParam2, objParam3);
        }

        public static Func<T5> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> fnThis, T1 objParam1, T2 objParam2, T3 objParam3, T4 objParam4)
        {
            return () => fnThis(objParam1, objParam2, objParam3, objParam4);
        }
        public static Func<T4, T5> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> objThis, T1 objParam1, T2 objParam2, T3 objParam3)
        {
            return (T4 objParam4) => objThis(objParam1, objParam2, objParam3, objParam4);
        }
        public static Func<T3, T4, T5> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> objThis, T1 objParam1, T2 objParam2)
        {
            return (T3 objParam3, T4 objParam4) => objThis(objParam1, objParam2, objParam3, objParam4);
        }
        public static Func<T2, T3, T4, T5> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> objThis, T1 objParam1)
        {
            return (T2 objParam2, T3 objParam3, T4 objParam4) => objThis(objParam1, objParam2, objParam3, objParam4);
        }

        public static Action Curry<T1>(this Action<T1> fnThis, T1 objParam1)
        {
            return () => fnThis(objParam1);
        }

        public static Action Curry<T1, T2>(this Action<T1, T2> fnThis, T1 objParam1, T2 objParam2)
        {
            return () => fnThis(objParam1, objParam2);
        }
        public static Action<T2> Curry<T1, T2>(this Action<T1, T2> objThis, T1 objParam1)
        {
            return (T2 objParam2) => objThis(objParam1, objParam2);
        }

        public static Action Curry<T1, T2, T3>(this Action<T1, T2, T3> fnThis, T1 objParam1, T2 objParam2, T3 objParam3)
        {
            return () => fnThis(objParam1, objParam2, objParam3);
        }
        public static Action<T3> Curry<T1, T2, T3>(this Action<T1, T2, T3> objThis, T1 objParam1, T2 objParam2)
        {
            return (T3 objParam3) => objThis(objParam1, objParam2, objParam3);
        }
        public static Action<T2, T3> Curry<T1, T2, T3>(this Action<T1, T2, T3> objThis, T1 objParam1)
        {
            return (T2 objParam2, T3 objParam3) => objThis(objParam1, objParam2, objParam3);
        }

        public static Action Curry<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4> fnThis, T1 objParam1, T2 objParam2, T3 objParam3, T4 objParam4)
        {
            return () => fnThis(objParam1, objParam2, objParam3, objParam4);
        }
        public static Action<T4> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> objThis, T1 objParam1, T2 objParam2, T3 objParam3)
        {
            return (T4 objParam4) => objThis(objParam1, objParam2, objParam3, objParam4);
        }
        public static Action<T3, T4> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> objThis, T1 objParam1, T2 objParam2)
        {
            return (T3 objParam3, T4 objParam4) => objThis(objParam1, objParam2, objParam3, objParam4);
        }
        public static Action<T2, T3, T4> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> objThis, T1 objParam1)
        {
            return (T2 objParam2, T3 objParam3, T4 objParam4) => objThis(objParam1, objParam2, objParam3, objParam4);
        }
    }
}
