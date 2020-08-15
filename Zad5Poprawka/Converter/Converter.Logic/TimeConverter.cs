using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class TimeConverter : IConverter
    {
        public string name => "Czasu";

        public List<string> Units => new List<string>()
        {
            "Am",
            "Pm"
        };

        public decimal Convert(string convertFrom, string convertTo, decimal valueToConvert)
        {
            if ((convertFrom.Equals("Am")&&convertTo.Equals("Pm")) && valueToConvert<=12 && valueToConvert>=0){
                return valueToConvert = valueToConvert + 12;
            }else if((convertFrom.Equals("Pm") && convertTo.Equals("Am")) && valueToConvert <= 24 && valueToConvert >= 0)
            {
                return valueToConvert -= 12;
            }
            else
            {
                return -1;
            }
        }

        

       
    }
}
