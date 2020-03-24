using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    class Odleglosc_Konw
    {
        public double Odleglosc(double Kilometr, double Mila)
        {
            double wynik = 0;

            //przelicza na Mile
            if (Kilometr != 0)
            {
                Console.WriteLine("Ilosc Mil: ");
                wynik = Kilometr / 1.609344;
            }

            //przelicza na kilometry
            if (Mila != 0)
            {
                Console.WriteLine("Ilosc Kilometrow: ");
                wynik = Mila * 1.609344;
            }

            return wynik;
        }
    }
}
