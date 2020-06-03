using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Logic;

namespace Konwerter.Logic
{
    public class KonwerterZegara : IKonwerter
    {
        public string Nazwa { get => "Zegar"; }

        public List<string> Jednostki => new List<string>
        {
            "12h",
            "24h"
        };

        public string Konwertuj(string jednostkaZ, string jednostkaDo, string wartoscString)
        {

            DateTime czas;
            try
            {
                czas = DateTime.Parse(wartoscString);
            }
            catch (Exception)
            {
                return "";
            }

            if (jednostkaZ == "12h" && jednostkaDo == "24h")
            {
                return czas.ToString("HH:mm:ss");
            }
            else if (jednostkaZ == "24h" && jednostkaDo == "12h")
            {
                return czas.ToString("hh:mm:ss tt");
            }

            return "";
        }

    }
}
