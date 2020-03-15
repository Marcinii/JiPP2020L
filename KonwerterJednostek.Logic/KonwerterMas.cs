using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
  
    public class KonwerterMas : IKonwerter
    {
        public string Nazwa => "Masy";
        public List<string> Jednostki => new List<string>()
        {
            "kg", "f"
        };
        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji)
        {
            if (jednZ == "kg" || jednZ == "KG")
                return (wartoscDoKonwersji / 0.45359237);
            else if (jednZ == "f" || jednZ == "F")
                return (wartoscDoKonwersji * 0.45359237);
            return 0;
        }

    }
}
