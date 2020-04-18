using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
   public class Cisnienie_hPa_To_Pa : IKonwerter

    {

        public double pa;
        public double hpa;
        private double inputValue;

        public Cisnienie_hPa_To_Pa(double inputValue)
        {
            this.inputValue = Cisnienie_hPa_To_Pa.
        }

        public Cisnienie_hPa_To_Pa()
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
            return valueToConvert * 100;
        }

        public string UnitConv(string from, string to, string number)
        {
            bool success = double.TryParse(number, out double inputValue);
            if (!success) { inputValue = 0; }
            Cisnienie_hPa_To_Pa a = new Cisnienie_hPa_To_Pa(inputValue);
            if (from == Units[0] && to == Units[1])
            {
                return a.pa + " pa";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.hpa + " hpa";
            }
            else { return Error.Info(); }
        }
    }
}
