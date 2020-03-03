using System;

namespace Project
{
    public class Konwerter
    {
        public void VarTemp(double x, int y)
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

        public void VarLeng(double x, int y)
        {
            if (y == 0)
            {
                x = x/1.609344;
                Console.WriteLine("Dana odleglosc w milach wynosi " + x);
            }
            else if (y == 1)
            {
                x = x * 1.609344;
                Console.WriteLine("Dana odleglosc w kilometrach wynosi " + x);
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek odleglosci.");
            }
        }

        public void VarMass(double x, int y)
        {
            if (y == 0)
            {
                x = x/0.45359237;
                Console.WriteLine("Dana masa w funtach wynosi " + x);
            }
            else if (y == 1)
            {
                Console.WriteLine("Dana masa w kilogramach wynosi " + x);
            }
            else
            {
                Console.WriteLine("Nie obsluguje jeszcze innych jednostek masy.");
            }
        }
    }
}