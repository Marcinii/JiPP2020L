using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostekLK
{
    public class MassConverter : IConverter
    {
        public string getName => "Masy";

        public List<string> units => new List<string>()
        {
            "funt",
            "kilogram"
        };

        public float Convert(int convertFrom, int convertTo, float value)
        {
            if (convertFrom == 0)
            {
                if (convertTo == 1)
                {
                    value = value * 0.45f;
                } 
            }
            if (convertFrom == 1)
            {
                if (convertTo == 0)
                {
                    value = value*2.204f;
                }
            }
            return value;
        }
    }
}
