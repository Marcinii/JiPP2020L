using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class zegar : IConverter
    {
        public string Name => "czas 24h na 12h";

        public string Konwertuj(string input)
        {
            int godzina = int.Parse(input.Substring(0, 2));
            string reszta = input.Substring(2, 3);
            string wynik;
            if (godzina > 0 && godzina < 10) { wynik = "0" + godzina.ToString() + reszta + "AM"; }
            else if (godzina > 9 && godzina < 12) { wynik = godzina.ToString() + reszta + "AM"; }
            else if (godzina > 12 && godzina < 22) { wynik = "0" + (godzina - 12).ToString() + reszta + "PM"; }
            else if (godzina > 21 && godzina < 24) { wynik = (godzina - 12).ToString() + reszta + "PM"; }
            else if (godzina == 12) { wynik = godzina.ToString() + reszta + "PM"; }
            else { wynik = "12" + reszta + "AM"; }

            return wynik;
        }
    }
}
