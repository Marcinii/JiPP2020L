using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostekLK
{
    public class UnitConverter : IConverter
    {
        public string getName => "Jednostek";

        public List<string> units => new List<string>()
        {
            "metry",
            "centymetry",
        };

        public float Convert(int convertFrom, int convertTo, float value)
        {
            if (convertFrom == 0)
            {
                if (convertTo == 1)
                {
                    value = value*100;
                }

            }
            if (convertFrom == 1)
            {
                if (convertTo == 0)
                {
                    value = value/100;
                }
            }
            return value;
        }
    }
}
