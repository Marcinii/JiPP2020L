using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class KonwerterTemperatury : IKonwerter
    {
        public string Nazwa { get => "Temperatura"; }


        public List<string> Jednostki { get => new List<string> { "°F", "°C" }; }


        public string Konwertuj(string jednostkaZ, string jednostkaDo, string wartoscString)
        {
            double wartosc = 0; ;
            double.TryParse(wartoscString, out wartosc);

            if (jednostkaZ == Jednostki[0] && jednostkaDo == Jednostki[1])
                return ((wartosc - 32) / 1.8d).ToString();
            else if (jednostkaZ == Jednostki[1] && jednostkaDo == Jednostki[0])
                return ((wartosc * 1.8d) + 32).ToString();

            return wartoscString;
        }
    }
}
