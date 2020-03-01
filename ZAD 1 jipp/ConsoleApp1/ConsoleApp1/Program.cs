using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Konverter tmp = new Konverter();
            Console.WriteLine("Konwerter jednostek. Wybierz jednostke(wpisz liczbe obok jednostki) ktora chcesz przekonwertowac z podanych: 1 celcjusz, 2 farenheit, 3 km, 4 mil,5 kg, 6 funt");
            string jednostka = Console.ReadLine();
            Console.WriteLine("podaj ilosc");
            int liczba = Convert.ToInt32(Console.ReadLine());
            tmp.WpiszDane(liczba, jednostka);
            tmp.Konwersja();
            Console.ReadKey();


            
        }


    }
    class Konverter
    {
        double Wartosc;
        string Jednostka;

        
        public void WpiszDane(double W1, string Jed)
        {
            Wartosc = W1;
            Jednostka = Jed;
        }
        public void Konwersja()
        {
            double Wynik = 0;
            switch (Jednostka)
            {
                case "1":
                    Wynik = Wartosc * (9 / 5) + 32;
                    Console.WriteLine(Wartosc+" celcjuszy to "+Wynik+" farenheita ");
                    break;
                case "2":
                    Wynik = (Wartosc - 32) / 1.8;
                    Console.WriteLine(Wartosc + " farenheita to" + Wynik + " celcjuszy ");
                    break;
                case "3":
                    Wynik = Wartosc / 1.609;
                    Console.WriteLine(Wartosc + " kilometrow to " + Wynik + " mil ");
                    break;
                case "4":
                    Wynik = Wartosc * 1.609;
                    Console.WriteLine(Wartosc + " mili to " + Wynik + " kilometrow ");
                    break;
                case "5":
                    Wynik = Wartosc * 2.442;
                    Console.WriteLine(Wartosc + " kilogramow to " + Wynik + " funtow ");
                    break;
                case "6":
                    Wynik = Wartosc / 2.442;
                    Console.WriteLine(Wartosc + " funtow to " + Wynik + " kilogramow ");
                    break;

            }
        }

    }
}