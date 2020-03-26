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
            "kg", "KG",
            "f", "F",
            "g", "G"
        };
        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji)
        {
            if ((jednZ == "kg" || jednZ == "KG") && (jednDo=="f" || jednDo=="F"))
                return (wartoscDoKonwersji / 0.45359237);
            else if ((jednZ == "f" || jednZ == "F") && (jednDo=="kg" || jednDo=="KG"))
                return (wartoscDoKonwersji * 0.45359237);
            else if ((jednZ == "f" || jednZ == "F") && (jednDo == "g" || jednDo == "G"))
                return (wartoscDoKonwersji * 453.59237);
            else if ((jednZ == "g" || jednZ == "G") && (jednDo == "f" || jednDo == "F"))
                return (wartoscDoKonwersji / 453.59237);
            else if ((jednZ == "kg" || jednZ == "KG") && (jednDo == "g" || jednDo == "G"))
                return (wartoscDoKonwersji * 1000);
            else if ((jednZ == "g" || jednZ == "G") && (jednDo == "kg" || jednDo == "KG"))
                return (wartoscDoKonwersji / 1000);
            return 0;
        }

    }
}
