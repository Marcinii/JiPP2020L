using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class Temperatura
    {
        public double Konwerter(string Z, string Do, double wartosc)
        {
            return (wartosc - 32) * 5 / 9 + 273.15;
        }
        public double ObliczFahrenhait()
        {
            double Fahrenhait, Celcjusz;
            Console.WriteLine("Podaj liczbe do konwersji: ");
            Celcjusz = double.Parse(Console.ReadLine());
            Fahrenhait = 9D / 5 * Celcjusz + 32;
            return Fahrenhait;
        }
        public double ObliczenieCelcjuszy()
        {
            double Fahrenhait, Celcjusz;
            Console.WriteLine("Podaj liczbe do konwersji: ");
            Fahrenhait = double.Parse(Console.ReadLine());
            Celcjusz = 5D / 9 * (Fahrenhait - 32);
            return Celcjusz;
        }
    }
}
