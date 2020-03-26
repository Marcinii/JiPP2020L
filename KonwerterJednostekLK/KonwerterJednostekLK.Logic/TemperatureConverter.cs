using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostekLK
{
    public class TemperatureConverter : IConverter
    {
        public string getName => "Temperatury";

        public List<string> units => new List<string>()
        {
            "celciusz",
            "farenheit"
        };

        public float Convert(int convertFrom, int convertTo, float value)
        {
            if (convertFrom == 0)
            {
                if (convertTo == 1)
                {
                    value = (value * 1.8f) +32 ;
                }
                
            }
            if (convertFrom == 1)
            {
                if (convertTo == 0)
                {
                    value = (value - 32)/1.8f;
                }          
            }
            return value;
        }
    }
}
