using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Energia : IKonwerter
    {
        public string Name => "Energia";

        public List<string> Unit => new List<string>()
        {
            "kcal",
            "cal"
        };

        public string Konwert(string Z, string Do, string wartosc)
        {
            double Wynik = 0;

            if (Z == "kcal" && Do == "cal")
            {
                Wynik = double.Parse(wartosc) * 1000;
            }
            if (Z == "cal" && Do == "kcal")
            {
                Wynik = double.Parse(wartosc) / 1000;
            }

            return Wynik.ToString();
        }
    }
}
