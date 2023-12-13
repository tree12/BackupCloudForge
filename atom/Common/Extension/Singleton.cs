using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyTeam.DarkMagick
{
    public static class Singleton<T> where T : class, new()
    {
        private static readonly T objInstance;

        static Singleton()
        {
            objInstance = new T();
        }

        public static T Instance
        {
            get { return objInstance; }
        }
    }
}
