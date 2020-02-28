using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1_S4
{
    class Operacja:Obliczenia
    {
        protected double cel, far, kilom, mila, kg, fun;
        Obliczenia operacja = new Obliczenia();
        public void Temperatura()
        {
            int jedynka = 0;
            while(jedynka !=3)
            {
                Console.WriteLine("(1) Celcjusze na Fahrenheite'y");
                Console.WriteLine("(2) Fahrenheite'y na Celcjusze");
                Console.WriteLine("(3) Zakoncz program");
                Console.WriteLine();
                jedynka = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch(jedynka)
                {
                    case 1:
                        Console.WriteLine("Podaj aktualna temperature do przeliczenia: ");
                        cel = double.Parse(Console.ReadLine());
                        operacja.celcjusz(cel);
                        break;
                    case 2:
                        Console.WriteLine("Podaj aktualna temperature do przeliczenia: ");
                        far = double.Parse(Console.ReadLine());
                        operacja.fahrenheit(far);
                        break;
                    case 3:
                        Console.WriteLine("Zakoncz program");
                        Console.WriteLine();
                        break;
                }
            }
        }
        public void Dlugosc()
        {
            int dwojka = 0;
            while (dwojka != 3)
            {
                Console.WriteLine("(1) Kilometry na mile");
                Console.WriteLine("(2) Mile na kilometry");
                Console.WriteLine("(3) Zakoncz program");
                Console.WriteLine();
                dwojka = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (dwojka)
                {
                    case 1:
                        Console.WriteLine("Podaj aktualna dlugosc do przeliczenia: ");
                        kilom = double.Parse(Console.ReadLine());
                        operacja.kilometr(kilom);
                        break;
                    case 2:
                        Console.WriteLine("Podaj aktualna dlugosc do przeliczenia: ");
                        mila = double.Parse(Console.ReadLine());
                        operacja.mile(mila);
                        break;
                    case 3:
                        Console.WriteLine("Zakoncz program");
                        Console.WriteLine();
                        break;
                }
            }
        }
        public void Masa()
        {
            int trojka = 0;
            while (trojka != 3)
            {
                Console.WriteLine("(1) Kilogram na funty");
                Console.WriteLine("(2) Funty na kilogramy");
                Console.WriteLine("(3) Zakoncz program");
                Console.WriteLine();
                trojka = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (trojka)
                {
                    case 1:
                        Console.WriteLine("Podaj aktualna mase do przeliczenia: ");
                        kg = double.Parse(Console.ReadLine());
                        operacja.kilogram(kg);
                        break;
                    case 2:
                        Console.WriteLine("Podaj aktualna mase do przeliczenia: ");
                        fun = double.Parse(Console.ReadLine());
                        operacja.funty(fun);
                        break;
                    case 3:
                        Console.WriteLine("Zakoncz program");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
