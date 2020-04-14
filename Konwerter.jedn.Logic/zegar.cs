using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    public class zegar : IKonwerter_jedn
    {
        public string Nazwa => "zegar";

        public List<string> Jednostki => new List<string>()
        {
            "24 - godzinny", //podstawowy
            "12 - godzinny",
        };

        public string naPodst(string Zjakiej, string dane) //na 24
        {
            return dane;
        }

        public string naWybr(string Zjakiej, string DOjakiej, string daneStr)//na 12
        {
            //string tmp = (dane).ToString();
            DateTime w24 = DateTime.Parse(daneStr);
            //double w24 = naPodst(Zjakiej, dane);
            if (DOjakiej == "12 - godzinny")
            {
                return w24.ToString("h:mm tt");
            }
            else 
            {
                return w24.ToString("H:mm");
            }
        }
    }
}
