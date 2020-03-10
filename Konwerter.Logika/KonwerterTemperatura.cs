using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KonwerterTemperatura: IKonwerter
    {
        public List<string> Jednostki => new List<string>()
        {
            "Celsius",
            "Fahrenheit",
            "Kelvin",
        };

        public string Name => "Temperatury";
        public string jednostki => "C F K";

        public double Konwertuj(string jw, string jd, double wynik)
        {

            if (jw == "Celsius" & jd == "Fahrenheit")
            {
                return (wynik * 9 / 5 + 32);
            }
            else if (jw == "Fahrenheit" & jd == "Celsius")
            {
                return (wynik - 32)/1.8;

            }
            else if (jw == "Fahrenheit" & jd == "Kelvin")
            {
                return (((wynik - 273) * 9 / 5)+32);

            }
            else if (jw == "Kelvin" & jd == "Fahrenheit")
            {
                return (((wynik - 32) * 5 / 9)+273);

            }
            else if (jw == "Celsius" & jd == "Kelvin")
            {
                return wynik + 273.15;

            }
            else if (jw == "Kelvin" & jd == "Celsius")
            {
                return (wynik - 273.15);
            }
            return wynik;
        }
    }
}
