using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek
{
   public class Dzialania
    {
      public double celcjusz(double c)
        {
            double wynik;
            //działanie obliczające
         return   wynik = 1.8000 * c + 32;
           // Console.WriteLine($"Po przeliczeniu temperatura jest rowna: {wynik} stopni Fahrenheita.");
           // Console.WriteLine();
        }

        public double fahrenheit(double f)
        {
            double wynik;
            //działanie obliczające
          return  wynik = (f - 32) / 1.8000;
          //  Console.WriteLine($"Po przeliczeniu temperatura jest rowna: {wynik} stopni Celcjusza.");
          //  Console.WriteLine();
        }
        public double kilometry(double km)
        {
            double wynik;
            //działanie obliczające
         return   wynik = 0.62137 * km ;
         //   Console.WriteLine($"Po przeliczeniu odleglosc jest rowna: {wynik} Mil.");
         //   Console.WriteLine();
        }
        public double mile(double m)
        {
            double wynik;
            //działanie obliczające
         return   wynik = m / 0.62137;
          //  Console.WriteLine($"Po przeliczeniu odleglosc jest rowna: {wynik} Kilometrow.");
           // Console.WriteLine();
        }
        public double kilogramy(double kg)
        {
            double wynik;
            //działanie obliczające
          return  wynik = 2.2046 * kg;
            //Console.WriteLine($"Po przeliczeniu waga jest rowna: {wynik} Funtow.");
           // Console.WriteLine();
        }
        public double funty(double ibs)
        {
            double wynik;
          return   wynik = ibs / 2.2046;
          //  Console.WriteLine($"Po przeliczeniu waga jest rowna: {wynik} Kilogramow.");
          //  Console.WriteLine();
        }

    }
}
