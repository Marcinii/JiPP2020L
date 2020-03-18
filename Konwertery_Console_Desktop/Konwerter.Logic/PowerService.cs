using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PowerService
    {
        public static double fromWatToKm(double value) { return value / 735.5; }
        public static double fromKmToWat(double value) { return value * 735.5; }
    }
}
