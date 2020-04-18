using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{

    public class MilesToKilometres : IKonwerter
    {
        public double mil;
        public double km;
        private double valueToConvert;
        public MilesToKilometres()
        {
            this.mil = 0;
            this.km = 0;
            this.valueToConvert = 0;
        }

        public MilesToKilometres(double valueToConvert)
        {
            this.valueToConvert = valueToConvert;
        }
        public List<string> Units => new List<string>()
        {
            "mil",
            "km"
        };

        public string Name => "Miles To Kilometres";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert / 0.62137;
        }

        public string UnitConv(string unitFrom, string unitTo, string number)
        {

            bool success = double.TryParse(number, out double valueToConvert);
            if (!success) { valueToConvert = 0; }
            MilesToKilometres a = new MilesToKilometres(valueToConvert);
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
