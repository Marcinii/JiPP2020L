using System;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            int zmiana;
            Console.WriteLine("konwersja: 1. c <-> f, 2. km <-> mil, 3. kg <-> f" );
            zmiana = Convert.ToInt32(Console.ReadLine());
            switch (zmiana)
            {
                case 1:
                    {
                        CFXD();
                        break;
                    }
                case 2:
                    {
                        kmmXD();
                        break;
                    }
                case 3:
                    {
                        kgfXD();
                        break;
                    }

                default:
                    break;
            }
        

        }

        public static void CFXD()
        {
            string zmiana;
            double wartosc;
            Console.WriteLine("Wprowadzasz C czy F?");
            zmiana = Console.ReadLine();
            Console.WriteLine($"Podaj wartosc " + zmiana);
            wartosc = Convert.ToInt32(Console.ReadLine());
            double wynik;

            switch (zmiana)
            {
                case "C":
                    {

                        wynik = (wartosc * 1.8) + 32;
                        break;
                    }
                case "F":
                    {

                        wynik = (wartosc / 1.8) + 32;
                        break;
                    }
                default:
                    {
                        wynik = 0;
                        break;
                    }
            }
            string wyjsce;
            if (zmiana == "C")
            {
                wyjsce = "F";
            }
            else
            {
                wyjsce = "C";
            }
            Console.WriteLine($"twoj wynik to: " + wynik + " " + wyjsce);
        }

        public static void kmmXD()
        {
            string zmiana;
            double wartosc;
            Console.WriteLine("Wprowadzasz km czy mil?");
            zmiana = Console.ReadLine();
            Console.WriteLine($"Podaj wartosc " + zmiana);
            wartosc = Convert.ToInt32(Console.ReadLine());
            double wynik;

            switch (zmiana)
            {
                case "km":
                    {

                        wynik = wartosc * 0.62137;
                        break;
                    }
                case "mil":
                    {

                        wynik = wartosc / 0.62137;
                        break;
                    }
                default:
                    {
                        wynik = 0;
                        break;
                    }
            }
            string wyjsce;
            if (zmiana == "km")
            {
                wyjsce = "mil";
            }
            else
            {
                wyjsce = "km";
            }
            Console.WriteLine($"twoj wynik to: " + wynik + " " + wyjsce);

        }

        public static void kgfXD()
        {
            string zmiana;
            double wartosc;
            Console.WriteLine("Wprowadzasz kg czy f?");
            zmiana = Console.ReadLine();
            Console.WriteLine($"Podaj wartosc " + zmiana);
            wartosc = Convert.ToInt32(Console.ReadLine());
            double wynik;

            switch (zmiana)
            {
                case "kg":
                    {

                        wynik = wartosc * 2.20462262;
                        break;
                    }
                case "f":
                    {

                        wynik = wartosc / 2.20462262;
                        break;
                    }
                default:
                    {
                        wynik = 0;
                        break;
                    }
            }
            string wyjsce;
            if (zmiana == "kg")
            {
                wyjsce = "f";
            }
            else
            {
                wyjsce = "kg";
            }
            Console.WriteLine($"twoj wynik to: " + wynik + " " + wyjsce);

        }
    }
}
