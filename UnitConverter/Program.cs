using System;

namespace UnitConverter
{
    class Program
    {
        static double ObliczenieCelcjuszy()
        {
            double Fahrenhait, Celcjusz;
            Fahrenhait = double.Parse(Console.ReadLine());
            Celcjusz = 5D / 9 * (Fahrenhait - 32);
            return Celcjusz;
        }

        static double ObliczFahrenhait()
        {
            double Fahrenhait, Celcjusz;
            Celcjusz = double.Parse(Console.ReadLine());
            Fahrenhait = 9D / 5 * Celcjusz +32;
            return Fahrenhait;
        }

        static double ObliczKilometry()
        {
            double kilometr, mila;
            mila = double.Parse(Console.ReadLine());
            kilometr = mila / 1.609344D;
            return kilometr;
        }

        static double ObliczMile()
        {
            double kilometr, mila;
            kilometr = double.Parse(Console.ReadLine());
            mila = kilometr * 1.609344D;
            return mila;
        }

        static double ObliczKilogramy()
        {
            double kilogram, funt;
            funt = double.Parse(Console.ReadLine());
            kilogram = 2.20462262D * funt;
            return kilogram;
        }
        static double ObliczFunty()
        {
            double kilogram, funt;
            kilogram = double.Parse(Console.ReadLine());
            funt = kilogram / 0.45359237D;
            return funt;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("CO CHCESZ ZAMIENIC?\n");
            Console.WriteLine("1. Celcjusze na Fahrenhaity?");
            Console.WriteLine("2. Fahrenhaity na Celcjusze?");
            Console.WriteLine("3. Kilometry na mile?");
            Console.WriteLine("4. Mile na kilometry?");
            Console.WriteLine("5. Kilogram na funt?");
            Console.WriteLine("6. Funt na kilogram?");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Podaj ile Fahrenhaity na Celcjusze");
                    double wynik1 = ObliczenieCelcjuszy();
                    Console.WriteLine("Fahrenhaita to "+ wynik1 + " Celcjuszy");
                    break;

                case "2":
                    Console.WriteLine("Podaj ile Celcjuszy na Fahrenhaity");
                    double wynik2 = ObliczFahrenhait();
                    Console.WriteLine("Celcjusza to " + wynik2 + " Fahrenhaitow");
                    break;

                case "3":
                    Console.WriteLine("Podaj ile Kilometrow na mile");
                    double wynik3 = ObliczKilometry();
                    Console.WriteLine("Kilometra to " + wynik3 + " mil");
                    break;

                case "4":
                    Console.WriteLine("Podaj ile Mil to kilometrow");
                    double wynik4 = ObliczMile();
                    Console.WriteLine("Mil to " + wynik4 + " kilometrow");
                    break;

                case "5":
                    Console.WriteLine("Podaj ile kilogramow to funt");
                    double wynik5 = ObliczKilogramy();
                    Console.WriteLine("Kilogramow to " + wynik5 + " funtow");
                    break;

                case "6":
                    Console.WriteLine("Podaj ile funtow to kilogram");
                    double wynik6 = ObliczFunty();
                    Console.WriteLine("Funtow to " + wynik6 + " kilogramow");
                    break;

                default:
                    Console.WriteLine("Zly wybor, wybierz jeszcze raz");
                    break;
            }

            Console.ReadKey();

        }
    }
}
