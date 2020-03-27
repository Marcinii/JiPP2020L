using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Masa: IKonwerter
    {
        public string Name => "Masa";

        public List<string> Unit => new List<string>()
        {
            "kg",
            "funty"
        };

        public string Konwert(string Z, string Do, string wartosc)
        {
            double Wynik = 0;

            if (Z == "kg" && Do == "funty")
            {
                Wynik = double.Parse(wartosc) * 2.20462262185;
            }
            if (Z == "funty" && Do == "kg")
            {
                Wynik = double.Parse(wartosc) / 2.20462262185;
            }

            return Wynik.ToString();
        }
    }
}
