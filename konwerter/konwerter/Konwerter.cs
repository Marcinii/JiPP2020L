using System;
using System.Collections.Generic;
using System.Text;

namespace konwerter
{
    class Konwerter
    {
        double wartosc, wynik;
        string typ, wyn_typ;
        public Konwerter()
        {
            Console.WriteLine("Podaj jednostke z której chcesz przeliczyć: (Km / Mil / C / F / Kg / Funt)");
            typ = Console.ReadLine();
            if (typ == "C")
            {
                Console.WriteLine("Podaj wartoś do przeliczenia:");
                wartosc = double.Parse(Console.ReadLine());
                while (wartosc < -273.15)
                {
                    Console.WriteLine("Błąd wartość nie może być mniejsza od zera absolutnego");
                    Console.WriteLine("Podaj poprawną wartość");
                    wartosc = double.Parse(Console.ReadLine());
                }
            }
            if (typ == "F")
            {
                Console.WriteLine("Podaj wartoś do przeliczenia:");
                wartosc = double.Parse(Console.ReadLine());
                while (wartosc < -459.67)
                {
                    Console.WriteLine("Błąd wartość nie może być mniejsza od zera absolutnego");
                    Console.WriteLine("Podaj poprawną wartość");
                    wartosc = double.Parse(Console.ReadLine());
                }
            }
            if (typ == "Km" || typ == "Mil" || typ == "Kg" || typ == "Funt")
            {
                Console.WriteLine("Podaj wartoś do przeliczenia:");
                wartosc = double.Parse(Console.ReadLine());
                while (wartosc <= 0)
                {
                    Console.WriteLine("Błąd wartość nie może być mniejsza lub równa 0");
                    Console.WriteLine("Podaj poprawną wartość większą od zera");
                    wartosc = double.Parse(Console.ReadLine());
                }
            }
        }
        public void daj_dane(double wartosc, string typ) 
        {
            this.wartosc = wartosc; this.typ = typ;
        }
        public void konwersja()
        {
            if(typ == "C")
            {
                wyn_typ = "F";
                wynik = (wartosc * 1.8) + 32;  
            }
            if(typ == "F")
            {
                wyn_typ = "C";
                wynik = (wartosc - 32) / 1.8;
            }
            if(typ == "Km")
            {
                wyn_typ = "Mil";
                wynik = wartosc * 0.62137;
            }
            if(typ == "Mil")
            {
                wyn_typ = "Km";
                wynik = wartosc / 0.62137;
            }
            if(typ == "Kg")
            {
                wyn_typ = "Funta";
                wynik = wartosc * 2.2046;
            }
            if(typ == "Funt")
            {
                wyn_typ = "Kg";
                wynik = wartosc / 2.2046;
            }
        }
        public void daj_wynik()
        {
            Console.WriteLine(wartosc.ToString() + " " + typ + " = " + wynik.ToString() + " " + wyn_typ);
        }
    }
}