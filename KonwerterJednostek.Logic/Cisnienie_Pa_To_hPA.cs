using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
   public class Cisnienie_Pa_To_hPa : IKonwerter

    {
        public double pa;
        public double hpa;
        private double inputValue;

        public Cisnienie_Pa_To_hPa(double inputValue)
        {
            this.inputValue = inputValue;
        }

        public Cisnienie_Pa_To_hPa()
        {
        }

        public string Name => "Ciśnienie";

        public List<string> Units => new List<string>()
        {
            "Pa",
            "hPa"
        };

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert / 100;
        }

        public string UnitConv(string from, string to, string number)
        {
            bool success = double.TryParse(number, out double inputValue);
            if (!success) { inputValue = 0; }
            Cisnienie_Pa_To_hPa a = new Cisnienie_Pa_To_hPa(inputValue);
            if (from == Units[0] && to == Units[1])
            {
                return a.pa + " Pa";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.hpa + " hPa";
            }
            else { return Error.Info(); }
        }
    }
}
