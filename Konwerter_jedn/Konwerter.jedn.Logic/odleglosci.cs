using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    public class odleglosci: IKonwerter_jedn
    {
        public string Nazwa => "odleglosci";

        public List<string> Jednostki => new List<string>()
        {
            "km", // 1
            "mi", // /1,609344
            "m" //1000
        };
        public double naPodst(string Zjakiej, double dane) //cos na metry
        {
            if (Zjakiej == "km")
            {
                return dane * 1000;
            }
            else if (Zjakiej == "mi")
            {
                return dane * 1609.344;
            }
            else return dane;
        }

        public double naWybr(string Zjakiej, string DOjakiej, double dane) //z metrow na cos
        {
            double wmetrach = naPodst(Zjakiej, dane);
            if (DOjakiej == "km")
            {
                return wmetrach / 1000;
            }
            else if (DOjakiej == "mi")
            {
                return wmetrach / 1609.344;
            }
            else return wmetrach;
        }
    }
}
