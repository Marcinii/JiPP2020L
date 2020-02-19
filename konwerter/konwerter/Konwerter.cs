using System;
using System.Collections.Generic;
using System.Text;

namespace konwerter
{
    class Konwerter
    {
        private double wartosc;
        private double wynik;
        private string typ, wyn_typ;

        public double Wartosc
        {
            get => wartosc;
            set
            {
                if (this.Typ == "C")
                {
                    while (value < -273.15)
                    {
                        Console.WriteLine("Niepoprawna wartość nie można podać temperatury poniżej zera absolutnego -273.15");
                        Console.WriteLine("podaj poprawną wartość: ");
                        value = double.Parse(Console.ReadLine());
                    }
                }
                if (this.Typ == "F")
                {
                    while(value< -459.67)
                    {
                        Console.WriteLine("Niepoprawna wartość nie można podać temperatury poniżej zera absolutnego -459.67");
                        Console.WriteLine("podaj poprawną wartość: ");
                        value = double.Parse(Console.ReadLine());
                    }
                }
                if (Typ == "Km" || Typ == "Mil" || Typ == "Kg" || Typ == "Funt")
                {
                    while (value < 0)
                    {
                        Console.WriteLine("Wartość nie może być mniejsza lub równa 0");
                        Console.WriteLine("Podaj poprawną wartość większą");
                        value = double.Parse(Console.ReadLine());
                    }
                }
                wartosc = value;
            }
        }
        public double Wynik { get => wynik; set => wynik = value; }
        public string Typ 
        { 
            get => typ;
            set 
            {
                while(value != "C" && value != "F" && value != "Km" && value != "Mil" && value != "Kg" && value != "Funt")
                {
                    Console.WriteLine("Podano niepoprawną jednostkę");
                    Console.WriteLine("Podaj poprawną jednostkę (Km / Mil / C / F / Kg / Funt)");
                    value = Console.ReadLine();
                }
                typ = value;
            } 
        }
        public string Wyn_typ { get => wyn_typ; set => wyn_typ = value; }

        public Konwerter(double wartosc, string typ)
        {
            this.Wartosc = wartosc; this.Typ = typ;
        }
        public Konwerter()
        {
            Console.WriteLine("Podaj jednostke z której chcesz przeliczyć: (Km / Mil / C / F / Kg / Funt)");
            Typ = Console.ReadLine();
            Console.WriteLine("Podaj wartoś do przeliczenia:");
            Wartosc = double.Parse(Console.ReadLine());                        
        }
        public void daj_dane_i_konwertuj(double wartosc, string typ) 
        {
            this.Wartosc = wartosc; this.Typ = typ;
            this.konwersja();
        }
        public void konwersja()
        {
            if(Typ == "C")
            {
                Wyn_typ = "F";
                Wynik = (Wartosc * 1.8) + 32;  
            }
            if(Typ == "F")
            {
                Wyn_typ = "C";
                Wynik = (Wartosc - 32) / 1.8;
            }
            if(Typ == "Km")
            {
                Wyn_typ = "Mil";
                Wynik = Wartosc * 0.62137;
            }
            if(Typ == "Mil")
            {
                Wyn_typ = "Km";
                Wynik = Wartosc / 0.62137;
            }
            if(Typ == "Kg")
            {
                Wyn_typ = "Funta";
                Wynik = Wartosc * 2.2046;
            }
            if(Typ == "Funt")
            {
                Wyn_typ = "Kg";
                Wynik = Wartosc / 2.2046;
            }
        }
        public void daj_wynik()
        {
            Console.WriteLine(Wartosc.ToString() + " " + Typ + " = " + Wynik.ToString() + " " + Wyn_typ);
        }
    }
}