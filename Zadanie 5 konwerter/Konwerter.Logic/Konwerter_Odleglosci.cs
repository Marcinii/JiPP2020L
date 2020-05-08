using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class Konwerter_Odleglosci :IKonwertery
    {
        double wynik, dana;
        public double Wynik { get => wynik; set => wynik = value; }
        public double Dana { get => dana; set => dana = value; }

        public void Konwertuj_i_Pokaz(string z_jednostki, string do_jednostki, double dana)
        {
            Konwertuj(z_jednostki, do_jednostki, dana);
            Console.WriteLine(dana.ToString() + " " + z_jednostki + " = " + this.Wynik.ToString() + do_jednostki);
        }
        public double Konwertuj(string z_jednostki, string do_jednostki, double dana)
        {
            this.Dana = dana;
            if (z_jednostki == "Km")
            {
                if (do_jednostki == "Mi")
                {
                    this.Wynik = dana * 0.62137;
                }
                if (do_jednostki == "ft")
                {
                    this.Wynik = dana * 3280.8;
                }
            }
            if (z_jednostki == "Mi")
            {
                if (do_jednostki == "Km")
                {
                    this.Wynik = dana / 0.62137;
                }
                if (do_jednostki == "ft")
                {
                    this.Wynik = dana * 5280;
                }
            }
            if (z_jednostki == "ft")
            {
                if (do_jednostki == "Km")
                {
                    this.Wynik = dana / 3280.8;
                }
                if (do_jednostki == "Mi")
                {
                    this.Wynik = dana / 5280;
                }
            }
            if (z_jednostki == do_jednostki)
            {
                this.wynik = dana;
            }
            return this.Wynik;
        }
    }
}
