using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD_1
{
    class Konwerter
    {
        double dana, wynik;
        public Konwerter() { }
        public void konwertuj_na_C(double dana)
        {
            this.dana = dana;
            wynik = (dana - 32) / 1.8;
            Console.WriteLine(this.dana.ToString() + "F" + " = " + wynik.ToString() + "C");
        }
        public void konwertuj_na_F(double dana)
        {
            this.dana = dana;
            wynik = (dana * 1.8) + 32;
            Console.WriteLine(this.dana.ToString() + "C" + " = " + wynik.ToString() + "F");
        }
        public void konwertuj_na_Funty(double dana)
        {
            this.dana = dana;
            wynik = dana * 2.2046;
            Console.WriteLine(this.dana.ToString() + "Kg" + " = " + wynik.ToString() + "Funta");
        }
        public void konwertuj_na_Kg(double dana)
        {
            this.dana = dana;
            wynik = dana / 2.2046;
            Console.WriteLine(this.dana.ToString() + "Funta" + " = " + wynik.ToString() + "Kg");
        }
        public void konwertuj_na_Kilometry(double dana)
        {
            this.dana = dana;
            wynik = dana * 1.61;
            Console.WriteLine(this.dana.ToString() + "Mil" + " = " + wynik.ToString() + "Km");
        }
        public void konwertuj_na_Mile(double dana)
        {
            this.dana = dana;
            wynik = dana * 0.62137;
            Console.WriteLine(this.dana.ToString() + "Km" + " = " + wynik.ToString() + "Mil");
        }
    }
}
