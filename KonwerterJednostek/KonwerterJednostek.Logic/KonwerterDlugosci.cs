using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class KonwerterDlugosci: IKonwerter
    {
        public string Name => "Dlugosci (m/km/mi)";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi",
            "m"
        };

        public decimal Konwerter(string jednostkaZ, string jednostkaDO, decimal konwertowanaWartosc)
        {
            if (jednostkaZ == "km")
            {
                if (jednostkaDO == "mi")
                {
                    return (konwertowanaWartosc * 0.6214m);
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "mi")
            {
                if (jednostkaDO == "km")
                {
                    return (konwertowanaWartosc / 0.6214m);
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "km")
            {
                if (jednostkaDO == "m")
                {
                    return (konwertowanaWartosc * 1000);
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "m")
            {
                if (jednostkaDO == "km")
                {
                    return (konwertowanaWartosc / 1000);
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "m")
            {
                if (jednostkaDO == "mi")
                {
                    return (konwertowanaWartosc * 621.4m);
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "mi")
            {
                if (jednostkaDO == "m")
                {
                    return (konwertowanaWartosc / 621.4m);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Podałeś nieprawidłowe jednostki!");
                return 0;
            }
            }
    }
}