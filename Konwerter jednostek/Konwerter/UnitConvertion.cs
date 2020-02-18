using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class UnitConvertion
    {
        public static double celToFahr(double cel)
        {
            return (2 * (cel - 0.1*cel)) + 32;
        }
        public static double fahrToCel(double fahr)
        {
            return ((fahr - 32) / 2) * 1.1;
        }
        public static double kmToMile(double km)
        {
            return km / 1.609;
        }
        public static double mileToKm(double mile)
        {
            return mile * 1.609;
        }
        public static double poundToKg(double pound)
        {
            return pound * 0.4535;
        }
        public static double kgToPound(double kg)
        {
            return kg / 0.4535;
        }
    }
}
