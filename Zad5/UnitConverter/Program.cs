using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Logic;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldContinue = true;

            while (shouldContinue)
            {
                Console.WriteLine("Wybierz opcję: ");
                Console.WriteLine("(1) F => C");
                Console.WriteLine("(2) C => F");
                Console.WriteLine("(3) Km => Mi");
                Console.WriteLine("(4) Mi => Km");
                Console.WriteLine("(5) Kg => Funty");
                Console.WriteLine("(6) Funty => Kg");
                Console.WriteLine("(7) Dec => Mi");
                Console.WriteLine("(8) Mi => Dec");
                Console.WriteLine("(9) Pa => hPa");
                Console.WriteLine("(0) hPa => Pa");

                string inputChoice = Console.ReadLine();
                Console.WriteLine("Podaj liczbę do konwersji: ");
                string inputValue = Console.ReadLine();

                int choice = int.Parse(inputChoice);
                double value = double.Parse(inputValue);

                TemperatureConverter t = new TemperatureConverter();
                LengthConverter l = new LengthConverter();
                Weight w = new Weight();
                Pressure p = new Pressure();

                switch (choice)
                {
                    case 1:
                        //Console.WriteLine("Fahrenheit => Celsius: {0}", value * 1.8 + 32);
                        Console.WriteLine((t.Convert(t.Units[0], t.Units[1], value)).ToString());
                        break;
                    case 2:
                        //Console.WriteLine("Celsius => Fahrenheit: {0}", (value - 32) / 1.8);
                        Console.WriteLine((t.Convert(t.Units[1], t.Units[0], value)).ToString());
                        break;
                    case 3:
                        //Console.WriteLine("Kilometers => Miles: {0}", value * 0.62137);
                        Console.WriteLine((l.Convert(l.Units[0], l.Units[1], value)).ToString());
                        break;
                    case 4:
                        //Console.WriteLine("Miles => Kilometers: {0}", value / 0.62);
                        Console.WriteLine((l.Convert(l.Units[1], l.Units[0], value)).ToString());
                        break;
                    case 5:
                        //Console.WriteLine("Kilograms => Pounds: {0}", value * 2.20);
                        Console.WriteLine((w.Convert(w.Units[0], w.Units[1], value)).ToString());
                        break;
                    case 6:
                        //Console.WriteLine("Pounds => Kilograms: {0}", value / 2.2046);
                        Console.WriteLine((w.Convert(w.Units[1], w.Units[0], value)).ToString());
                        break;
                    case 7:
                        //Console.WriteLine("Decymeters => Miles: {0}", value * 0.62137 * 10000);
                        Console.WriteLine((l.Convert(l.Units[2], l.Units[1], value)).ToString());
                        break;
                    case 8:
                        //Console.WriteLine("Miles => Decymeters: {0}", value / 0.62137 / 100000);
                        Console.WriteLine((l.Convert(l.Units[1], l.Units[2], value)).ToString());
                        break;
                    case 9:
                        Console.WriteLine((p.Convert(p.Units[0], p.Units[1], value)).ToString());
                        break;
                    case 0:
                        Console.WriteLine((p.Convert(p.Units[1], p.Units[0], value)).ToString());
                        break;
                    default:
                        shouldContinue = false;
                        break;
                }
            }
        }
    }
}
