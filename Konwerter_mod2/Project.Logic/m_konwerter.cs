using System;
using System.Collections.Generic;

namespace Project
{
    public class MassKonwerter : IKonwerter
    {
        public string Name => "Konwerter masy";

        public List<string> Units => new List<string>()
        {
            "kg",
            "f",
            "st."
        };
        public double VarUnit(double x, int y)
        {
            if (y == 0)
            {
                x *= 2.2046;
                Console.WriteLine("Masa w funtach wynosi {0}", x);
                return x;
            }
            else if (y == 1)
            {
                x *= 0.1575;
                Console.WriteLine("Masa w stone'ach wynosi {0}", x);
                return x;
            }
            else if (y == 2)
            {
                x *= 0.4536;
                Console.WriteLine("Masa w kilogramach wynosi {0}", x);
                return x;
            }
            else if (y == 3)
            {
                x *= 0.0714;
                Console.WriteLine("Masa w stone'ach wynosi {0}", x);
                return x;
            }
            else if (y == 4)
            {
                x *= 6.3503;
                Console.WriteLine("Masa w kilogramach wynosi {0}", x);
                return x;
            }
            else if (y == 5)
            {
                x *= 14;
                Console.WriteLine("Masa w funtach wynosi {0}", x);
                return x;
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek masy.");
                return x;
            }
        }

        }
}
