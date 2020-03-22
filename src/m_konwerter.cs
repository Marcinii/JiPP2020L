using System;

namespace Project
{
    public class MassKonwerter : IKonwerter
    {
        public string Name => "Konwerter masy";

        public List<string> Units => new List<string>()
        {
            "kg",
            "f"
        };
        public void VarUnit(double x, int y)
        {
            if (y == 0)
            {
                x *= 2.2046;
                Console.WriteLine("Masa w funtach wynosi " + x);
            }
            else if (y == 1)
            {
                x *= 0.4536;
                Console.WriteLine("Masa w kilogramach wynosi " + x);

            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek temperatury.");
            }
        }

        }
}
