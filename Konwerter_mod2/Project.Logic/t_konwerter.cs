using System;
using System.Collections.Generic;

namespace Project
{
    public class TempKonwerter : IKonwerter
    {
        public string Name => "Konwerter temperatur";

        public List<string> Units => new List<string>()
        {
            "C",
            "F",
            "R"
        };
        public double VarUnit(double x, int y)
        {
            if (y == 0)
            {
                x = 9 * x/5 + 32;
                Console.WriteLine("Temperatura w stopniach Fahrenheita wynosi {0}", x);
                return x;
            }
            else if (y == 1)
            {
                x = (x + 273.15) * 1.8;
                Console.WriteLine("Temperatura w stopniach Rankine'a wynosi {0}", x);
                return x;
            }
            else if (y == 2)
            {
                x = (x - 32)*5/9;
                Console.WriteLine("Temperatura w stopniach Celsjusza wynosi {0}", x);
                return x;
            }
            else if (y == 3)
            {
                x = x + 273.15 * 1.8 - 32;
                Console.WriteLine("Temperatura w stopniach Rankine'a wynosi {0}", x);
                return x;
            }
            else if (y == 4)
            {
                x = x/1.8 - 273.15;
                Console.WriteLine("Temperatura w stopniach Celsjusza wynosi {0}", x);
                return x;
            }
            else if (y == 5)
            {
                x = x + 32 - 273.15 * 1.8;
                Console.WriteLine("Temperatura w stopniach Fahrenheita wynosi {0}", x);
                return x;
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek temperatury.");
                return x;
            }
        }

        }
}
