using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    class Masa_Konw
    {
        public double Masa(double Kilogram, double Funt)
        {
            double wynik = 0;

            //przelicza na Kilogram
            if (Funt != 0)
            {
                Console.WriteLine("Ilosc Kilogramow: ");
                wynik = Funt * 0.45359237;
            }

            //przelicza na Funt
            if (Kilogram != 0)
            {
                Console.WriteLine("Ilosc Funtow: ");
                wynik = Kilogram / 0.45359237;
            }

            return wynik;
        }
    }
}
