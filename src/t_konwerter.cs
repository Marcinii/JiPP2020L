using System;

namespace Project
{
    public class TempKonwerter : IKonwerter
    {
        public string Name => "Konwerter temperatur";

        public List<string> Units => new List<string>()
        {
            "C",
            "F"
        };
        public void VarUnit(double x, int y)
        {
            if (y == 0)
            {
                x = 9 * x/5 + 32;
                Console.WriteLine("Temperatura w stopniach Fahrenheita wynosi " + x);
            }
            else if (y == 1)
            {
                x = (x - 32)*5/9;
                Console.WriteLine("Temperatura w stopniach Celsjusza wynosi " + x);
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek temperatury.");
            }
        }

        }
}
