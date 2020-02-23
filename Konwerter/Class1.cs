using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Konwerter
    {
        private double temperatura;
        private double odleglosc;
        private double waga;


        public Konwerter()
        {
            Console.WriteLine("Wybierz jedną opcję:\n1. Konwerter temperatury");
            Console.WriteLine("2. Konwerter odległości\n3. Konwerter wagi");
            int opcja = Convert.ToInt32(Console.ReadLine());
            while (opcja < 1 || opcja > 3)
            {
                Console.WriteLine("Nie ma takiej opcji!\nWybierz jedną opcję:\n1. Konwerter temperatury");
                Console.WriteLine("2. Konwerter odległości\n3. Konwerter wagi");
                opcja = Convert.ToInt32(Console.ReadLine());
            }
            switch (opcja)
            {
                case 1:
                    Console.WriteLine("Wynik = " + Convert.ToString(Temperatura()));
                    break;
                case 2:
                    Console.WriteLine("Wynik = " + Convert.ToString(Odleglosc()));
                    break;
                case 3:
                    Console.WriteLine("Wynik = " + Convert.ToString(Waga()));
                    break;
                default: break;
            }
        }

        private double Temperatura()
        {
            if (menu(1))
            {
                Console.WriteLine("Wprowadź temperaturę w Fahrenheitach:");
                temperatura = Convert.ToDouble(Console.ReadLine());
                return Math.Round((temperatura - 32) / 1.8, 2);
            }
            else
            {
                Console.WriteLine("Wprowadź temperaturę w Celsiuszach:");
                temperatura = Convert.ToDouble(Console.ReadLine());
                return Math.Round((temperatura * 1.8) + 32, 2);
            }
        }

        private double Odleglosc()
        {
            if (menu(2))
            {
                Console.WriteLine("Wprowadź liczbe kilometrów:");
                odleglosc = Convert.ToDouble(Console.ReadLine());
                return Math.Round(odleglosc * 0.62137, 2);
            }
            else
            {
                Console.WriteLine("Wprowadź liczbe mil:");
                odleglosc = Convert.ToDouble(Console.ReadLine());
                return Math.Round(odleglosc / 0.62137, 2);
            }
        }

        private double Waga()
        {
            if (menu(3))
            {
                Console.WriteLine("Wprowadź ilość kilogramów:");
                waga = Convert.ToDouble(Console.ReadLine());
                return Math.Round(waga * 2.2046, 2);
            }
            else
            {
                Console.WriteLine("Wprowadź ilość funtów:");
                waga = Convert.ToDouble(Console.ReadLine());
                return Math.Round(waga / 2.2046, 2);
            }
        }

        private bool menu(int mode)
        {
            string tekst;
            if (mode == 1)
            {
                tekst = "1. Fahrenheit na Celsiusz\n2. Celsiusz na Fahrenheit";
            }
            else if (mode == 2)
            {
                tekst = "1. Kilometry na Mile\n2. Mile na Kilometry";
            }
            else
            {
                tekst = "1. Kilogramy na Funty\n2. Funty na Kilogramy";
            }

            Console.WriteLine("Wybierz jedną opcje:");
            Console.WriteLine(tekst);
            int wybor = Convert.ToInt32(Console.ReadLine());
            while (wybor != 1 && wybor != 2)
            {
                Console.WriteLine("Nie ma takiej opcji!\nWybierz jedną opcje:");
                Console.WriteLine(tekst);
                wybor = Convert.ToInt32(Console.ReadLine());
            }
            if (wybor == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
