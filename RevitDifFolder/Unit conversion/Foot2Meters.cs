using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_conversion;
namespace Unit_conversion
{
//#define f2m 0.3048m 不对 但是我不知道为啥

    public static class FootAndMeterTrans
    {
        public static decimal Foot2Meter(decimal value)
        {
            return value * 0.3048m;
        }
            
        public static decimal Meter2Foot(decimal value)
        {
            return value / 0.3048m;
        }
    }
}
