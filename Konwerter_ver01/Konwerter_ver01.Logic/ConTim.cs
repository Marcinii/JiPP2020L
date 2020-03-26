using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Konwerter_ver01
{
    public class ConTim : IConverter
    {
        public string Name => "Zegar";

        public List<string> Jedn => new List<string>()
        {
        "24h", "12h"
        };
        public string Convert(string JednZ, string JednDo, string Wart)
        {
            DateTime time = DateTime.Parse(Wart);
            if (JednZ == "24h")
            {
                if (JednDo == "12h")
                {
                    return time.ToString("h:mmtt");
                }
                else
                {
                    return time.ToString("h:mm");
                }
            }

            else if (JednZ == "12h")
            {
                if (JednDo == "24h")
                {
                    return time.ToString("h:mm");
                }
                else
                {
                    return time.ToString("h:mmtt");
                }
            }
            else return "";
        }
    }
}

