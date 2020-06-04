using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    class VolumeConverter:IConverter
    {
        public string Name => "Objetosc";

        public List<string> Units => new List<string>()
        {
            "ml",
            "l",
            "cl"
        };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {

            if (unitFrom == "l")
            {
                if (unitTo == "ml")
                {
                    return (decimal.Parse(valueToConvert) * 1000).ToString();
                }
                if (unitTo == "cl")
                {
                    return (decimal.Parse(valueToConvert) * 100).ToString();
                }
            }
            if (unitFrom == "ml")
            {
                if (unitTo == "l")
                {
                    return (decimal.Parse(valueToConvert) / 1000).ToString();
                }
                if (unitTo == "cl")
                {
                    return (decimal.Parse(valueToConvert) / 10).ToString();
                }
                if (unitFrom == "cl")
                {
                    if (unitTo == "l")
                    {
                        return (decimal.Parse(valueToConvert) /100).ToString();
                    }
                    if (unitTo == "ml")
                    {
                        return (decimal.Parse(valueToConvert) * 10).ToString();
                    }
                }
            }
            return " ";
        }
    }
}
