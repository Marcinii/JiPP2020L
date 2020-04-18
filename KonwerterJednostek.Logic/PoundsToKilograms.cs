using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class PoundsToKilograms : IKonwerter
    {

        public double kg;
        public double lb;
        private double inputValue;

        public PoundsToKilograms(double inputValue)
        {
            this.inputValue = inputValue;
        }

        public PoundsToKilograms()
        {
        }

        public List<string> Units => new List<string>()
        {
            "kg",
            "lb"
        };

        public string Name => "Pounds To Kilograms";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert / 2.2046;
        }

        public string UnitConv(string from, string to, string number)
        {
            bool success = double.TryParse(number, out double inputValue);
            if (!success) { inputValue = 0; }
            PoundsToKilograms a = new PoundsToKilograms(inputValue);
            if (from == Units[0] && to == Units[1])
            {
                return a.kg + " kg";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.lb + " lb";
            }
            else { return Error.Info(); }
        }

        public static implicit operator PoundsToKilograms(KilogramsToPounds v)
        {
            throw new NotImplementedException();
        }
    }
}
