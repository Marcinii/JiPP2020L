using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostekLK.Logic
{
    public class TimeConverter : IConverter

    {
        public string getName => "Czasu";

        public List<string> units => new List<string>()
        {
            "24h",
            "12h"
        };

        public float Convert(int convertFrom, int convertTo, float value)
        {
            if (convertFrom == 0)
            {
                if (convertTo == 1)
                {
                    value = value - 12;
                }
            }
            if (convertFrom == 1)
            {
                if(convertTo == 0)
                {
                    value = value + 12;
                }
                
            }
            return value;
        }
    }
}
