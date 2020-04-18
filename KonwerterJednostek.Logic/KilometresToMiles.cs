using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class KilometresToMiles : IKonwerter
    {
        public double mil;
        public double km;
        private double valueToConvert;
        public KilometresToMiles()
        {
            this.km = 0;
            this.mil = 0;
            this.valueToConvert = 0;
        }

        public KilometresToMiles(double valueToConvert)
        {
            this.valueToConvert = valueToConvert;
        }
        public List<string> Units => new List<string>()
        {
            "km",
            "mil"
        };

        public string Name => "Kilometres To Miles";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert *0.62137;
        }

        public string UnitConv(string unitFrom, string unitTo, string number)
        {

                bool success = double.TryParse(number, out double valueToConvert);
                if (!success) { valueToConvert = 0; }
            KilometresToMiles a = new KilometresToMiles(valueToConvert);
                if (unitFrom == Units[0] && unitTo == Units[1])
                {
                    return a.km + " km";
                }
                else if (unitFrom == Units[1] && unitTo == Units[0])
                {
                    return a.mil + " mil";
                }
                else { return Error.Info(); }
            }
    }
}
