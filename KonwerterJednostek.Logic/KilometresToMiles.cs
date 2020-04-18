using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class KilometresToMiles : IKonwerter
    {
        public double km;
        public double mil;
        private double inputValue;

        public KilometresToMiles(double inputValue)
        {
            this.inputValue = inputValue;
        }

        public KilometresToMiles()
        {
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

        public string UnitConv(string from, string to, string number)
        {

                bool success = double.TryParse(number, out double inputValue);
                if (!success) { inputValue = 0; }
            KilometresToMiles a = new KilometresToMiles(inputValue);
                if (from == Units[0] && to == Units[1])
                {
                    return a.km + " km";
                }
                else if (from == Units[1] && to == Units[0])
                {
                    return a.mil + " mil";
                }
                else { return Error.Info(); }
            }
    }
}
