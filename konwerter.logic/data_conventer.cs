using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.logic
{
    public class data_conventer : Ikonwerter
    {
        public List<string> Units => new List<string>()
        {
            "Bajt",
            "KiloBajt",
            "GigaBajt"
        };

        public string Name => "Data";

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            switch (unitFrom)
            {
                case "B": // Bajt
                    if (unitTo == "K") // Bajt --> KiloBajt
                    {

                        return valueToConvert * (1/1024);
                    }
                    else // Bajt --> GigaBajt
                    {
                        return valueToConvert * (1/1073741824);
                    }

                case "K": //KiloBajt
                    if (unitTo == "B") // KiloBajt --> Bajt
                    {
                        return valueToConvert * 1024;
                    }
                    else // KiloBajt --> GigaBajt
                    {
                        return valueToConvert * (1/1048576);
                    }
                case "G": //GigaBajt
                    if (unitTo == "B") // GigaBajt --> Bajt
                    {
                        return valueToConvert * 1073741824;
                    }
                    else // GigaBajt --> KiloBajt
                    {
                        return valueToConvert * 1048576;
                    }

            }
            return 0;
        }


    }
}
