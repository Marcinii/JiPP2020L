using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class KilogramsToPounds : IKonwerter
    {
        public double kg;
        public double lb;
        private double valueToConvert;
        public KilogramsToPounds()
        {
            this.kg = 0;
            this.lb = 0;
            this.valueToConvert = 0;
        }

        public KilogramsToPounds(double valueToConvert)
        {
            this.valueToConvert = valueToConvert;
        }
        public List<string> Units => new List<string>()
        {
            "kg",
            "lb"
        };


        public string Name => "Kilograms To Pounds";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert * 2.2046;
        }


        public string UnitConv(string unitFrom, string unitTo, string number)
        {
            bool success = double.TryParse(number, out double valueToConvert);
            if (!success) { valueToConvert = 0; }
            KilogramsToPounds a = new KilogramsToPounds(valueToConvert);
            if (unitFrom == Units[0] && unitTo == Units[1])
            {
                return a.kg + " kg";
            }
            else if (unitFrom == Units[1] && unitTo == Units[0])
            {
                return a.lb + " lb";
            }
            else { return Error.Info(); }
        }
    }
}
