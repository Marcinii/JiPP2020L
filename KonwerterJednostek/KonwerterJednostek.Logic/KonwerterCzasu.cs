using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class KonwerterCzasu : IKonwerter
    {
        public string Name => "Czasu (min/h)";

        public List<string> Units => new List<string>()
        {
            "min",
            "h"
        };

        public decimal Konwerter(string jednostkaZ, string jednostkaDO, decimal konwertowanaWartosc)
        {
            if (jednostkaZ == "min")
            {
                if (jednostkaDO == "h")
                {
                    return (konwertowanaWartosc / 60);
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "h")
            {
                if (jednostkaDO == "min")
                {
                    return (konwertowanaWartosc * 60);
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

        public override string ToString() { return Name; }
    }
}
