using System;
using System.Collections.Generic;

namespace Project
{
    public class LenKonwerter : IKonwerter
    {
        public string Name => "Konwerter długości";

        public List<string> Units => new List<string>() { "km","mi","cbl" };
        public double VarUnit(double x, int y)
        {
            if (y == 0)
            {
                x *= 0.6214;
                Console.WriteLine("Dlugosc w milach wynosi {0}", x);
                return x;
            }
            else if (y == 1)
            {
                x *= 0.0054;
                Console.WriteLine("Dlugosc w kablach wynosi {0}", x);
                return x;
            }
            else if (y == 2)
            {
                x *= 1.6093;
                Console.WriteLine("Dlugosc w kilometrach wynosi {0}", x);
                return x;
            }
            else if (y == 3)
            {
                x *= 8.6898;
                Console.WriteLine("Dlugosc w kablach wynosi {0}", x);
                return x;
            }
            else if (y == 4)
            {
                x *= 0.1852;
                Console.WriteLine("Dlugosc w kilometrach wynosi {0}", x);
                return x;
            }
            else if (y == 5)
            {
                x *= 0.1151;
                Console.WriteLine("Dlugosc w milach wynosi {0}", x);
                return x;
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek dlugosci.");
                return x;
            }
        }

        }
}
