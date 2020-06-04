using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UnitConverter
{
    public class WeightConverter : IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>()
        {
            "kg",
            "f",
            "g"
        };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
          
            
            if (unitFrom == "kg")
            {
                if (unitTo == "f")
                {
                    return (decimal.Parse(valueToConvert) * 2.2046m).ToString();
                }
                if (unitTo == "g")
                {
                    return (decimal.Parse(valueToConvert) * 1000).ToString();
                }
            }
            if (unitFrom == "f")
            {
                if (unitTo == "kg")
                {
                    return (decimal.Parse(valueToConvert) / 2.2046m).ToString();
                }
                if (unitTo == "g")
                {
                    return ((decimal.Parse(valueToConvert)/ 2.2046m) *1000).ToString();
                }
                if (unitFrom == "g")
                {
                    if (unitTo == "f")
                    {
                        return ((decimal.Parse(valueToConvert)/1000) * 2.2046m).ToString();
                    }
                    if (unitTo == "kg")
                    {
                        return (decimal.Parse(valueToConvert) / 1000).ToString();
                    }
                }
            }
            return " ";
        }
    }
}
