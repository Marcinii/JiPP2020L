using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Odleglosc: IKonwerter
    {
        public string Name => "Odleglosc";

        public List<string> Unit => new List<string>()
        {
            "km",
            "mile"
        };

        public string Konwert(string Z, string Do, string wartosc)
        {
            double Wynik = 0;
            

            if (Z == "km" && Do == "mile")
            {
                Wynik = double.Parse(wartosc) * 0.621371;
            }
            if (Z == "mile" && Do == "km")
            {
                Wynik = double.Parse(wartosc) * 1.609344;
            }

            return Wynik.ToString();
    }   }
}
