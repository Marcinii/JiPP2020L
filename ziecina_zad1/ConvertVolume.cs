using System;
using System.Collections.Generic;
using System.Text;

namespace ziecina_zad1
{
    class ConvertVolume : IConverter
    {
        public string Name => "Konwerter objętości";

        public List<string> Units => new List<string>
        {
            "l",
            "oz",
            "m^3"
        };

        public float Convert(string startUntit, string endUnit, string value)
        {
            float startValueToDefault = 0;
            float toReturn = 0;
            switch (startUntit)
            {
                case "l":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        ;
                    }
                    break;
                case "oz":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = (float)(0.0295735) * startValueToDefault;
                    }
                    break;
                case "m^3":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = (float)(1000) * startValueToDefault;
                    }
                    break;
            }
            switch (endUnit)
            {
                case "l":
                    toReturn = startValueToDefault;
                    break;
                case "oz":
                    toReturn = startValueToDefault / (float)(33.8140227);
                    break;
                case "m^3":
                    toReturn = (float)(0.001) * startValueToDefault;
                    break;
            }
            return toReturn;
        }
    }
}

