using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Temperatura_Konw
    {
        public double Temperatura(double Celsjusz, double Farenheit)
        {
            double wynik = 0;

            //przelicza na faranhajty
            if (Celsjusz != 0)
            {
                Console.WriteLine("Ilosc stopni Farenheita: ");
                wynik = Celsjusz * 1.8 + 32;
            }

            //przelicza na celsjusza
            if (Farenheit != 0)
            {
                Console.WriteLine("Ilosc stopni Celsjusza: ");
                wynik = (Farenheit - 32) / 1.8;
            }

            return wynik;
        }
    }
}
