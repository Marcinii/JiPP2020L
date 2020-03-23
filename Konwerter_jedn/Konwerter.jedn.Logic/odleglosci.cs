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
       
        public string naPodst(string Zjakiej, string strDane) //cos na metry
        {
            double dane = double.Parse(strDane);
            if (Zjakiej == "km")
            {
                return (dane * 1000).ToString();
            }
            else if (Zjakiej == "mi")
            {
                return (dane * 1609.344).ToString();
            }
            else return dane.ToString();
        }

        public string naWybr(string Zjakiej, string DOjakiej, string strDane) //z metrow na cos
        {
            double wmetrach = double.Parse(naPodst(Zjakiej, strDane));
            if (DOjakiej == "km")
            {
                return (wmetrach / 1000).ToString();
            }
            else if (DOjakiej == "mi")
            {
                return (wmetrach / 1609.344).ToString();
            }
            else return wmetrach.ToString();
        }
    }
}
