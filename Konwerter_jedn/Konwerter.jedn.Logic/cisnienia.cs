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

        public string naPodst(string Zjakiej, string strDane) //cos na paskale
        {
            double dane = double.Parse(strDane);
            if (Zjakiej == "hpa")
            {
                return (dane * 100).ToString();
            }
            else if (Zjakiej == "bar")
            {
                return (dane * 1000000).ToString();
            }
            else return dane.ToString();
        }

        public string naWybr(string Zjakiej, string DOjakiej, string strDane) //z paskali na cos
        {
            double wPa = double.Parse(naPodst(Zjakiej, strDane));
            if (DOjakiej == "hpa")
            {
                return (wPa / 100).ToString();
            }
            else if (DOjakiej == "bar")
            {
                return (wPa / 1000000).ToString();
            }
            else return wPa.ToString();
        }
    }
}
