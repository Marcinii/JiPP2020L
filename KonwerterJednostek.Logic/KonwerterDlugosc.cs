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
            "m", "M",
            "km", "KM",
            "mm", "MM"
        };
        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji)
        {
            if ((jednZ == "km" || jednZ == "KM") && (jednDo == "m" || jednDo == "M"))
                return (wartoscDoKonwersji * 1000);
            else if ((jednZ == "m" || jednZ == "M") && (jednDo == "km" || jednDo == "KM"))
                return (wartoscDoKonwersji / 1000);
            else if ((jednZ == "m" || jednZ == "M") && (jednDo == "mm" || jednDo == "MM"))
                return (wartoscDoKonwersji * 1000);
            else if ((jednZ == "km" || jednZ == "KM") && (jednDo == "mm" || jednDo == "MM"))
                return (wartoscDoKonwersji * 1000000);
            else if ((jednZ == "mm" || jednZ == "MM") && (jednDo == "m" || jednDo == "M"))
                return (wartoscDoKonwersji / 1000);
            else if ((jednZ == "mm" || jednZ == "MM") && (jednDo == "km" || jednDo == "KM"))
                return (wartoscDoKonwersji / 1000000);
            return 0;
        }
    }
}
