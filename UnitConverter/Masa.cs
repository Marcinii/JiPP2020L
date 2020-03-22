using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class Masa
    {
        public decimal Konwerter(string Z, string Do, decimal wynik)
        {
            return wynik;
        }
        public double ObliczFunty()
            {
                double kilogram, funt;
                Console.WriteLine("Podaj ile Kg -> funt: ");
                kilogram = double.Parse(Console.ReadLine());
                funt = kilogram * 2.20462262D;
                return funt;
            }
        public double ObliczKilogramy()
            {
                double kilogram, funt;
                Console.WriteLine("Podaj ile funtow -> kg: ");
                funt = double.Parse(Console.ReadLine());
                kilogram = funt / 2.20462262D;
                return kilogram;
            }
    }
}
