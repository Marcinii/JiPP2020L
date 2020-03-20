using System;
using System.Collections.Generic;
using System.Text;

namespace ziecina_zad1
{
    class ConvertMass : IConverter
    {
        public string Name => "Konwerter wagi";

        public List<string> Units => new List<string>
        {
            "kg",
            "lbs",
            "g"
        };

        public float Convert(string startUntit, string endUnit, string value)
        {
            float startValueToDefault = 0;
            float toReturn = 0;
            switch (startUntit)
            {
                case "kg":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        ;
                    }
                    break;
                case "lbs":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = (float)(0.4535923) * startValueToDefault;
                    }
                    break;
                case "g":
                    if (float.TryParse(value, out startValueToDefault))
                    {
                        startValueToDefault = (float)(0.001) * startValueToDefault;
                    }
                    break;
            }
            switch(endUnit)
            {
                case "kg":
                    toReturn = startValueToDefault;
                    break;
                case "lbs":
                    toReturn = (float)(2.20462262) * startValueToDefault;
                    break;
                case "g":
                    toReturn = (float)(1000) * startValueToDefault;
                    break;
            }
            return toReturn;
            }
        }
    }
}
