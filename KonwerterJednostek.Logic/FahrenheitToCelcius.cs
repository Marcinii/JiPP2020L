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
        private double inputValue;

        public FahrenheitToCelcius(double inputValue)
        {
            this.inputValue = inputValue;
        }

        public FahrenheitToCelcius()
        {
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

        public string UnitConv(string from, string to, string number)
        {
            bool success = double.TryParse(number, out double inputValue);
            if (!success) { inputValue = 0; }
            FahrenheitToCelcius a = new FahrenheitToCelcius(inputValue);
            if (from == Units[0] && to == Units[1])
            {
                return a.c + " c";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.f + " f";
            }
            else { return Error.Info(); }
        }
    }
}
