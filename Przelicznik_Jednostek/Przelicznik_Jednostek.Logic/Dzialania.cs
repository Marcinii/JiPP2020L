﻿using Przelicznik_Jednostek.Logic;
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
            return yd * 1093.61;
        }
        private double km_yd(double km)
        {
            return km * 0.00091440271745352;
        }
        private double clock_change (double zegarek)
        {
            return 0;
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
            else return 0.ToString();
        }

    }
}