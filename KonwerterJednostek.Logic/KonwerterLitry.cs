using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KonwerterLitry :IKonwerter
    {
        public string Nazwa => "Litry";
        public List<string> Jednostki => new List<string>()
        {
            "l", "m^3"
        };
        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji)
        {
            if (jednZ == "L" || jednZ == "l")
                return (wartoscDoKonwersji / 1000);
            else if (jednZ == "m^3" || jednZ == "M^3")
                return (wartoscDoKonwersji *1000);
            return 0;
        }
    }
}
