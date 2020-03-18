using System;

namespace Project
{
    class Program
    {
        public static void Main()
        {
            int choice = 0, jednostka = 0;
            double zmienna = 0;
            bool shouldContinue = true;
            List <IKonwerter> Konwertery = new List<IKonwerter>()
            {
                new LenKonwerter(),
                new TempKonwerter(),
                new MassKonwerter()
            };

            while (shouldContinue)
            {
                Konwerter konw = new Konwerter();
                Console.WriteLine("Witaj w menu konwertera:\n\n");
                foreach(IKonwerter I in Konwertery)
                {
                    Console.WriteLine(I.Name);
                }
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
                        shouldContinue = false;
                        break;
                }
                Console.ReadLine();

            }
        }
    }
}