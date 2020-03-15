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
            "F"
        };
        
        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji)
        {
            if (jednZ == "C" || jednZ == "c")
                return (wartoscDoKonwersji * 9 / 5 + 32);
            else if (jednZ == "F" || jednZ == "f")
                return ((wartoscDoKonwersji - 32) * 5 / 9);
            return 0;
        }
    }
}
