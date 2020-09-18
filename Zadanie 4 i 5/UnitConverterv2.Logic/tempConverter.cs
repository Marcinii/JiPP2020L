using System.Collections.Generic;

namespace unitConverterv2
{
    public class tempConverter : IConvert
    {
        public string Name => "temp Converter";

        public List<string> Units => new List<string>()
        {
            "Celvin", //0
            "Celcius", //1
            "Faranhait" //2
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
            if (fromUnit == 0) // celviny
            {
                if (toUnit == 1)
                {
                   value = value - (decimal)273.15;
                   
                }
                else if (toUnit == 2)
                {
                    value = ((value - (decimal)273.15) * (decimal)1.8) + 32;
                }
            }

            else if (fromUnit == 0) // Celcius
            {
                if (toUnit == 0)
                {
                    value = value + (decimal)273.15;
                }
                else if (toUnit == 2)
                {
                    value = ((9 * value) / 5) + 32;
                }
            }

            else // Faranhait
            {
                if (toUnit == 0)
                {
                    value = ((value - 32)/(decimal)1.80) + (decimal)273.15;
                }
                else if (toUnit == 1)
                {
                    value = ((value - 32));
                    value /= (decimal)1.8;
                   
                }
            }

            return value;
        }
    }
}
 