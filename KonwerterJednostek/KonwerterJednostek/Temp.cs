using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    class Temp
    {
        public double value;
        public double f;
        public double c;
        public Temp()
        {
            this.value = 0;
            this.c = 0;
            this.f = 0;
        }
        public Temp(double value)
        {
            this.value = value;
            this.c = FtoC();
            this.f = CtoF();
        }
        public double FtoC()
        {
            double result = (this.value - 32) * 5 / 9;
            return result;
        }
        public double CtoF()
        {
            double result = this.value * 9 / 5 + 32;
            return result;
        }
        public void TempConv()
        {
            Console.WriteLine("KONWERSJA TEMPERATURY");
            Console.WriteLine("\t(1) Celsjusz\t->\tFahrenheit");
            Console.WriteLine("\t(2) Fahrenheit\t->\tCelsjusz");
            Console.WriteLine();
            Console.Write("\t");

            string test = Console.ReadLine();

            int choice = Convert.ToInt32(test);
            Console.Write("\tPodaj wartosc temperatury: ");
            double number = Convert.ToDouble(Console.ReadLine().Replace('.',','));
            Temp a = new Temp(number);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\t" + a.value + " stC\t=\t" + a.f + " F");
                    break;
                case 2:
                    Console.WriteLine("\t" + a.value + " F\t=\t" + a.c + " stC");
                    break;
                default:
                    Console.WriteLine("!!! ERROR !!!");
                    break;
            }
        }
    }
}
