using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
public class FahrenheitToCelcius : IKonwerter
    {
        public double c;
        public double f;
        private double valueToConvert;
        public FahrenheitToCelcius()
        {
            this.c = 0;
            this.f = 0;
            this.valueToConvert = 0;
        }

        public FahrenheitToCelcius(double valueToConvert)
        {
            this.valueToConvert = valueToConvert;
        }
        public List<string> Units => new List<string>()
        {
            "C",
            "F"
        };

        public string Name => "Fahrenheit To Celcius";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return (valueToConvert - 32)*1.8;
        }

        public string UnitConv(string unitFrom, string unitTo, string number)
        {
            bool success = double.TryParse(number, out double valueToConvert);
            if (!success) { valueToConvert = 0; }
            FahrenheitToCelcius a = new FahrenheitToCelcius(valueToConvert);
            if (unitFrom == Units[0] && unitTo == Units[1])
            {
                return a.c + " c";
            }
            else if (unitFrom == Units[1] && unitTo == Units[0])
            {
                return a.f + " f";
            }
            else { return Error.Info(); }
        }
    }
}
