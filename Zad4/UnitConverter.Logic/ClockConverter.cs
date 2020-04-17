using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace UnitConverter
{
    public class ClockConverter: IConverter
    {
        public string Name => "Zegar";

        public List<string> Units => new List<string>()
        {
            "24",
            "12"
        };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            string wynik="Godzina jest w złym formacie. Prawidłowy format to 'gg:mm'";
            if ((valueToConvert.Length == 5) && (valueToConvert.Substring(2, 1) == ":"))
            {
                    string godzina = valueToConvert.Substring(0, 2);
                    string minuty = valueToConvert.Substring(3, 2);

                if (unitFrom == "24" && unitTo == "12" && System.Convert.ToInt32(godzina) < 25 && System.Convert.ToInt32(minuty) < 60)
                {
                    if (System.Convert.ToInt32(godzina) > 12)
                    {
                        wynik = System.Convert.ToString(System.Convert.ToInt32(godzina) - 12) + ":" + minuty + "PM";
                    }
                    else
                    {
                        wynik = godzina + ":" + minuty + "AM";
                    } 
                }
                
                else if (unitFrom == "12" && unitTo == "24")
                {
                    wynik = "Konwersja tylko jednostronna z 24 na 12";
                }

            }
             return wynik;
        }
    }
}
