using System;
using System.Collections.Generic;
using System.Text;

namespace ziecina_zad1
{
    class convertTemperature : IConverter
    {
        public string Name => "Konwerter temperatury";

        public List<string> Units => new List<string>
        {
            "°C",
            "°F",
            "K"
        };

        public float Convert(string startUntit, string endUnit, string value)
        {
            float startValueToDefault = 0;
            float toReturn = 0;
            switch (startUntit)
            {
                case "°C":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        ;
                    }
                    break;
                case "°F":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = (startValueToDefault - 32) / (float)(1.8);
                    }
                    break;
                case "K":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = startValueToDefault - (float)(274.15);
                    }
                    break;
            }
            switch (endUnit)
            {
                case "°C":
                    toReturn = startValueToDefault;
                    break;
                case "°F":
                    toReturn = startValueToDefault * (float)(1.8) + 32;
                    break;
                case "K":
                    toReturn = startValueToDefault + (float)(274.15);
                    break;
            }
            return toReturn;
        }
    }
}

