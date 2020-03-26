using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostekLK
{
    public class LenghtConverter : IConverter
    {
        public string getName => "Dlugosci";

        public List<string> units => new List<string>()
        {
            "mila",
            "kilometr",
            "jard"
        };

        public float Convert(int convertFrom, int convertTo, float value)
        {
            if (convertFrom == 0)
            {
                if (convertTo == 1)
                {
                    value = value * 0.62137f;
                }
                else if(convertTo == 2)
                {
                    value = value * 1760;
                }
            }
            if (convertFrom == 1)
            {
                if (convertTo == 0)
                {
                    value = (value / 0.62137f);
                }
                if (convertTo == 2)
                {
                    value = (value * 1093.6133f);
                }
            }
            else if(convertFrom == 2)
            {
                if (convertTo == 0)
                {
                    value = (value * 0.000568f);
                }
                if (convertTo == 1)
                {
                    value = (value * 0.0009144f);
                }
            }
            return value;
        }
    }
}
