using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class CelciusToFarenheit : IKonwerter
    {
        public double c;
        public double f;
        private double inputValue;

        public CelciusToFarenheit(double inputValue)
        {
            this.inputValue = inputValue;
        }

        public CelciusToFarenheit()
        {
        }

        public List<string> Units => new List<string>()
        {
            "c",
            "f"
        };

        public string Name => "Celcius To Farenheit";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            
            return (valueToConvert * 1.8) + 32;
        }

        public string UnitConv(string from, string to, string number)
        {
            bool success = double.TryParse(number, out double inputValue);
            if (!success) { inputValue = 0; }
            CelciusToFarenheit a = new CelciusToFarenheit(inputValue);
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
