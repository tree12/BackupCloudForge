using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATom.CommonBasics.Extension
{
    public static class FloatExtension
    {
        public static bool EqualsWithDelta(this float fltThis, float fltOther, float fltDelta)
        {
            if (fltDelta <= 0)
                throw new ArgumentOutOfRangeException("fltDelta", "Das Delta muss größer als 0 sein.");
            
            return (Math.Abs(fltThis - fltOther) <= fltDelta);
        }
        public static bool EqualsWithDelta(this double dblThis, double dblOther, double dblDelta)
        {
            if (dblDelta <= 0)
                throw new ArgumentOutOfRangeException("fltDelta", "Das Delta muss größer als 0 sein.");

            return (Math.Abs(dblThis - dblOther) <= dblDelta);
        }

        public static bool EqualsWithDelta(this decimal dblThis, decimal dblOther, decimal dblDelta)
        {
            if (dblDelta <= 0)
                throw new ArgumentOutOfRangeException("fltDelta", "Das Delta muss größer als 0 sein.");

            return (Math.Abs(dblThis - dblOther) <= dblDelta);
        }
    }
}
