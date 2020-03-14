using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public class KonwerterMasy: IKonwerter
    {
        public string Name => "Masy (kg/f)";

        public List<string> Units => new List<string>()
        {
            "kg",
            "f"
        };

        public decimal Konwerter(string jednostkaZ, string jednostkaDO, decimal konwertowanaWartosc)
        {
            if (jednostkaZ == "kg")
            {
                if (jednostkaDO == "f") {
                    return (konwertowanaWartosc * 2.204m);
                }
                else
                {
                    return 0;
                }
            }
            else if (jednostkaZ == "f")
            {
                if (jednostkaDO == "kg") {
                    return (konwertowanaWartosc / 2.204m);
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
