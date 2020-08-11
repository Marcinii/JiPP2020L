using Przelicznik_Jednostek.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Przelicznik_Jednostek
{
   public class Dzialania: ISubmition
    {
      private double celcjusz(double c)
        {
            
            //działanie obliczające
         return 1.8000 * c + 32;
           // Console.WriteLine($"Po przeliczeniu temperatura jest rowna: {wynik} stopni Fahrenheita.");
           // Console.WriteLine();
        }

        private double fahrenheit(double f)
        {
            
            //działanie obliczające
          return  (f - 32) / 1.8000;
          //  Console.WriteLine($"Po przeliczeniu temperatura jest rowna: {wynik} stopni Celcjusza.");
          //  Console.WriteLine();
        }
        private double kilometry(double km)
        {
           
            //działanie obliczające
         return  0.62137 * km ;
         //   Console.WriteLine($"Po przeliczeniu odleglosc jest rowna: {wynik} Mil.");
         //   Console.WriteLine();
        }
        private double mile(double m)
        {
            
            //działanie obliczające
         return  m / 0.62137;
          //  Console.WriteLine($"Po przeliczeniu odleglosc jest rowna: {wynik} Kilometrow.");
           // Console.WriteLine();
        }
        private double kilogramy(double kg)
        {
            
            //działanie obliczające
          return  2.2046 * kg;
            //Console.WriteLine($"Po przeliczeniu waga jest rowna: {wynik} Funtow.");
           // Console.WriteLine();
        }
        private double funty(double ibs)
        {
            
          return   ibs / 2.2046;
          //  Console.WriteLine($"Po przeliczeniu waga jest rowna: {wynik} Kilogramow.");
          //  Console.WriteLine();
        }
        private double jard(double yd)
        {
            return yd * 1093.61;//wynik w km
        }
        private double km_yd(double km)
        {
            return km * 0.00091440271745352;//wynik w jard
        }
        private double kelvin(double k)
        {
            return k - 273.15;//wynik w celcjusz
        }
        private double celKel(double c)
        {
            return c + 273.15;//wynik w Kelvin
        }
        private double kilo(double kg)
        {
            return kg * 1000;//wynik w gram
        }
        private double gram(double g)
        {
            return g / 1000;//wynik w kg
        }
        private double joul(double j)
        {
            return j * 1000;//wynik w kilojoulach
        }
        private double Kjoul(double kJ)
        {
            return kJ / 1000;//wynik w joulach
        }
        private double clock_change (double zegarek)
        {
            if (zegarek < 13)
            {
                return zegarek;
            }
            else if (zegarek == 13)
            {
                return 1;
            }
            else if (zegarek == 14)
            {
                return 2;
            }
            else if (zegarek == 15)
            {
                return 3;
            }
            else if (zegarek == 16)
            {
                return 4;
            }
            else if (zegarek == 17)
            {
                return 5;
            }
            else if (zegarek == 18)
            {
                return 6;
            }
            else if (zegarek == 19)
            {
                return 7;
            }
            else if (zegarek == 20)
            {
                return 8;
            }
            else if (zegarek == 21)
            {
                return 9;
            }
            else if (zegarek == 22)
            {
                return 10;
            }
            else if (zegarek == 23)
            {
                return 11;
            }
            else if (zegarek == 24)
            {
                return 12;
            }
            else
            {
                return 0;
            }

        }
        public string which_submition(int q, double z)
        {
            if (q == 2)
            {
                return celcjusz(z).ToString();
            }
            if (q == 1)
            {
                return fahrenheit(z).ToString();
            }
            if (q == 4)
            {
                return kilometry(z).ToString();
            }
            if (q == 3)
            {
                return mile(z).ToString();
            }
            if (q == 6)
            { return kilogramy(z).ToString();
            }
            if (q == 5)
            {
                return funty(z).ToString();
            }
            if ( q == 7)
            {
                return jard(z).ToString();
            }
            if (q == 8)
            {
                return km_yd(z).ToString();
            }
            if (q == 9)
            {
                return clock_change(z).ToString();
            }
            if (q == 10)
            {
                return kelvin(z).ToString();
            }
            if (q == 11)
            {
                return celKel(z).ToString();
            }
            if (q == 12)
            {
                return kilo(z).ToString();
            }
            if (q == 13)
            {
                return gram(z).ToString();
            }
            if (q == 14)
            {
                return joul(z).ToString();
            }
            if (q == 15)
            {
                return Kjoul(z).ToString();
            }

            else return 0.ToString();
        }

    }
}
