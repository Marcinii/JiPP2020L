using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.logic
{
    public class weight_conventer : Ikonwerter
    {
        public List<string> Units => new List<string>()
        {
            "Kilogramy",
            "Funty",
            "Gramy"
        };

        public string Name => "Masy";

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            switch (unitFrom)
            {
                case "K": // Kilogramy
                    if (unitTo == "F") // Kilogramy --> Funty
                    {

                        return valueToConvert * (22046/10000);
                    }
                    else // Kilogramy --> Gramy
                    {
                        return valueToConvert / (1/1000);
                    }

                case "F": //Funty
                    if (unitTo == "C") // Funty --> Kilogramy
                    {
                        return valueToConvert / (22046/10000);
                    }
                    else // Funty --> Gramy
                    {
                        return valueToConvert * 12;
                    }
                case "G": //Gramy
                    if (unitTo == "K") // Gramy --> Kilogramy
                    {
                        return valueToConvert / 1000;
                    }
                    else // Gramy --> Funty
                    {
                        return valueToConvert * 12;
                    }

            }
            return 0;
        }

    }
}
