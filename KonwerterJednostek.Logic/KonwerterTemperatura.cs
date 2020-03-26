using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class KonwerterTemperatura : IKonwerter
    {
        public string Nazwa => "Temperatury";
        public List<string> Jednostki => new List<string>()
        {
            "C",
            "F",
            "K"
        };
        
        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji)
        {
            if (jednZ == "C" && jednDo=="F")
                return (wartoscDoKonwersji * 9 / 5 + 32);
            else if (jednZ == "F" && jednDo == "C")

                return ((wartoscDoKonwersji - 32) * 5 / 9);
            else if (jednZ == "C" || jednDo == "K")
                return (wartoscDoKonwersji + 274.15);
            else if (jednZ == "K" || jednDo == "C")
                return (wartoscDoKonwersji - 274.15);

            else if (jednZ == "K" || jednDo == "F")
                return (wartoscDoKonwersji * (9 / 5 - 459.67));
            else if (jednZ == "F" || jednDo == "K")
                return ((wartoscDoKonwersji + 459.67)*(5/9));

            return 0;
        }
    }
}
