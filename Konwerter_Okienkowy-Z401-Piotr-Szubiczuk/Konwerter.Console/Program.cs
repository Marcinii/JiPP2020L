using System;
using System.Collections.Generic;


namespace Konwerter
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Ikonwenter> konw = new List<Ikonwenter>()
            {
                new CnF(),
                new FnC(),
                new FnKG(),
                new KGnF(),
                new KMnM(),
                new MnKM()

            };
            while (true)                                    //Petla ktora nie konczy programu po wykonaniu jednego przeliczenia. Aby zakonczyc jej wykonywanie nalezy wybrac "0"
            {
                Console.WriteLine("\nCo zamieniamy?\n");    //Wyswietlanie dostepnych opcji do wyboru
                Console.WriteLine("1. Fahrenhaity na celcjusze");
                Console.WriteLine("2. Celcjusze na fahrenhaity?");
                Console.WriteLine("3. Kilometry na mile?");
                Console.WriteLine("4. Mile na kilometry?");
                Console.WriteLine("5. Kilogram na funt?");
                Console.WriteLine("6. Funt na kilogram?");
                Console.WriteLine("0. Wyjscie");
                switch (Console.ReadLine())                 //zczytanie wyboru
                {
                    case "1":                               //wywolanie wyboru
                        Console.WriteLine("Podaj farenhaity");
                        double wartosc = Convert.ToDouble(Console.ReadLine());
                        FnC kon1 = new FnC();
                        Console.WriteLine("Fahrenhaita to " + (kon1.Konwer("z", "na", wartosc)).ToString() + " Celcjuszy");   //Wyswietlenie wyniku  Analogicznie ponizej
                        break;
                    case "2":
                        Console.WriteLine("Podaj Celcjuze");
                        double wartosc2 = Convert.ToDouble(Console.ReadLine());
                        CnF kon2 = new CnF();
                        Console.WriteLine("Celcjusza to " + (kon2.Konwer("z", "na", wartosc2)).ToString() + " Fahrenhaitow");   //Wyswietlenie wyniku  Analogicznie ponizej
                        break;
                    case "3":
                        Console.WriteLine("Podaj Funty");
                        double wartosc3 = Convert.ToDouble(Console.ReadLine());
                        FnKG kon3 = new FnKG();
                        Console.WriteLine("Funtow to " + (kon3.Konwer("z", "na", wartosc3)).ToString() + " Kilogramow");   //Wyswietlenie wyniku  Analogicznie ponizej
                        break;
                    case "4":
                        Console.WriteLine("Podaj Kilogramy");
                        double wartosc4 = Convert.ToDouble(Console.ReadLine());
                        KGnF kon4 = new KGnF();
                        Console.WriteLine("Kilogramow to " + (kon4.Konwer("z", "na", wartosc4)).ToString() + " Funtow");   //Wyswietlenie wyniku  Analogicznie ponizej
                        break;
                    case "5":
                        Console.WriteLine("Podaj Kilomety");
                        double wartosc5 = Convert.ToDouble(Console.ReadLine());
                        KMnM kon5 = new KMnM();
                        Console.WriteLine("Kilometorw to " + (kon5.Konwer("z", "na", wartosc5)).ToString() + " Mil");   //Wyswietlenie wyniku  Analogicznie ponizej
                        break;
                    case "6":
                        Console.WriteLine("Podaj Mile");
                        double wartosc6 = Convert.ToDouble(Console.ReadLine());
                        MnKM kon6 = new MnKM();
                        Console.WriteLine("Mil to " + (kon6.Konwer("z", "na", wartosc6)).ToString() + " Kilometrow");   //Wyswietlenie wyniku  Analogicznie ponizej
                        break;
                    case "0":
                        Environment.Exit(0);                //Wybranie 0 powoduje zakonczenie pogramu
                        break;
                    default:
                        Console.WriteLine("Zly wybor");      //Wybranie innej liczby niz sa dostepne wyswietla komuniakt
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
