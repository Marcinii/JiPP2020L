using System;

namespace Project
{
    public class LenKonwerter : IKonwerter
    {
        public string Name => "Konwerter długości";

        public List<string> Units => new List<string>() { "km","mi" };
        public void VarUnit(double x, int y)
        {
            if (y == 0)
            {
                x *= 0.6214;
                Console.WriteLine("Długość w milach wynosi {0}", x);
            }
            else if (y == 1)
            {
                x *= 1.6093;
                Console.WriteLine("Długość w kilometrach wynosi {0}", x);
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek długości.");
            }
        }

        }
}
