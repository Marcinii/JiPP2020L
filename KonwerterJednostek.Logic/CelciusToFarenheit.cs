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
        private double valueToConvert;
        public CelciusToFarenheit()
        {
            this.c = 0;
            this.f = 0;
            this.valueToConvert = 0;
        }

        public CelciusToFarenheit(double valueToConvert)
        {
            this.valueToConvert = valueToConvert;
        }


        public List<string> Units => new List<string>()
        {
            "c",
            "f"
        };

        public string Name => "Celcius To Farenheit";

        object IKonwerter.Convert(object valueToConvert) => Convert((double)valueToConvert);
        public double Convert(double valueToConvert)
        {

            return (valueToConvert * 1.8) + 32;
        }

        public string UnitConv(string unitFrom, string unitTo, string number)
        {
            bool success = double.TryParse(number, out double valueToConvert);
            if (!success) { valueToConvert = 0; }
            CelciusToFarenheit a = new CelciusToFarenheit(valueToConvert);
            if (unitFrom == Units[0] && unitTo == Units[1])
            {
                return a.c + " C";
            }
            else if (unitFrom == Units[1] && unitTo == Units[0])
            {
                return a.f + " F";
            }
            else { return Error.Info(); }
        }
    }
}
