using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class Odleglosc
    {
        public double ObliczKilometry()
        {
            double kilometr, mila;
            Console.WriteLine("Podaj ile mil to km: ");
            mila = double.Parse(Console.ReadLine());
            kilometr = mila * 1.609344D;
            return kilometr;
        }

        public double ObliczMile()
        {
            double kilometr, mila;
            Console.WriteLine("Podaj ile km to mil: ");
            kilometr = double.Parse(Console.ReadLine());
            mila = kilometr / 1.609344D;
            return mila;
        }
    }
}
