using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    public class cisnienia : IKonwerter_jedn
    {
        public string Nazwa => "cisnienia";

        public List<string> Jednostki => new List<string>()
        {
            "pa", //100
            "hpa", //1
            "bar" //0,001
        };

        public double naPodst(string Zjakiej, double dane) //cos na paskale
        {
            if (Zjakiej == "hpa")
            {
                return dane * 100;
            }
            else if (Zjakiej == "bar")
            {
                return dane * 1000000;
            }
            else return dane;
        }

        public double naWybr(string Zjakiej, string DOjakiej, double dane) //z paskali na cos
        {
            double wPa = naPodst(Zjakiej, dane);
            if (DOjakiej == "hpa")
            {
                return wPa / 100;
            }
            else if (DOjakiej == "bar")
            {
                return wPa / 1000000;
            }
            else return wPa;
        }
    }
}
