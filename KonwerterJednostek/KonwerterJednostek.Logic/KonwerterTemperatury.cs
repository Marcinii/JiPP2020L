using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class KonwerterTemperatury: IKonwerter
    {
        public string Name => "Temperatury (C/F)";

        public List<string> Units => new List<string>()
        {
            "C",
            "F"
        };

        public decimal Konwerter(string jednostkaZ, string jednostkaDO, decimal konwertowanaWartosc)
        {
            if (jednostkaZ == "C")
            {
                if (jednostkaDO == "F")
                {
                    return (konwertowanaWartosc * 1.8m) + 32;
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "F")
            {
                if (jednostkaDO == "C")
                {
                    return (konwertowanaWartosc - 32) / 1.8m;
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
