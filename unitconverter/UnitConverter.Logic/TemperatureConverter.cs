using System.Collections.Generic;

namespace UnitConverter
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Konwerter Temperatury";

        public List<string> Units => new List<string>()
        {
            "Kelvin", //0
            "Celsjusz", //1
            "Farenhait" //2
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
            if (fromUnit == 0) // Kalvin
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

            else if (fromUnit == 0) // Celsjusz
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

            else // Farenheit
            {
                if (toUnit == 0)
                {
                    value = ((value - 32) / (decimal)1.80) + (decimal)273.15;
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