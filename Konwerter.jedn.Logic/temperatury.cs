using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
   public class temperatury: IKonwerter_jedn
    {
        public string Nazwa => "temperatury";

        public List<string> Jednostki => new List<string>()
        {
            "c", // 100
            "f", // 100*1.8 -32
            "k" // 100+273,15
        };
        public string naPodst(string Zjakiej, string daneStr) //cos na celsjusze
        {
            double dane = double.Parse(daneStr);
            if (Zjakiej == "f")
            {
                return ((dane-32)/1.8).ToString();
            }
            else if (Zjakiej == "k")
            {
                return (dane -273.15).ToString();
            }
            else return dane.ToString();
        }

        public string naWybr(string Zjakiej, string DOjakiej, string daneStr)//z celsuszy na cos
        {
            double wC = double.Parse(naPodst(Zjakiej, daneStr));
            if (DOjakiej == "f")
            {
                return ((wC *1.8)+32).ToString();
            }
            else if (DOjakiej == "k")
            {
                return (wC +273.15).ToString();
            }
            else return wC.ToString();
        }

    }
}
