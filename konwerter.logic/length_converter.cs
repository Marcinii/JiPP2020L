using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.logic
{
    public class length_converter : Ikonwerter
    {
        public List<string> Units => new List<string>()
        {
            "Kilometry",
            "Mile",
            "Cale"
        };

        public string Name => "Długości";

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            switch (unitFrom)
            {
                case "K": // Kilometry
                    if (unitTo == "M") // Kilometry --> Mile
                    {
                        return valueToConvert * 62137/100000;
                    }
                    else // Kilometry --> Cale
                    {
                        return valueToConvert * 39370;
                    }

                case "M": //Mile
                    if (unitTo == "K") // Mile --> Kilometry
                    {
                        return valueToConvert / (62137 / 100000);
                    }
                    else // Mile --> Cale
                    {
                        return valueToConvert * 63360;
                    }
                case "C": //Cale
                    if (unitTo == "K") // Cale --> Kilometry
                    {
                        return valueToConvert / 39370;
                    }
                    else // Cale --> Mile
                    {
                        return valueToConvert * 15783/1000000000;
                    }

            }
            return 0;
        }





    }
}
