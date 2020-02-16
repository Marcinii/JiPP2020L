using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    class Length
    {
        public double value;
        public double k;
        public double m;
        public Length()
        {
            this.value = 0;
            this.m = 0;
            this.k = 0;
        }
        public Length(double value)
        {
            this.value = value;
            this.m = KtoM();
            this.k = MtoK();
        }
        public double KtoM()
        {
            double result = this.value * 0.621371;
            return result;
        }
        public double MtoK()
        {
            double result = this.value * 1.609344;
            return result;
        }
        public void LengthConv()
        {
            Console.WriteLine("KONWERSJA DLUGOSCI");
            Console.WriteLine("\t(1) Kilometry\t->\tMile");
            Console.WriteLine("\t(2) Mile\t->\tKilometry");
            Console.WriteLine();
            Console.Write("\t");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tPodaj wartosc odleglosci: ");
            double number = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Length a = new Length(number);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\t" + a.value + " km\t=\t" + a.m + " miles");
                    break;
                case 2:
                    Console.WriteLine("\t" + a.value + " miles\t=\t" + a.k + " km");
                    break;
                default:
                    Console.WriteLine("!!! ERROR !!!");
                    break;
            }
        }
    }
}
