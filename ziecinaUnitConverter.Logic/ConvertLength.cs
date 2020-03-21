using System;
using System.Collections.Generic;
using System.Text;

namespace ziecina_zad1
{
    public class ConvertLength : IConverter
    {
        public string Name => "Konwerter odległości";

        public List<string> Units => new List<string>
        {
            "ki",
            "mi",
            "m"
        };

        public float Convert(string startUntit, string endUnit, string value)
        {
            float startValueToDefault = 0;
            float toReturn = 0;
            switch (startUntit)
            {
                case "ki":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        ;
                    }
                    break;
                case "mi":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = (float)(1.609344) * startValueToDefault;
                    }
                    break;
                case "m":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = (float)(0.001) * startValueToDefault;
                    }
                    break;
            }
            switch (endUnit)
            {
                case "ki":
                    toReturn = startValueToDefault;
                    break;
                case "mi":
                    toReturn = startValueToDefault / (float)(1.609344);
                    break;
                case "m":
                    toReturn = (float)(1000) * startValueToDefault;
                    break;
            }
            return toReturn;
        }
    }
}
