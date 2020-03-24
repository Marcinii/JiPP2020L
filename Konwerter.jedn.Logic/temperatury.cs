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
        public double naPodst(string Zjakiej, double dane) //cos na celsjusze
        {
            if (Zjakiej == "f")
            {
                return (dane-32)/1.8;
            }
            else if (Zjakiej == "k")
            {
                return dane -273.15;
            }
            else return dane;
        }

        public double naWybr(string Zjakiej, string DOjakiej, double dane)//z celsuszy na cos
        {
            double wC = naPodst(Zjakiej, dane);
            if (DOjakiej == "f")
            {
                return (wC *1.8)+32;
            }
            else if (DOjakiej == "k")
            {
                return wC +273.15;
            }
            else return wC;
        }

    }
}
