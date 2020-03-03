using System;

namespace Project
{
    class Program
    {
        public static void Main()
        {
            int choice = 0, jednostka = 0;
            double zmienna = 0;
            Konwerter konw = new Konwerter();
            Console.WriteLine("Witaj w menu konwertera:\n\n1 - Konwersja Temperatury\n2 - Konwersja odleglosci\n3 - Konwersja masy");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Wpisz teraz wartosc a nastepnie podaj na jaka chcesz zamienic (1-Fahrenheit,2-Celsjusz)");
                    zmienna = Convert.ToInt32(Console.ReadLine());
                    jednostka = Convert.ToInt32(Console.ReadLine());
                    konw.VarTemp(zmienna, jednostka);
                    break;
                case 2:
                    Console.WriteLine("Wpisz teraz wartosc a nastepnie podaj na jaka chcesz zamienic (1-mile,2-kilometry)");
                    zmienna = Convert.ToInt32(Console.ReadLine());
                    jednostka = Convert.ToInt32(Console.ReadLine());
                    konw.VarLeng(zmienna, jednostka);
                    break;
                case 3:
                    Console.WriteLine("Wpisz teraz wartosc a nastepnie podaj na jaka chcesz zamienic (1-funty,2-kilogramy)");
                    zmienna = Convert.ToInt32(Console.ReadLine());
                    jednostka = Convert.ToInt32(Console.ReadLine());
                    konw.VarMass(zmienna, jednostka);
                    break;
                default:
                    Console.WriteLine("Wybrales niepoprawna opcje");
                    break;
            }
            Console.ReadLine();
        }
    }
}