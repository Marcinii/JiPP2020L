using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class Dystans: IConverter
    {
        public Dystans() { }

        public string Name => "Dystans";

        public List<string> Units => new List<string>()
        {
            "km", "miles", "m"
        };

        public double convert(double a, string from, string to)
        {
            double b = a;

            if (from == Units[0] && to == Units[1])
            {
                b = a * 0.621371192;
            }
            else if (from == Units[0] && to == Units[2])
            {
                b = a * 1000;
            }
            else if (from == Units[1] && to == Units[0])
            {
                b = a * 1 / 0.621371192;
            }
           
            else if (from == Units[1] && to == Units[2])
            {
                b = a * 1000 / 0.621371192;
            }
            else if (from == Units[2] && to == Units[0])
            {
                b = a / 1000;
            }
            else if (from == Units[2] && to == Units[1])
            {
                b = (a * 0.621371192)/1000;
            } 




            return b;
        }
        public override string ToString() { return Name; }
    }
}