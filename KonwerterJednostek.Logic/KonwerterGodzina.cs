using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KonwerterGodzina
    {
        public string Nazwa => "Godzina";
        public int Konwertuj(int wartoscDoKonwersji)
        {
            if (wartoscDoKonwersji >= 12)
                return (wartoscDoKonwersji - 12);
            else
                return wartoscDoKonwersji;
        }
    }
}
