using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConverter
{
    public class lenght : Iconventer
    {
        public string Name => "lenghtConverter";

        public List<string> Units => new List<string>()
        {
            "kilogramy",
            "funty"
        };
public decimal converterCalculator(int unitFrom, int unitTo, decimal value)
        {
            if (unitFrom == 0)
            {
                value = value * (decimal)2.2046;
            }
            else
            {
                value = value / (decimal)2.2046;
            }
            return value;
        }
    }
}
