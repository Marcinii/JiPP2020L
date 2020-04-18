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
        private double valueToConvert;
        public Cisnienie_hPa_To_Pa()
        {
            this.pa = 0;
            this.hpa = 0;
            this.valueToConvert = 0;
        }

        public Cisnienie_hPa_To_Pa(double valueToConvert)
        {
            this.valueToConvert = valueToConvert;
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

        public string UnitConv(string unitFrom, string unitTo, string number)
        {
            bool success = double.TryParse(number, out double valueToConvert);
            if (!success) { valueToConvert = 0; }
            Cisnienie_hPa_To_Pa a = new Cisnienie_hPa_To_Pa(valueToConvert);
            if (unitFrom == Units[0] && unitTo == Units[1])
            {
                return a.pa + " pa";
            }
            else if (unitFrom == Units[1] && unitTo == Units[0])
            {
                return a.hpa + " hpa";
            }
            else { return Error.Info(); }
        }
    }
}
