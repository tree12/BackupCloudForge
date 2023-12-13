using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyTeam.DarkMagick
{
    public static class BoolExtensions
    {
        public static string ToSqlString(this bool bolValue)
        {
            return Convert.ToInt16(bolValue).ToString();
        }
    }
}
