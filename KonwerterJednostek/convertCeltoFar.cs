using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    class convertCeltoFar
    {
        public void conCeltoFar()
        {
            string input1, input2;
            int celsjusz, fahrenheit;
            double wyjscie = 0;
            Console.WriteLine("1. Konwertuj skala Celsjusz na skala Farenheita 2. Konwertuj skala Farenheita na skale Celsjusza.");
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    Console.WriteLine("Wpisz stopnie Celsujesza: ");
                    input1 = Console.ReadLine();
                    celsjusz = Convert.ToInt32(input1);
                    wyjscie = (celsjusz * 1.8) + 32;
                    Console.WriteLine(wyjscie);
                    break;
                case "2":
                    Console.WriteLine("Wpisz stopnie Fahrenheita: ");
                    input2 = Console.ReadLine();
                    fahrenheit = Convert.ToInt32(input2);
                    wyjscie = (fahrenheit - 32) / 1.8;
                    Console.WriteLine(wyjscie);
                    break;
                default:
                    break;
            }
        }
    }
}