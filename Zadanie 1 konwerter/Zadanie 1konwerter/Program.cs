using System;

namespace ZAD_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double dana;
            int wybor;
            Konwerter konwerter = new Konwerter();
            Console.WriteLine("KONWERTER JEDNOSTEK" +
            "\n Wybierz co chcesz zrobić (1 - 6)" +
            "\n 1. Konwersja stopni (F na C)" +
            "\n 2. Konwersja stopni (C na F)" +
            "\n 3. Konwersja masy (Kilogramy na Funty)" +
            "\n 4. Konwersja masy (Funty na Kilogramy)" +
            "\n 5. Konwersja odległości (Kilometry na Mile)" +
            "\n 6. Konwersja odległości (Mile na Kilometry)");
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
                {
                    case 1:
                        {
                            Console.WriteLine("Podaj wartość do przeliczenia: ");
                            dana = double.Parse(Console.ReadLine());
                            konwerter.konwertuj_na_C(dana);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Podaj wartość do przeliczenia: ");
                            dana = double.Parse(Console.ReadLine());
                            konwerter.konwertuj_na_F(dana);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Podaj wartość do przeliczenia: ");
                            dana = double.Parse(Console.ReadLine());
                            konwerter.konwertuj_na_Funty(dana);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Podaj wartość do przeliczenia: ");
                            dana = double.Parse(Console.ReadLine());
                            konwerter.konwertuj_na_Kg(dana);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Podaj wartość do przeliczenia: ");
                            dana = double.Parse(Console.ReadLine());
                            while (dana < 0)
                            {
                                Console.WriteLine("Podaj wartość większą od zera:");
                                dana = double.Parse(Console.ReadLine());
                            }
                            konwerter.konwertuj_na_Mile(dana);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Podaj wartość do przeliczenia: ");
                            dana = double.Parse(Console.ReadLine());
                            while (dana < 0)
                            {
                                Console.WriteLine("Podaj wartość większą od zera:");
                                dana = double.Parse(Console.ReadLine());
                            }
                            konwerter.konwertuj_na_Kilometry(dana);
                            break;
                        }
            }            
        }
    }
}