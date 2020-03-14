using System;
using System.Collections.Generic;
using System.Text;
using Konwerter.Logic;

namespace LAB_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IKonwertery> converters = new List<IKonwertery>()
            {
                new Konwerter_Mas(),
                new Konwerter_Mocy(),
                new Konwerter_Odleglosci(),
                new Konwerter_Temperatur()
            };
            string z_jednostki, do_jednostki;
            double dana;
            string init_wybor, init_dana;
            int wybor;
            Console.WriteLine("KONWERTER JEDNOSTEK" +
            "\n Wybierz co chcesz zrobić (1 - 4)" +
            "\n 1. Konwersja Mas " +
            "\n 2. Konwersja Mocy " +
            "\n 3. Konwersja Odległości " +
            "\n 4. Konwersja Temperatur ");
            init_wybor = Console.ReadLine();
            while (int.TryParse(init_wybor, out wybor) == false) 
            {
                Console.WriteLine("Podaj poprawną wartosć");
                init_wybor = Console.ReadLine();                
            }
            if (int.TryParse(init_wybor, out wybor) == true)
            {
                while (wybor < 1 || wybor > 4)
                {
                    Console.WriteLine("Podaj wartość z przedziału 1-4 ");
                    init_wybor = Console.ReadLine();
                    while (int.TryParse(init_wybor, out wybor) == false)
                    {
                        Console.WriteLine("Podaj poprawną wartosć");
                        init_wybor = Console.ReadLine();
                    }
                }
            }
            Console.WriteLine("Podaj wartość do przeliczenia: ");
            init_dana = Console.ReadLine();
            while (double.TryParse(init_dana, out dana) == false)
            {
                Console.WriteLine("Podaj poprawną wartość ");
                init_dana = Console.ReadLine();
            }
            switch (wybor)
            {
                case 1:
                    {
                        Console.WriteLine("Z jakiej jednostki chcesz kontertować? (Kg, F, dkg)");                            
                        z_jednostki = Console.ReadLine();
                        Console.WriteLine("Do jakiej jednostki chcesz kontertować? (Kg, F, dkg)");
                        do_jednostki = Console.ReadLine();
                        converters[wybor-1].Konwertuj_i_Pokaz(z_jednostki, do_jednostki, dana);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Z jakiej jednostki chcesz kontertować? (KM, W, kW)");
                        z_jednostki = Console.ReadLine();
                        Console.WriteLine("Do jakiej jednostki chcesz kontertować? (KM, W, kW)");
                        do_jednostki = Console.ReadLine();
                        converters[wybor - 1].Konwertuj_i_Pokaz(z_jednostki, do_jednostki, dana);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Z jakiej jednostki chcesz kontertować? (Km, Mi, ft)");
                        z_jednostki = Console.ReadLine();
                        Console.WriteLine("Do jakiej jednostki chcesz kontertować? (Km, Mi, ft)");
                        do_jednostki = Console.ReadLine();
                        converters[wybor - 1].Konwertuj_i_Pokaz(z_jednostki, do_jednostki, dana);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Z jakiej jednostki chcesz kontertować? (C, F, K)");
                        z_jednostki = Console.ReadLine();
                        Console.WriteLine("Do jakiej jednostki chcesz kontertować? (C, F, K)");
                        do_jednostki = Console.ReadLine();
                        converters[wybor - 1].Konwertuj_i_Pokaz(z_jednostki, do_jednostki, dana);
                        break;
                    }
            }                           
        }
    }
}