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

        public string naPodst(string Zjakiej, string daneStr) //na gramy
        {
            double dane = double.Parse(daneStr);
            if (Zjakiej == "kg")
            {
                return (dane * 1000).ToString();
            }
            else if (Zjakiej == "lb")
            {
                return (dane * 453.5924).ToString();
            }
            else return dane.ToString();
        }

        public string naWybr(string Zjakiej, string DOjakiej, string daneStr)//z gramow na cos
        {
            double wgramach = double.Parse(naPodst(Zjakiej, daneStr));
            if (DOjakiej == "kg")
            {
                return (wgramach / 1000).ToString();
            }
            else if (DOjakiej == "lb")
            {
                return (wgramach / 453.5924).ToString();
            }
            else return wgramach.ToString();
        }

    }
}
