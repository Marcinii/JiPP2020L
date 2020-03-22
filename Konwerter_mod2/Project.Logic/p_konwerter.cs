using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class PowKonwerter : IKonwerter
    {
        public string Name => "Konwerter mocy";

        public List<string> Units => new List<string>()
        {
            "W",
            "KM",
            "BTU/h"
        };

        public double VarUnit(double x, int y)
        {
            if (y == 0)
            {
                x *= 0.6214;
                Console.WriteLine("Moc w koniach mechanicznych wynosi {0}", x);
                return x;
            }
            else if (y == 1)
            {
                x *= 0.0054;
                Console.WriteLine("Moc w brytyjskich jednostkach ciepla wynosi {0}", x);
                return x;
            }
            else if (y == 2)
            {
                x *= 1.6093;
                Console.WriteLine("Moc w watach wynosi {0}", x);
                return x;
            }
            else if (y == 3)
            {
                x *= 8.6898;
                Console.WriteLine("Moc w brytyjskich jednostkach ciepla wynosi {0}", x);
                return x;
            }
            else if (y == 4)
            {
                x *= 0.1852;
                Console.WriteLine("Moc w watach wynosi {0}", x);
                return x;
            }
            else if (y == 5)
            {
                x *= 0.1151;
                Console.WriteLine("Moc w koniach mechanicznych wynosi {0}", x);
                return x;
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek mocy.");
                return x;
            }
        }
    }
}
