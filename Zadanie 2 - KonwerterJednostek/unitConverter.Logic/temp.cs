using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConverter
{
    public class temp : Iconventer
    {
        public string Name => "tempConverter";

        public List<string> Units => new List<string>()
        {
            "Celsjusz",
            "FarenHeit"
        };
        public decimal converterCalculator(int unitFrom, int unitTo, decimal value)
        {
            if (unitFrom == 0)
            {
                value = ((9 * value) / 5) + 32;
            }
            else
            {
                value = (value - 32)/ (decimal)1.8;
            }
            return value;
        }
    }
}
