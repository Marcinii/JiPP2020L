using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class KonwerterDlugosc : IKonwerter
    {
        public string Nazwa => "Dlugosci";

        public List<string> Jednostki => new List<string>()
        {
            "m",
            "km"
        };
        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji)
        {
            if (jednZ == "km" || jednZ == "KM")
                return (wartoscDoKonwersji * 1000);
            else if (jednZ == "m" || jednZ == "M")
                return (wartoscDoKonwersji / 1000);
            return 0;
        }
    }
}
