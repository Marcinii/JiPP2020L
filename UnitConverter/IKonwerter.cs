using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public interface IKonwerter
    {
        public double ObliczFahrenhait()
        {
            double Fahrenhait, Celcjusz;
            Console.WriteLine("Podaj liczbe do konwersji: ");
            Celcjusz = double.Parse(Console.ReadLine());
            Fahrenhait = 9D / 5 * Celcjusz + 32;
            return Fahrenhait;
        }
    }
}
