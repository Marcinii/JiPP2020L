using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    class Konwerter
    {
        protected int numer;
        protected double celsjusz;
        protected double fahrenheit;
        protected double km;
        protected double mil;
        protected double kg;
        protected double funt;

        public Konwerter()
        {
            Console.WriteLine("Co chcesz przekonwertować?\n Celsjusz na Fahrenheit - wybierz 1\n Fahrenheit na Celsjusz - wybierz 2\n Kilometry na mile - wybierz 3\n Mile na kiloetry - wybierz 4\n Kilogramy na funty - wybierz 5\n Funty na kilogramy - wybierz 6." );
        }
        public double numeropcji()
        { 
            Console.WriteLine("Podaj numer wybranego konwertera");
            numer = int.Parse(Console.ReadLine());
            return numer;
        }

        public void konwerterjednostek()
        {
            switch (numer)
            {
                case 1:
                     Console.WriteLine("Podaj stopnie w skali Celsjusza.");
                     celsjusz = double.Parse(Console.ReadLine());
                     fahrenheit = celsjusz * 1.8 + 32;
                    Console.WriteLine(celsjusz.ToString() + "stopni Celsjusza to " + fahrenheit.ToString() + " stopni Fahrenheita.\n");
                    break;
                case 2:
                     Console.WriteLine("Podaj stopnie w skali Fahrenheita.");
                     fahrenheit = double.Parse(Console.ReadLine());
                     celsjusz = (fahrenheit -32)/ 1.8;
                    Console.WriteLine(fahrenheit.ToString() + "stopni Fahrenheita to " + celsjusz.ToString() + " stopni Celsjusza.\n");
                    break;
                case 3:
                     Console.WriteLine("Podaj odległość w kilometrach.");
                     km = double.Parse(Console.ReadLine());
                     mil = km * 0.62137;
                    Console.WriteLine(km.ToString() + " kilometrów to " + mil.ToString() + " mil.\n");
                    break;
                case 4:
                    Console.WriteLine("Podaj odległość w milach.");
                    mil = double.Parse(Console.ReadLine());
                    km = mil / 0.62137;
                    Console.WriteLine(mil.ToString() + " mil to " + km.ToString() + " kilometrów.\n");
                    break;
                case 5:
                    Console.WriteLine("Podaj wagę w kilogramach.\n");
                    kg = double.Parse(Console.ReadLine());
                    funt = kg * 2.2046;
                    Console.WriteLine(kg.ToString() + " kilogramów to " + funt.ToString() + " funtów.\n");
                    break;
                case 6:
                    Console.WriteLine("Podaj wagę w funtach.");
                    funt = double.Parse(Console.ReadLine());
                    kg = funt / 2.2046;
                    Console.WriteLine(funt.ToString() + " funtów to " + kg.ToString() + " kilogramów.\n");
                    break;
                default:
                    Console.WriteLine("Wybrano błędną opcję.\n");
                    break;
            }
        } 
    }
}
