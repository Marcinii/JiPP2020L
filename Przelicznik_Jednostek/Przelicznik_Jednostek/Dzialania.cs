using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek
{
   public class Dzialania
    {
      public void celcjusz(double c)
        {
            double wynik;
            //działanie obliczające
            wynik = 1.8000 * c + 32;
            Console.WriteLine($"Po przeliczeniu temperatura jest rowna: {wynik} stopni Fahrenheita.");
            Console.WriteLine();
        }

        public void fahrenheit(double f)
        {
            double wynik;
            //działanie obliczające
            wynik = (f - 32) / 1.8000;
            Console.WriteLine($"Po przeliczeniu temperatura jest rowna: {wynik} stopni Celcjusza.");
            Console.WriteLine();
        }
        public void kilometry(double km)
        {
            double wynik;
            //działanie obliczające
            wynik = 0.62137 * km ;
            Console.WriteLine($"Po przeliczeniu odleglosc jest rowna: {wynik} Mil.");
            Console.WriteLine();
        }
        public void mile(double m)
        {
            double wynik;
            //działanie obliczające
            wynik = m / 0.62137;
            Console.WriteLine($"Po przeliczeniu odleglosc jest rowna: {wynik} Kilometrow.");
            Console.WriteLine();
        }
        public void kilogramy(double kg)
        {
            double wynik;
            //działanie obliczające
            wynik = 2.2046 * kg;
            Console.WriteLine($"Po przeliczeniu waga jest rowna: {wynik} Funtow.");
            Console.WriteLine();
        }
        public void funty(double ibs)
        {
            double wynik;
            //działanie obliczające
            wynik = ibs / 2.2046;
            Console.WriteLine($"Po przeliczeniu waga jest rowna: {wynik} Kilogramow.");
            Console.WriteLine();
        }

    }
}
