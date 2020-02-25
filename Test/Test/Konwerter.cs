using System;
using System.Collections.Generic;
using System.Text;

namespace konwerter
{
    class Konwerter
    {
        private double wartosc;
        private double przeliczenie;
        private string jednostka, znak_jed;

        //Element kodu zjmujacy sie zmienna Wartosc
        public double Wartosc
        {
            //Odebranie wartosci oraz zabezpeczenie (Wyjatki)
            get => wartosc;
            set
            {
                
                if (this.Jednostka == "C")
                {
                    while (value < -273)
                    {
                        Console.WriteLine("Zła warość: ");
                        value = double.Parse(Console.ReadLine());
                    }
                }
                if (this.Jednostka == "F")
                {
                    while (value < -459)
                    {
                        Console.WriteLine("Zła warość: ");
                        value = double.Parse(Console.ReadLine());
                    }
                }
                if (Jednostka == "Km" 
                    || Jednostka == "Mil" 
                    || Jednostka == "Kg" 
                    || Jednostka == "Funt")
                {
                    while (value < 0)
                    {
                        Console.WriteLine("Zła warość: ");
                        value = double.Parse(Console.ReadLine());
                    }
                }
                wartosc = value;
            }
        }
        public double Przeliczenie
        { 
            get => przeliczenie;
            set => przeliczenie = value; 
        }
        //Element kodu zjmujacy sie zmienna Jednostka
        public string Jednostka
        {
            get => jednostka;
            set
            {
                //Zabezpieczenie przed błędem
                while (value != "C" 
                    && value != "F" 
                    && value != "Km" 
                    && value != "Mil" 
                    && value != "Kg" 
                    && value != "Funt")
                {
                    Console.WriteLine("Zła warość: ");
                    Console.WriteLine("Podaj poprawną jednostkę (Km / Mil / C / F / Kg / Funt)");
                    value = Console.ReadLine();
                }
                jednostka = value;
            }
        }
        public string Znak_jed 
        { 
            get => znak_jed;
            set => znak_jed = value; 
        }
        public Konwerter() //Konstruktor 
        {
            Console.WriteLine("Co chcesz przeliczyc na co?: (Km / Mil; C / F; Kg / Funt)");
            Jednostka = Console.ReadLine();
            Console.WriteLine("Wartość:");
            Wartosc = double.Parse(Console.ReadLine());
        }
        //Otrzymuje dane od użytkownika, zapisuje w pamieci i dalej wykonuje funkcje konwersja
        //Konwersja
        public void konwersja()
        {
            if (Jednostka == "C")
            {
                Znak_jed = "F";
                Przeliczenie = (Wartosc * 1.8) + 32;
            }
            if (Jednostka == "F")
            {
                Znak_jed = "C";
                Przeliczenie = (Wartosc - 32) / 1.8;
            }
            if (Jednostka == "Km")
            {
                Znak_jed = "Mil";
                Przeliczenie = Wartosc * 0.6;
            }
            if (Jednostka == "Mil")
            {
                Znak_jed = "Km";
                Przeliczenie = Wartosc / 0.6;
            }
            if (Jednostka == "Kg")
            {
                Znak_jed = "Funt";
                Przeliczenie = Wartosc * 2.2;
            }
            if (Jednostka == "Funt")
            {
                Znak_jed = "Kg";
                Przeliczenie = Wartosc / 2.2;
            }
        }
        //Wypisanie wyniku
        public void wynik()
        {
            Console.WriteLine(Wartosc.ToString() + " " + Jednostka + " = " + Przeliczenie.ToString() + " " + Znak_jed);
        }
    }
}