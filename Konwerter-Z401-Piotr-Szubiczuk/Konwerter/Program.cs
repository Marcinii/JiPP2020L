using System;
namespace Konwerter
{
    class Program
    {
        static double CnF()                                 //Funkcja przeliczajaca Celcjusze na Farenhaity
        {
            double fahrenhait, celcjusz;
            fahrenhait = double.Parse(Console.ReadLine());
            celcjusz = 5D / 9 * (fahrenhait - 32);
            return celcjusz;
        }
        static double FnC()                                 //Funkcja przeliczajaca Farenhaity na Celcjusze
        {
            double fahrenhait, celcjusz;
            celcjusz = double.Parse(Console.ReadLine());
            fahrenhait = 9D / 5 * celcjusz + 32;
            return fahrenhait;
        }
        static double KMnM()                                //Funkcja przeliczajaca Kilmetry na mile
        {
            double kilometr, mila;
            mila = double.Parse(Console.ReadLine());
            kilometr = mila / 1.609344D;
            return kilometr;
        }
        static double MnKM()                                //Funkcja przeliczajaca Mile na kilometry
        {
            double kilometr, mila;
            kilometr = double.Parse(Console.ReadLine());
            mila = kilometr * 1.609344D;
            return mila;
        }
        static double KGnF()                                //Funkcja przeliczajaca Kilogramy na Funty
        {
            double kilogram, funt;
            funt = double.Parse(Console.ReadLine());
            kilogram = 2.20462262D * funt;
            return kilogram;
        }
        static double FnKG()                                //Funkcja przeliczajaca Funty na Kilogramy
        {
            double kilogram, funt;
            kilogram = double.Parse(Console.ReadLine());
            funt = kilogram / 0.45359237D;
            return funt;
        }
        static void Main(string[] args)
        {
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
                        double wynik1 = CnF();              //Przypisanie wyniku funkcji do zmiennej
                        Console.WriteLine("Fahrenhaita to " + wynik1 + " Celcjuszy");   //Wyswietlenie wyniku  Analogicznie ponizej
                        break;
                    case "2":
                        Console.WriteLine("Podaj celcjusze");
                        double wynik2 = FnC();
                        Console.WriteLine("Celcjusza to " + wynik2 + " Fahrenhaitow");
                        break;
                    case "3":
                        Console.WriteLine("Podaj kilometry");
                        double wynik3 = KMnM();
                        Console.WriteLine("Kilometra to " + wynik3 + " mil");
                        break;
                    case "4":
                        Console.WriteLine("Podaj mile");
                        double wynik4 = MnKM();
                        Console.WriteLine("Mil to " + wynik4 + " kilometrow");
                        break;
                    case "5":
                        Console.WriteLine("Podaj kilogramy");
                        double wynik5 = KGnF();
                        Console.WriteLine("Kilogramow to " + wynik5 + " funtow");
                        break;
                    case "6":
                        Console.WriteLine("Podaj funty");
                        double wynik6 = FnKG();
                        Console.WriteLine("Funtow to " + wynik6 + " kilogramow");
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