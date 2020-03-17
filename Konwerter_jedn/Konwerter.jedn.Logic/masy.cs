using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    public class masy: IKonwerter_jedn
    {
        public string Nazwa => "masy";

        public List<string> Jednostki => new List<string>()
        {
            "kg", // 1
            "lb", // 1*2.2046
            "g" //1000
        };

        public double naPodst(string Zjakiej, double dane) //na gramy
        {
            if (Zjakiej == "kg")
            {
                return dane * 1000;
            }
            else if (Zjakiej == "lb")
            {
                return dane * 453.5924;
            }
            else return dane;
        }

        public double naWybr(string Zjakiej, string DOjakiej, double dane)//z gramow na cos
        {
            double wgramach = naPodst(Zjakiej, dane);
            if (DOjakiej == "kg")
            {
                return wgramach / 1000;
            }
            else if (DOjakiej == "bar")
            {
                return wgramach / 453.5924;
            }
            else return wgramach;
        }
    }
}
