using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConverter;

namespace unitConverter.Logic
{
    public class zegar : Iconventer
    {
        public string Name => "konwertowanie zegara";

        public List<string> Units => new List<string>()
        {
            "12",
            "24"
        };

        public decimal converterCalculator(int unitFrom, int unitTo, decimal value)
        {
            return value % 12;
        }
        public string przeliczanieZegara(string inputValue, decimal value)
        {

            string returnValue;
            if (value - (int)value > (decimal)0.60)
            {
                inputValue = "bledne dane";
            }

            else
            {
                if ((value) < 13) inputValue += "AM";
                else inputValue += "PM";

            }
            returnValue = (value % 12).ToString();
            returnValue +=   " " + inputValue;  
            return returnValue;

        }
    }
}
