using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.logic
{
    public class temp_converter: Ikonwerter
    {

        public List<string> Units => new List<string>()
        {
            "Celsjusz",
            "Farenheit",
            "Kelwiny"
        };

        public string Name => "Temperatury";

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            switch (unitFrom)
            {
                case "C": // Celsjusz
                    if (unitTo == "F") // Celsjusz --> Farenheit
                    {

                        return (valueToConvert * 18 / 10) + 32;
                    }
                    else // Celsjusz --> Kelwiny
                    {
                        return valueToConvert + (27315 / 100);
                    }

                case "F": //Farenheit
                     if (unitTo == "C") // Farenheit --> Celsjusz
                    {
                        return (valueToConvert - 32) / (18/10);
                    }
                    else // Farenheit --> Kelwiny
                    {
                        return ((valueToConvert - 32) / (18 / 10)) + (27315 / 100);
                    }
                case "K": //Kelwiny
                    if (unitTo == "C") // Kelwiny --> Celsjusz
                    {
                        return valueToConvert - (27315 / 100);
                    }
                    else // Kelwiny --> Farenheit
                    {
                        return (valueToConvert - (27315 / 100) * (18 / 10)) + 32;
                    }

            }
                    return 0;
        }
    }
}
